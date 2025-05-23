using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NLog;
using InvSis.Model;
using InvSis.Utilities;

namespace InvSis.Data
{
    public class UsuariosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.UsuariosDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly PersonasDataAccess _personasData;
        private readonly RolesDataAccess _rolesData;

        public UsuariosDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _personasData = new PersonasDataAccess();
                _rolesData = new RolesDataAccess();
                _logger.Info("UsuariosDataAccess inicializado correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar UsuariosDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos
        /// </summary>
        public int InsertarUsuario(Usuario usuario)
        {
            try
            {
                // Validaciones obligatorias
                if (usuario == null) throw new ArgumentNullException(nameof(usuario));
                if (usuario.Persona == null) throw new ArgumentException("El usuario debe tener una Persona asociada");
                if (usuario.Rol == null) throw new ArgumentException("El usuario debe tener un Rol asociado");

                // Verificar existencia en la base de datos
                var personaExistente = _personasData.ObtenerPersonaPorId(usuario.IdPersona) ??
                    throw new DataException($"No existe la persona con ID {usuario.IdPersona}");

                var rolExistente = _rolesData.ObtenerRolPorId(usuario.IdRol) ??
                    throw new DataException($"No existe el rol con ID {usuario.IdRol}");

                if (ExisteNickname(usuario.Nickname))
                    throw new InvalidOperationException($"El nickname {usuario.Nickname} ya está en uso");

                string query = @"INSERT INTO Usuarios (id_rol, id_persona, nickname, contrasena, estatus) 
                                VALUES (@IdRol, @IdPersona, @Nickname, @Contrasena, @Estatus) 
                                RETURNING id_usuario";

                var parameters = new[]
                {
                    _dbAccess.CreateParameter("@IdRol", usuario.IdRol),
                    _dbAccess.CreateParameter("@IdPersona", usuario.IdPersona),
                    _dbAccess.CreateParameter("@Nickname", usuario.Nickname),
                    _dbAccess.CreateParameter("@Contrasena", usuario.Contraseña),
                    _dbAccess.CreateParameter("@Estatus", usuario.Estatus)
                };

                _dbAccess.Connect();
                var idGenerado = Convert.ToInt32(_dbAccess.ExecuteScalar(query, parameters));

                _logger.Info($"Usuario insertado correctamente con ID: {idGenerado}");
                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el usuario {usuario?.Nickname}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente
        /// </summary>
        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                // Validaciones obligatorias
                if (usuario == null) throw new ArgumentNullException(nameof(usuario));
                if (usuario.Persona == null) throw new ArgumentException("El usuario debe tener una Persona asociada");
                if (usuario.Rol == null) throw new ArgumentException("El usuario debe tener un Rol asociado");

                // Verificar existencia en la base de datos
                var personaExistente = _personasData.ObtenerPersonaPorId(usuario.IdPersona) ??
                    throw new DataException($"No existe la persona con ID {usuario.IdPersona}");

                var rolExistente = _rolesData.ObtenerRolPorId(usuario.IdRol) ??
                    throw new DataException($"No existe el rol con ID {usuario.IdRol}");

                if (ExisteNickname(usuario.Nickname, usuario.IdUsuario))
                    throw new InvalidOperationException($"El nickname {usuario.Nickname} ya está en uso");

                string query = @"UPDATE Usuarios 
                                SET id_rol = @IdRol, 
                                    id_persona = @IdPersona, 
                                    nickname = @Nickname, 
                                    contrasena = @Contrasena, 
                                    estatus = @Estatus 
                                WHERE id_usuario = @IdUsuario";

                var parameters = new[]
                {
                    _dbAccess.CreateParameter("@IdUsuario", usuario.IdUsuario),
                    _dbAccess.CreateParameter("@IdRol", usuario.IdRol),
                    _dbAccess.CreateParameter("@IdPersona", usuario.IdPersona),
                    _dbAccess.CreateParameter("@Nickname", usuario.Nickname),
                    _dbAccess.CreateParameter("@Contrasena", usuario.Contraseña),
                    _dbAccess.CreateParameter("@Estatus", usuario.Estatus)
                };

                _dbAccess.Connect();
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, parameters);

                if (filasAfectadas > 0)
                {
                    _logger.Info($"Usuario con ID {usuario.IdUsuario} actualizado correctamente");
                    return true;
                }

                _logger.Warn($"No se encontró el usuario con ID {usuario.IdUsuario} para actualizar");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el usuario con ID {usuario?.IdUsuario}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID con todas sus relaciones cargadas
        /// </summary>
        public Usuario? ObtenerUsuarioPorId(int idUsuario)
        {
            try
            {
                string query = @"SELECT id_usuario, id_rol, id_persona, nickname, contrasena, estatus 
                               FROM Usuarios 
                               WHERE id_usuario = @IdUsuario";

                var paramId = _dbAccess.CreateParameter("@IdUsuario", idUsuario);
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún usuario con ID {idUsuario}");
                    return null;
                }

                DataRow row = resultado.Rows[0];
                var usuario = new Usuario(
                    Convert.ToInt32(row["id_usuario"]),
                    Convert.ToInt32(row["id_rol"]),
                    Convert.ToInt32(row["id_persona"]),
                    row["nickname"].ToString() ?? string.Empty,
                    row["contrasena"].ToString() ?? string.Empty,
                    Convert.ToInt32(row["estatus"])
                );

                // Cargar relaciones obligatorias
                usuario.Persona = _personasData.ObtenerPersonaPorId(usuario.IdPersona) ??
                    throw new DataException($"Persona con ID {usuario.IdPersona} no encontrada");

                usuario.Rol = _rolesData.ObtenerRolPorId(usuario.IdRol) ??
                    throw new DataException($"Rol con ID {usuario.IdRol} no encontrado");

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el usuario con ID {idUsuario}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios activos del sistema
        /// </summary>
        public List<Usuario> ObtenerTodosLosUsuarios(bool soloActivos = true)
        {
            var usuarios = new List<Usuario>();

            try
            {
                string query = @"SELECT id_usuario, id_rol, id_persona, nickname, contrasena, estatus 
                               FROM Usuarios 
                               WHERE 1=1";

                if (soloActivos) query += " AND estatus = 1";
                query += " ORDER BY nickname";

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                foreach (DataRow row in resultado.Rows)
                {
                    var usuario = new Usuario(
                        Convert.ToInt32(row["id_usuario"]),
                        Convert.ToInt32(row["id_rol"]),
                        Convert.ToInt32(row["id_persona"]),
                        row["nickname"].ToString() ?? string.Empty,
                        row["contrasena"].ToString() ?? string.Empty,
                        Convert.ToInt32(row["estatus"])
                    );

                    // Cargar relaciones obligatorias
                    usuario.Persona = _personasData.ObtenerPersonaPorId(usuario.IdPersona) ??
                        throw new DataException($"Persona con ID {usuario.IdPersona} no encontrada");

                    usuario.Rol = _rolesData.ObtenerRolPorId(usuario.IdRol) ??
                        throw new DataException($"Rol con ID {usuario.IdRol} no encontrado");

                    usuarios.Add(usuario);
                }

                _logger.Info($"Se obtuvieron {usuarios.Count} usuarios");
                return usuarios;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los usuarios");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Autentica un usuario por nickname y contraseña
        /// </summary>
        public Usuario? AutenticarUsuario(string nickname, string contrasena)
        {
            try
            {
                string query = @"SELECT id_usuario, id_rol, id_persona, nickname, contrasena, estatus 
                               FROM Usuarios 
                               WHERE nickname = @Nickname 
                               AND contrasena = @Contrasena 
                               AND estatus = 1";

                var parameters = new[]
                {
                    _dbAccess.CreateParameter("@Nickname", nickname),
                    _dbAccess.CreateParameter("@Contrasena", contrasena)
                };

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, parameters);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"Autenticación fallida para el usuario {nickname}");
                    return null;
                }

                DataRow row = resultado.Rows[0];
                var usuario = new Usuario(
                    Convert.ToInt32(row["id_usuario"]),
                    Convert.ToInt32(row["id_rol"]),
                    Convert.ToInt32(row["id_persona"]),
                    row["nickname"].ToString() ?? string.Empty,
                    row["contrasena"].ToString() ?? string.Empty,
                    Convert.ToInt32(row["estatus"])
                );

                // Cargar relaciones obligatorias
                usuario.Persona = _personasData.ObtenerPersonaPorId(usuario.IdPersona) ??
                    throw new DataException($"Persona con ID {usuario.IdPersona} no encontrada");

                usuario.Rol = _rolesData.ObtenerRolPorId(usuario.IdRol) ??
                    throw new DataException($"Rol con ID {usuario.IdRol} no encontrado");

                _logger.Info($"Usuario {nickname} autenticado correctamente");
                return usuario;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al autenticar al usuario {nickname}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si un nickname ya existe en la base de datos
        /// </summary>
        public bool ExisteNickname(string nickname, int idUsuarioExcluir = 0)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM Usuarios 
                                WHERE nickname = @Nickname";

                if (idUsuarioExcluir > 0)
                    query += " AND id_usuario != @IdUsuario";

                var parameters = new List<NpgsqlParameter>
                {
                    _dbAccess.CreateParameter("@Nickname", nickname)
                };

                if (idUsuarioExcluir > 0)
                    parameters.Add(_dbAccess.CreateParameter("@IdUsuario", idUsuarioExcluir));

                _dbAccess.Connect();
                var count = Convert.ToInt32(_dbAccess.ExecuteScalar(query, parameters.ToArray()));

                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar el nickname {nickname}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina lógicamente un usuario (cambia su estatus a inactivo)
        /// </summary>
        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                string query = "UPDATE Usuarios SET estatus = 2 WHERE id_usuario = @IdUsuario";
                var paramId = _dbAccess.CreateParameter("@IdUsuario", idUsuario);

                _dbAccess.Connect();
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                if (filasAfectadas > 0)
                {
                    _logger.Info($"Usuario con ID {idUsuario} desactivado correctamente");
                    return true;
                }

                _logger.Warn($"No se encontró el usuario con ID {idUsuario} para desactivar");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al desactivar el usuario con ID {idUsuario}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }
}
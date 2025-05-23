using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NLog;
using InvSis.Utilities;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;

namespace InvSis.Data
{
    public class PostgreSQLDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.PostgreSQLDataAccess");
        //cadena de conexion desde Ap.cpnfig
        //private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        //le indiica al dataacces donde esta la cadena de conexion que esta appConfig
        private static string _connectionString;
        private NpgsqlConnection _connection;
        private static PostgreSQLDataAccess? _instance;
        //para crear solo una instancias y no tenerlas repertidas

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    try
                    {
                        // Intenta obtener desde ConfigurationManager (Windows Forms)
                        _connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"]?.ConnectionString;
                    }
                    catch (Exception ex)
                    {
                        _logger.Warn(ex, "No se pudo obtener la cadena de conexión desde ConfigurationManager");
                    }
                }
                return _connectionString;
            }
            set { _connectionString = value; }
        }

        //constrauctor
        private PostgreSQLDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión no está configurada. Asegúrate de establecer PostgreSQLDataAccess.ConnectionString antes de usar la clase.");
                }

                _connection = new NpgsqlConnection(ConnectionString);
                _logger.Info("Instancia de acceso a datos creada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar el acceso a la base de datos");
                throw;
            }
        }

        public NpgsqlParameter CreateParameter(string name, object value)
        {
            return new NpgsqlParameter(name, value ?? DBNull.Value);
        }

        public static PostgreSQLDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PostgreSQLDataAccess();
            }
            return _instance;
        }

        public bool Connect()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                    _logger.Info("Conexión a la base de datos establecida correctamente");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al conectar a la base de datos");
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Close();
                    _logger.Info("Conexión a la base de datos cerrada correctamente");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al cerrar la conexión a la base de datos");
                throw;
            }
        }

        public DataTable ExecuteQuery_Reader(string query, params NpgsqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable); //como el execute reader
                    }
                    command.Dispose();
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al ejecutar la consulta");
                throw;
            }
        }

        private NpgsqlCommand CreateCommand(string query, params NpgsqlParameter[] parameters)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
                foreach (var param in parameters)
                {
                    _logger.Trace($"Parámetro: {param.ParameterName} = {param.Value ?? "NULL"}");
                }
            }

            return command;
        }

        public int ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    int result = command.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la operación: {query}");
                throw;
            }
        }

        public object ExecuteScalar(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    object? result = command.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar la operación: {query}");
                throw;
            }
        }
    }
}

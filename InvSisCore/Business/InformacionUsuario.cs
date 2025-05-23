using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using NLog;
using InvSis.Utilities;

namespace InvSis.Business
{
    public static class InformacionUsuario
    {
        public static string obtenerNombreComputadora ()
        {
            string nombreComputadora = Environment.MachineName;
            return nombreComputadora;
        }

/*
    Implementación de ip:
    // Obtener la IP (método asíncrono)
                string ip = await InformacionUusuario.ObtenerIpCompletaAsync();

    // Mostrar resultado al usuario
    txtResultadoIP.Text = ip;
*/

        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Business.InformacionUsuario");

        public static async Task<string> ObtenerIpCompletaAsync()
        {
            try
            {
                _logger.Trace("Iniciando obtención de dirección IP...");

                // Primero intentamos obtener la IP pública
                string ipPublica = await ObtenerIpPublicaAsync();

                if (!string.IsNullOrWhiteSpace(ipPublica))
                {
                    _logger.Info($"IP pública obtenida: {ipPublica}");
                    return ipPublica;
                }

                // Si no hay IP pública, intentamos con la local
                string ipLocal = ObtenerIpLocal();
                _logger.Info($"Usando IP local: {ipLocal} (no se pudo obtener IP pública)");
                return ipLocal;
            }
            catch (NetworkInformationException ex)
            {
                _logger.Error(ex, "Error al obtener dirección IP");
                throw;
            }
        }

        private static async Task<string> ObtenerIpPublicaAsync()
        {
            try
            {
                _logger.Debug("Intentando obtener IP pública...");

                using (var cliente = new HttpClient { Timeout = TimeSpan.FromSeconds(5) })
                {
                    var servicios = new[]
                    {
                    "https://api.ipify.org",
                    "https://icanhazip.com",
                    "https://ipinfo.io/ip"
                };

                    foreach (var servicio in servicios)
                    {
                        try
                        {
                            _logger.Trace($"Probando servicio: {servicio}");
                            var respuesta = await cliente.GetStringAsync(servicio);

                            if (!string.IsNullOrWhiteSpace(respuesta))
                            {
                                string ip = respuesta.Trim();
                                _logger.Debug($"IP obtenida del servicio {servicio}: {ip}");
                                return ip;
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Trace($"Fallo con servicio {servicio}: {ex.Message}");
                            continue;
                        }
                    }
                }

                var mensajeError = "Todos los servicios de IP pública fallaron";
                _logger.Warn(mensajeError);
                throw new NetworkInformationException(mensajeError);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error en ObtenerIpPublicaAsync");
                throw new NetworkInformationException("Error al obtener IP pública", ex);
            }
        }

        private static string ObtenerIpLocal()
        {
            try
            {
                _logger.Debug("Obteniendo IP local...");

                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var direccion in host.AddressList)
                {
                    if (direccion.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string ip = direccion.ToString();
                        _logger.Debug($"IP local encontrada: {ip}");
                        return ip;
                    }
                }

                var mensajeError = "No se encontraron adaptadores de red IPv4";
                _logger.Warn(mensajeError);
                throw new NetworkInformationException(mensajeError);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error en ObtenerIpLocal");
                throw new NetworkInformationException("Error al obtener IP local", ex);
            }
        }
    }

    public class NetworkInformationException : Exception
    {
        public NetworkInformationException() { }
        public NetworkInformationException(string message) : base(message) { }
        public NetworkInformationException(string message, Exception inner) : base(message, inner) { }
    }

    
}
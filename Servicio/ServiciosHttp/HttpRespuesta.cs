using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Servicio.ServiciosHttp
{
    //public class HttpRespuesta<T>
    //{
    //    private readonly T respuesta;
    //    private readonly bool error;
    //    private readonly HttpResponseMessage httpResponseMessage;

    //    public HttpRespuesta(T respuesta,bool error, HttpResponseMessage httpResponseMessage )
    //    {
    //        this.respuesta = respuesta;
    //        this.error = error;
    //        this.httpResponseMessage = httpResponseMessage;
    //    }

    //    public T Respuesta { get; }
    //    public bool Error { get; }
    //    public HttpResponseMessage HttpResponseMessage { get; set; }

    //    public string ObtenerError()
    //    {
    //        if (!Error)
    //        {
    //            return string.Empty;
    //        }
    //        else
    //        {
    //            var statudCode = HttpResponseMessage.StatusCode;
    //            switch (statudCode)
    //            {
    //                case HttpStatusCode.NotFound:
    //                    return "Recurso no encontrado.";
    //                case HttpStatusCode.BadRequest:
    //                    return "Solicitud incorrecta.";
    //                case HttpStatusCode.InternalServerError:
    //                    return "Error interno del servidor.";
    //                case HttpStatusCode.Unauthorized:
    //                    return "No autorizado.";
    //                default:
    //                    return $"Error desconocido. Código de estado: {statudCode}";
    //            }
    //        }
    //    }
    //}
    public class HttpRespuesta<T>
    {
        public HttpRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public string ObtenerError()
        {
            if (!Error)
            {
                return string.Empty;
            }

            return HttpResponseMessage.StatusCode switch
            {
                HttpStatusCode.NotFound => "Recurso no encontrado.",
                HttpStatusCode.BadRequest => "Solicitud incorrecta.",
                HttpStatusCode.InternalServerError => "Error interno del servidor.",
                HttpStatusCode.Unauthorized => "No autorizado.",
                _ => $"Error desconocido. Código de estado: {HttpResponseMessage.StatusCode}"
            };
        }
    }
}

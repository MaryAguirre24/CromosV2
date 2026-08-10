using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Servicio.ServiciosHttp
{
    public class HttpServicio : IHttpServicio
    {
        private readonly HttpClient http;

        public HttpServicio(HttpClient Http)
        {
            this.http = Http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<T>(response);
                return new HttpRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, response);
            }

        }

        public async Task<HttpRespuesta<TResp>> Post<T, TResp>(string url, T entidad)
        {
            var JasonAEnviar = JsonSerializer.Serialize(entidad);
            var contenido = new StringContent(JasonAEnviar, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(url, contenido);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<TResp>(response);
                return new HttpRespuesta<TResp>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<TResp>(default, true, response);
            }
        }
        public async Task<HttpRespuesta<TResp>> Put<T, TResp>(string url, T entidad)
        {
            var JasonAEnviar = JsonSerializer.Serialize(entidad);
            var contenido = new StringContent(JasonAEnviar, Encoding.UTF8, "application/json");
            var response = await http.PutAsync(url, contenido);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<TResp>(response);
                return new HttpRespuesta<TResp>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<TResp>(default, true, response);
            }
        }

        public async Task<HttpRespuesta<TResp>> Delete<TResp>(string url)
        {
            var resp = await http.DeleteAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<TResp>(resp);
                return new HttpRespuesta<TResp>(respuesta, false, resp);
            }
            else
            {
                return new HttpRespuesta<TResp>(default, true, resp);
            }
        }

        private async Task<T?> DesSerializar<T>(HttpResponseMessage response)
        {
            var respString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respString,
              new JsonSerializerOptions
              {
                  PropertyNameCaseInsensitive = true
              });
        }
    }
}


using Microsoft.JSInterop;
using Microsoft.Extensions.Logging;

namespace barber.JsInterop.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _JsRuntime;
        private readonly ILogger _Logger;

        public LocalStorageService(IJSRuntime jsRuntime, ILogger<LocalStorageService> logger)
        {
            _JsRuntime = jsRuntime;
            _Logger = logger;
        }

        public async System.Threading.Tasks.Task Add<T>(string key, T value)
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(value);
                await _JsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
            }
            catch (System.InvalidOperationException ex)
            {
                _Logger.LogWarning(ex.ToString());
            }
        }

        public async System.Threading.Tasks.Task<T?> Get<T>(string key)
        {
            try
            {
                var json = await _JsRuntime.InvokeAsync<string>("localStorage.getItem", key);
                return json == null ? default : System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (System.InvalidOperationException ex)
            {
                _Logger.LogWarning(ex.ToString());
                return default;
            }
        }

        public async System.Threading.Tasks.Task Remove(string key)
        {
            try
            {
                await _JsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
            }
            catch (System.InvalidOperationException ex)
            {
                _Logger.LogWarning(ex.ToString());
            }
        }
    }
}
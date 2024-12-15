namespace barber.JsInterop.Services
{
    public interface ILocalStorageService
    {
        System.Threading.Tasks.Task Add<T>(string key, T value);

        System.Threading.Tasks.Task<T?> Get<T>(string key);

        System.Threading.Tasks.Task Remove(string key);
    }
}
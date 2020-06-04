using FireSharp.Response;
using System;
using System.Threading.Tasks;

namespace FireSharp.Interfaces
{
    public interface IFirebaseClient
    {
        DeleteResponse Delete(string path);
        Task<DeleteResponse> DeleteTaskAsync(string path);
        FirebaseResponse Get(string path);
        Task<FirebaseResponse> GetTaskAsync(string path);
        PushResponse Push<T>(string path, T data);
        Task<PushResponse> PushTaskAsync<T>(string path, T data);
        SetResponse Set<T>(string path, T data);
        Task<SetResponse> SetTaskAsync<T>(string path, T data);
        FirebaseResponse Update<T>(string path, T data);
        Task<FirebaseResponse> UpdateTaskAsync<T>(string path, T data);
    }

    public class DeleteResponse
    {
    }
}

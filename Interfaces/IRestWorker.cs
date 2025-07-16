using SpaceStation.Enums;
using SpaceStation.Models;
using System.Collections.Specialized;

namespace SpaceStation.Interfaces
{
    public interface IRestWorker
    {
        public Task<T> CallService<T>(Uri uri, HttpVerb httpVerb = HttpVerb.Get, object data = null, NameValueCollection headerData = null) where T : BaseResponse, new();
    }
}
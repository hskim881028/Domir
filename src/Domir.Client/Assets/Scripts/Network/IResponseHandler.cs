using Domir.Shared.Response;

namespace Domir.Client.Network
{
    public interface IResponseHandler
    {
        public bool HandleResponse(IResponse response);
    }
}
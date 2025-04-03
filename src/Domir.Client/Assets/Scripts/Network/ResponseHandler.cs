using Domir.Client.Infrastructure;
using Domir.Shared.Common;
using Domir.Shared.Response;

namespace Domir.Client.Network
{
    public class ResponseHandler : IResponseHandler
    {
        public bool HandleResponse(IResponse response)
        {
            if (response.StatusCode != StatusCode.Success)
            {
                ZLog.StatusCodeException(response.StatusCode);
                return false;
            }

            return true;
        }
    }
}
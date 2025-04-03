using Domir.Shared.Response;
using UnityEngine;

namespace Domir.Client.Network
{
    public class ResponseHandler : IResponseHandler
    {
        public bool HandleResponse(IResponse response)
        {
            Debug.Log("");
            return true;
        }
    }
}
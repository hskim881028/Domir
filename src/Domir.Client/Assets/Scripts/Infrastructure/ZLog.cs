using Cysharp.Text;
using Domir.Shared.Common;
using MagicOnion.Client;
using UnityEngine;

namespace Domir.Client.Infrastructure
{
    public static class ZLog
    {
        public static void Request(RequestContext requestContext)
        {
#if UNITY_EDITOR
            if (!Debug.isDebugBuild) return;

            using var sb = ZString.CreateStringBuilder();
            sb.Append("<color=#4FC3F7>[Req]</color> ");
            sb.Append(requestContext.MethodPath);
            sb.Append("\n");
            sb.Append(JsonHelper.ExtractKey(requestContext, "Request"));
            Debug.Log(sb.ToString());
#endif
        }

        public static void Response(string methodPath, double elapsed, ResponseContext responseContext)
        {
#if UNITY_EDITOR
            if (!Debug.isDebugBuild) return;

            using var sb = ZString.CreateStringBuilder();
            sb.Append("<color=#81C784>[Res]</color> ");
            sb.Append(methodPath);
            sb.Append(" (Elapsed:");
            sb.Append(GetElapsedColor(elapsed));
            sb.Append(elapsed.ToString("0.0"));
            sb.Append("</color>ms)\n");
            sb.Append(JsonHelper.ExtractNestedKey(responseContext, "ResponseAsync", "Result"));
            Debug.Log(sb.ToString());
#endif
        }

        public static void StatusCodeException(int code)
        {
#if UNITY_EDITOR
            if (!Debug.isDebugBuild) return;

            using var sb = ZString.CreateStringBuilder();
            sb.Append("<color=#FF5252>[Err]</color> ");
            Debug.Log(StatusCodeMapper.ToMessage(code));
            sb.Append("</color>)");
#endif
        }


        private static string GetElapsedColor(double elapsed)
        {
            return elapsed <= 300 ? "<color=#81C784>" :
                elapsed <= 800 ? "<color=#FFD54F>" :
                "<color=#E57373>";
        }
    }
}
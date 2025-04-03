using Cysharp.Text;
using MagicOnion.Client;
using UnityEngine;

namespace Domir.Client.Core
{
    public static class ZLog
    {
        public static void Request(RequestContext requestContext)
        {
#if UNITY_EDITOR
            if (!Debug.isDebugBuild) return;

            Debug.Log(BuildRequestLog(requestContext));
#endif
        }

        public static void Response(string methodPath, double elapsed, ResponseContext responseContext)
        {
#if UNITY_EDITOR
            if (!Debug.isDebugBuild) return;

            Debug.Log(BuildResponseLog(methodPath, elapsed, responseContext));
#endif
        }

        private static string BuildRequestLog(RequestContext requestContext)
        {
            using var sb = ZString.CreateStringBuilder();
            sb.Append("<color=#4FC3F7>[Req]</color> ");
            sb.Append(requestContext.MethodPath);
            sb.Append("\n");
            sb.Append(JsonHelper.ExtractKey(requestContext, "Request"));
            return sb.ToString();
        }

        private static string BuildResponseLog(string methodPath, double elapsed, ResponseContext responseContext)
        {
            using var sb = ZString.CreateStringBuilder();
            sb.Append("<color=#81C784>[Res]</color> ");
            sb.Append(methodPath);
            sb.Append(" (Elapsed:");
            sb.Append(GetElapsedColor(elapsed));
            sb.Append(elapsed.ToString("0.0"));
            sb.Append("</color>ms)\n");
            sb.Append(JsonHelper.ExtractNestedKey(responseContext, "ResponseAsync", "Result"));
            return sb.ToString();
        }

        private static string GetElapsedColor(double elapsed) =>
            elapsed <= 300 ? "<color=#81C784>" :
            elapsed <= 800 ? "<color=#FFD54F>" :
            "<color=#E57373>";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace _
{
    [HarmonyPatch]
    public class _NetworkManager
    {
        [HarmonyPatch(typeof(LoadingScene), nameof(LoadingScene.Start))]
        [HarmonyPrefix]
        public static void start0()
        {
            Console.WriteLine("[0] LoadingScene: Start");
        }
        [HarmonyPatch(typeof(HttpRequestManager), nameof(HttpRequestManager.ReportClientInfo))]
        [HarmonyPrefix]
        public static void rep()
        {
            Console.WriteLine("[1] HttpRequestManager.ReportClientInfo");
        }
        [HarmonyPatch(typeof(HttpRequestManager), nameof(HttpRequestManager.TrackingStats),new Type[] { typeof(TrackingStatsType), typeof(string), typeof(bool) })]
        [HarmonyPrefix]
        public static void tasks(TrackingStatsType type, string strParams = "", bool parallel = false)
        {
            Console.WriteLine("HttpRequestManager.TrackingStats");
            Console.WriteLine($"type:{type},parallel:{parallel}");
            Console.WriteLine($"strParams:{strParams}");
        }
        [HarmonyPatch(typeof(HttpRequestManager), nameof(HttpRequestManager.TrackingStats), new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool) })]
        [HarmonyPrefix]
        public static void tasks2(string type, string eventType = "", string eventSubType = "", string action = "", string subId = "", string source = "", string nums = "", string strParams = "", bool parallel = false)
        {
            Console.WriteLine("HttpRequestManager.TrackingStats");
            Console.WriteLine($"type:{type},eventType:{eventType},eventSubType:{eventSubType},action:{action},subId:{subId},source:{source},nums:{nums},strParams:{strParams},parallel:{parallel}");
        }
        [HarmonyPatch(typeof(HttpRequest), nameof(HttpRequest.Request))]
        [HarmonyPrefix]
        public static void reqs(HttpRequest __instance, string url, string postContent, HttpRequest.HttpRequestCallback callback, bool start = true, int retryCount = 1)
        {
            Console.WriteLine($"HttpRequest.Request Prefix   trackType:{__instance.trackType}");
            Console.WriteLine($"url:{url}\n postContent:{postContent}\n start:{start},retryCount:{retryCount}");
        }
        [HarmonyPatch(typeof(HttpRequest), nameof(HttpRequest.Request))]
        [HarmonyPostfix]
        public static void reqs2(HttpRequest __instance, string url, string postContent, HttpRequest.HttpRequestCallback callback, bool start = true, int retryCount = 1)
        {
            Console.WriteLine($"HttpRequest.Request Postfix   trackType:{__instance.trackType}");
            Action<Il2CppSystem.Object, string, Il2CppSystem.Net.WebExceptionStatus> action = (a, b, c) => {
                Console.WriteLine($"Http Responce: {b}\nstatus:{c}");
            };
            __instance._callback += DelegateSupport.ConvertDelegate<HttpRequest.HttpRequestCallback>(action);
        }
        
        [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.Init))]
        [HarmonyPrefix]
        public static void Init(int times = 1)
        {
            Console.WriteLine("NetworkManager: Init");
            Console.WriteLine("times: " + times);
        }
        [HarmonyPatch(typeof(LoginHelper._ProtobufConnect_c__AnonStorey0), nameof(LoginHelper._ProtobufConnect_c__AnonStorey0.__m__0))]
        [HarmonyPrefix]
        private static void __m__0(string ipName)
        {
            Console.WriteLine("__m__0: " + ipName);
            Console.WriteLine(new System.Diagnostics.StackTrace());
        }
        [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.Connect))]
        [HarmonyPrefix]
        private static void Connect(string serverName, string serverIP, int port, int times = 1)
        {
            Console.WriteLine("serverName: " + serverName);
            Console.WriteLine("serverIP: " + serverIP);
            Console.WriteLine("port: " + port);
            Console.WriteLine("times: " + times);
        }
        [HarmonyPatch(typeof(LoginHelper), MethodType.Constructor)]
        [HarmonyPrefix]
        private static void LoginHelperCtor()
        {
            Console.WriteLine("LoginHelperCtor");
        }
    }
    public class Tool
    {
        public static string GetIpandPort()
        {
            return $"IP:{Config.address}:{Config.port}";
        }
        public static bool GetDebugOpen()
        {
            return EvonyDebug.enableLog;
        }
    }
}

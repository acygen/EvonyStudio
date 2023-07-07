using HarmonyLib;
using Msg;
using MsgDown;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EvonyStudio
{
    [HarmonyPatch]
    public class _LoadingScene
    {
        private static int _token = 0;

        [HarmonyPatch(typeof(LoadingManager), nameof(LoadingManager.onHttpLoginSuccess))]
        //[HarmonyPrefix]
        public static void onHttpLoginSuccess(Il2CppSystem.Collections.Generic.Dictionary<string, string> dic)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                IgnoreReadOnlyProperties = true,
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
            };

            string jsonString = JsonSerializer.Serialize(dic, options);
            Console.WriteLine(jsonString);
        }
    }
}

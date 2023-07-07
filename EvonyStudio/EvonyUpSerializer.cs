using BepInEx;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Msg;
using MsgDown;
using MsgUp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using YamlDotNet.Core.Tokens;

namespace EvonyStudio
{
    [HarmonyPatch]
    public class _EvonyUpSerializer
    {
        /*[HarmonyPatch(typeof(MsgUp.request_mapinfo), MethodType.Constructor)]
        public class request_mapinfo
        {
            [HarmonyPostfix]
            private static void request_mapinfoCtor(request_mapinfo __instance)
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true,
                    NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                };

                string jsonString = JsonSerializer.Serialize(__instance, options);

                Console.WriteLine(jsonString);
            }
        }*/
        /*[HarmonyPatch(typeof(MsgUp.request_mapinfo), "get__server_id")]
        [HarmonyPostfix]
        public static void get__server_id(ref int __result)
        {
            //__result = 0;
            Console.WriteLine(__result);
        }*/
        /*static bool set__wxChecker;

        [HarmonyPatch(typeof(MsgUp.request_mapinfo), "set__wx")]
        [HarmonyPostfix]
        public static void set__wx(MsgUp.request_mapinfo __instance, ref int value)
        {
            if (__instance.__server_id == 1406)
            {
                //value = 2;
                //__instance.__wx = 0;
                Console.WriteLine("set__wx:" + __instance._wx);
                set__wxChecker = true;
            }
        }
        static bool set__wyChecker;

        [HarmonyPatch(typeof(MsgUp.request_mapinfo), "set__wy")]
        [HarmonyPostfix]
        public static void set__wy(MsgUp.request_mapinfo __instance, ref int value)
        {
            if (__instance.__server_id == 1406)
            {
                //value = 2;
                //__instance.__wy = 0;
                Console.WriteLine("set__wy:" + __instance._wy);
                set__wyChecker = true;
            }
        }

        [HarmonyPatch(typeof(MsgUp.request_mapinfo), "set__width")]
        [HarmonyPrefix]
        public static bool set__width(MsgUp.request_mapinfo __instance, ref int value)
        {
            if (__instance.__server_id == 1406 && value == 16)
            {
                //value = 100;
                __instance.__width = 1200;
                __instance._width = 1200;
                //Console.WriteLine("set__width:" + __instance._width);
                return false;
            }
            return true;
        }

        [HarmonyPatch(typeof(Msg.mapinfo), "get__wx")]
        [HarmonyPostfix]
        public static void get__wx(Msg.mapinfo __instance, ref int __result)
        {
            if (set__wxChecker)
            {
                //value = 2;
                //__instance.__wy = 0;
                Console.WriteLine("Msgset__wx:" + __result);
                set__wxChecker = false;
            }
        }

        [HarmonyPatch(typeof(Msg.mapinfo), "get__wy")]
        [HarmonyPostfix]
        public static void get__wy(Msg.mapinfo __instance, ref int __result)
        {
            if (set__wyChecker)
            {
                //value = 2;
                //__instance.__wy = 0;
                Console.WriteLine("Msgset__wy:" + __result);
                set__wyChecker = false;
            }
        }*/

        [HarmonyPatch(typeof(MsgUp.up_msg), "_request_worldmap", MethodType.Getter)]
        //[HarmonyPostfix]
        public static void get__request_worldmap(ref MsgUp.request_mapinfo __result)
        {
            try
            {
                if (__result is null)
                {
                    return;
                }

                if (__result.__server_id != 1406)
                {
                    return;
                }

                {
                    __result._wx = 1;
                    __result._wy = 1;
                    __result._width = 100;
                }

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    IgnoreReadOnlyProperties = true,
                    WriteIndented = true,
                    NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                };

                string jsonString = JsonSerializer.Serialize(__result, options);

                Console.WriteLine(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

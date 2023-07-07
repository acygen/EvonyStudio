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
    public class _EvonyDownSerializer
    {
        private static int _token = 0;

        [HarmonyPatch(typeof(EvonyDownSerializer), nameof(EvonyDownSerializer.Deserialize))]
        [HarmonyPostfix]
        public static void Deserialize(ref Il2CppSystem.Object __result, int __0)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(__result.Cast<MsgDown.down_msg>()));
            //Console.WriteLine(__0);
            /*var serializer = new JsonSerializerSettings
            {
                *//*NullValueHandling = NullValueHandling.Ignore,*//*
                ContractResolver = new IgnorePropertiesContractResolver(new[] { "ObjectClass", "Pointer", "WasCollected" })
            };*/
            //Console.WriteLine(new System.Diagnostics.StackTrace());
            if (__0 == 253)
                if (_token != 0) return;
                else
                {
                    MsgDown.down_msg down_Msg = __result.Cast<MsgDown.down_msg>();
                    var options = new JsonSerializerOptions
                    {
                        IncludeFields = true,
                        IgnoreReadOnlyProperties = true,
                        WriteIndented = true,
                        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    };

                    //string jsonString = JsonSerializer.Serialize(down_Msg, options);
                    //Console.WriteLine(jsonString);
                    if (down_Msg.__request_worldmap_reply != null)
                    {
                        /*foreach (MsgDown.map_target_info map_target_info in down_Msg.__request_worldmap_reply.__map_target_info)
                        {
                            if (map_target_info._troop_owner == 241097744)
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(map_target_info));
                            }
                        }*/
                        /*for (int i = 0; i < down_Msg.__request_worldmap_reply.__map_target_info.Count; i++)
                        {
                            MsgDown.map_target_info map_target_info = down_Msg.__request_worldmap_reply.__map_target_info[i];

                            //Console.WriteLine(map_target_info._troop_owner);

                            if (map_target_info._troop_owner == 241097744)
                            {
                                var options = new JsonSerializerOptions
                                {
                                    IncludeFields = true,
                                    IgnoreReadOnlyProperties = true,
                                    WriteIndented = true,
                                    NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                                };

                                string jsonString = JsonSerializer.Serialize(map_target_info, options);
                                ((Il2CppSystem.Object)map_target_info.__troop_owner).GetIl2CppType();

                                //Console.WriteLine(JsonConvert.SerializeObject(map_target_info, serializer));
                                Console.WriteLine(jsonString);
                            }
                        }*/
                        /*for (int i = 0; i < down_Msg.__request_worldmap_reply.__mapinfo.Count; i++)
                        {
                            Msg.mapinfo mapinfo = down_Msg.__request_worldmap_reply.__mapinfo[i];

                            //Console.WriteLine(mapinfo._id);
                            if (mapinfo._type == 7 && mapinfo._level == 13.)
                            {
                                var options = new JsonSerializerOptions
                                {
                                    IncludeFields = true,
                                    IgnoreReadOnlyProperties = true,
                                    WriteIndented = true,
                                    NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                                };

                                string jsonString = JsonSerializer.Serialize(mapinfo, options);

                                //Console.WriteLine(JsonConvert.SerializeObject(mapinfo, serializer));
                                Console.WriteLine(jsonString);
                            }
                        }*/
                        for (int i = 0; i < down_Msg.__request_worldmap_reply.__sub_city.Count; i++)
                        {
                            MsgDown.sub_city_summary sub_city_summary = down_Msg.__request_worldmap_reply.__sub_city[i];

                            //Console.WriteLine(mapinfo._id);
                            if (sub_city_summary._sub_city_quality == MsgDown.sub_city_summary.sub_city_quality.gold)
                            {
                                /*var options = new JsonSerializerOptions
                                {
                                    IncludeFields = true,
                                    IgnoreReadOnlyProperties = true,
                                    WriteIndented = true,
                                    NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                                };

                                string jsonString = JsonSerializer.Serialize(sub_city_summary, options);*/

                                //Console.WriteLine(JsonConvert.SerializeObject(mapinfo, serializer));
                                Console.WriteLine("_name: " + sub_city_summary._name);
                                Console.WriteLine("_wx: " + sub_city_summary._wx);
                                Console.WriteLine("_wy: " + sub_city_summary._wy);
                                Console.WriteLine("==================================");
                            }
                        }

                    }
                    //_token = 1;
                }
            //Console.WriteLine(System.Text.Json.JsonSerializer.Serialize<MsgDown.down_msg>(__result.Cast<MsgDown.down_msg>()));
        }

        [HarmonyPatch(typeof(MsgDown.down_msg), "_request_worldmap_reply", MethodType.Getter)]
        //[HarmonyPostfix]
        public static void get__request_worldmap_reply(ref MsgDown.request_worldmap_reply __result)
        {
            if (__result == null)
            {
                return;
            }

            if (__result._server_id != 1406)
            {
                return;
            }

            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                IgnoreReadOnlyProperties = true,
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
            };

            string jsonString = JsonSerializer.Serialize(__result, options);

            //Console.WriteLine(jsonString);
            Console.WriteLine(__result._width);
        }
    }
}

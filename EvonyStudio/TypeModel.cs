using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.IO;
using Newtonsoft.Json;
using ProtoConfig;

namespace EvonyStudio
{
    [HarmonyPatch]
    public class _TypeModel
    {
        /*[HarmonyPatch(typeof(ProtoBuf.Meta.TypeModel), nameof(ProtoBuf.Meta.TypeModel.Deserialize), new Type[] { typeof(Stream), typeof(Il2CppSystem.Object), typeof(Il2CppSystem.Type) })]
        [HarmonyPostfix]
        public static void Deserialize(ref Il2CppSystem.Object __result, Stream source, Il2CppSystem.Object value, Il2CppSystem.Type type)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(__result.Cast<ProtoConfig.BundleMapConfigureList>()));
            //Console.WriteLine(__result.GetIl2CppType().FullName);
            var t = __result.GetIl2CppType().FullName;
            Console.WriteLine(t);
            *//*var t2 = typeof(ABTestConfigureList).Assembly.GetType(t);
            Console.WriteLine(t2);
            Console.WriteLine(JsonConvert.SerializeObject(
                typeof(Il2CppObjectBase).GetMethod(nameof(Il2CppObjectBase.Cast))
                !.MakeGenericMethod(t2).Invoke(__result, Array.Empty<object>())));*//*
        }*/
    }
}

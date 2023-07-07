using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace _
{
    [HarmonyPatch]
    public class _PackageErrorInfo
    {
        [HarmonyPatch(typeof(PackageErrorInfo), nameof(PackageErrorInfo.DecodePackage))]
        //[HarmonyPostfix]
        public static void DecodePackage(ref string __result, Il2CppStructArray<byte> package, int len, ref int errCode)
        {
            Console.WriteLine(__result);
        }
    }
}

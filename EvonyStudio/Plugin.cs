using _;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace EvonyStudio
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        private readonly Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        public override void Load()
        {
            // Plugin startup logic
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            Log.LogInfo($"Plugin ver is 1.0.0.2!");
            harmony.PatchAll();
            Log.LogWarning($"{_.Tool.GetIpandPort()}");
            System.Console.WriteLine($"Debug:{Tool.GetDebugOpen()}");
        }
    }
}
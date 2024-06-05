using MelonLoader;

namespace SelectionDetail
{
    public class Mod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            HarmonyLib.Harmony.CreateAndPatchAll(typeof(Hook));
        }
    }
}
using HarmonyLib;
using Monitor;
using Process;

namespace SelectionDetail
{
    public class Hook
    {
        private static Window window;
        public static MusicSelectProcess.MusicSelectData SelectData { get; private set; }
        public static int Difficulty { get; private set; }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MusicSelectMonitor), "UpdateRivalScore")]
        public static void ScrollUpdate(MusicSelectProcess ____musicSelect, MusicSelectMonitor __instance)
        {
            if (__instance != ____musicSelect.MonitorArray[0]) return;
            if (window != null)
            {
                window.Close();
            }

            if (____musicSelect.IsRandomIndex()) return;
            
            SelectData = ____musicSelect.GetMusic(0);
            if (SelectData == null) return;
            Difficulty = ____musicSelect.GetDifficulty(0);

            window = __instance.gameObject.AddComponent<Window>();
        }
    }
}
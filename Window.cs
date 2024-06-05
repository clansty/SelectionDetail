using Manager.MaiStudio;
using UnityEngine;
using UrGUI.GUIWindow;

namespace SelectionDetail
{
    public class Window : UnityEngine.MonoBehaviour
    {
        private GUIWindow window;

        private void Start()
        {
            window = GUIWindow.Begin("歌曲信息", Screen.width / 2f - 100, Screen.height * 0.87f, 200, 50, 10, 22, 5, true, true, true);
            window.Label(Hook.SelectData.MusicData.genreName?.str);
            window.Label(Hook.SelectData.MusicData.AddVersion?.str);
            window.Label($"{Hook.SelectData.MusicData.notesData[Hook.Difficulty]?.level}.{Hook.SelectData.MusicData.notesData[Hook.Difficulty]?.levelDecimal}");
        }

        private void OnGUI()
        {
            window.Draw();
        }

        public void Close()
        {
            Destroy(this);
        }
    }
}
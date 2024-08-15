using System.Linq;
using MAI2.Util;
using Manager;
using Manager.MaiStudio;
using Manager.UserDatas;
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
            window.Label($"ID: {Hook.SelectData.MusicData.name.id}");
            window.Label(Hook.SelectData.MusicData.genreName?.str);
            window.Label(Hook.SelectData.MusicData.AddVersion?.str);
            window.Label($"{Hook.SelectData.MusicData.notesData[Hook.Difficulty]?.level}.{Hook.SelectData.MusicData.notesData[Hook.Difficulty]?.levelDecimal}");

            var rate = CalcB50(Hook.SelectData.MusicData);
            if (rate > 0)
            {
                window.Label($"打到 SSS+ 可提 {rate} 分");
            }
        }

        private uint CalcB50(MusicData musicData)
        {
            var newRate = new UserRate(musicData.name.id, Hook.Difficulty, 1010000, (uint)musicData.version);
            var user = Singleton<UserDataManager>.Instance.GetUserData(0);
            var userLowRate = (newRate.OldFlag ? user.RatingList.RatingList : user.RatingList.NewRatingList).Last();

            if (newRate.SingleRate > userLowRate.SingleRate)
            {
                return newRate.SingleRate - userLowRate.SingleRate;
            }

            return 0;
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

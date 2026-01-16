using UnityEngine;
using Dotmob.LifeSystem;
using EasyUI.Toast;
public class UILevelBallButtonEvent : MonoBehaviour
{
	public void OnPressLevelBallButton()
	{
		MonoSingleton<PopupCommonYesNo>.Instance.CheckInternetNow((hasInternet) =>
		{
            if (hasInternet)
            {
				int result = 1;
				if (int.TryParse(base.gameObject.name, out result) && result <= MonoSingleton<PlayerDataManager>.Instance.CurrentLevelNo)
				{
					if (LifeHandler.Instance.CanPlay())
					{
						MapData.main = new MapData(result);
						MonoSingleton<PlayerDataManager>.Instance.lastPlayedLevel = result;
						SoundSFX.Play(SFXIndex.ButtonClick);
						MonoSingleton<SceneControlManager>.Instance.LoadScene(SceneType.Game, SceneChangeEffect.Color);
						GameMain.CompleteGameStart();
					}
					else
					{
						MonoSingleton<PopupManager>.Instance.Open(PopupType.PopupCommonInfo);
					}


				}
			}
		});
	
        
	}
}

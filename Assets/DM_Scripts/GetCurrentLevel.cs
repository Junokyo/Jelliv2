
/*
 * Created on 2025
 *
 * Copyright (c) 2025 Dotmob Games
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gley.Localization;
using Dotmob.LifeSystem;
using EasyUI.Toast;
public class GetCurrentLevel : MonoSingleton<GetCurrentLevel>
{

    public Text CurrentLevel;

    public void refreshText()
    {
        if(CurrentLevel != null)
        {
            CurrentLevel.text = API.GetText(WordIDs.Menu_Level) + " " + MonoSingleton<PlayerDataManager>.Instance.CurrentLevelNo;
        }
        
    }

    private void Start()
    {
        if (CurrentLevel != null)
        {
            CurrentLevel.text = API.GetText(WordIDs.Menu_Level) + " " + MonoSingleton<PlayerDataManager>.Instance.CurrentLevelNo;
        }

    }

    public void OnPressAllLevel()
    {
        // SoundSFX.Play(SFXIndex.ButtonClick);
        if (LifeHandler.Instance.CanPlay())
        {
            MonoSingleton<GameDataLoadManager>.Instance.MoveToLobbyScene();
          //  MonoSingleton<PopupCommonYesNo>.Instance.CheckInternetNow();
        }
        else
        {
            MonoSingleton<PopupManager>.Instance.Open(PopupType.PopupCommonInfo);
          //  Toast.Show("Dont have live", ToastColor.Black, ToastPosition.MiddleCenter);

        }
    }

 
}

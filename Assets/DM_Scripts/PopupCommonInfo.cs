

/*
 * Created on 2025
 *
 * Copyright (c) 2025 DotmobStudio
 * Support : dotmobstudio@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;
using Gley.MobileAds;
using Dotmob.LifeSystem;
using EasyUI.Toast;
public class PopupCommonInfo : PopupCommon
{
    int priceLive = 100;

    public void OnClickWatchAdsToRefill()
    {
        if (API.IsRewardedVideoAvailable())
        {
            API.ShowRewardedVideo((s) =>
            {
                LifeHandler.Instance.AddLife();
                base.OnEventClose();
            });
        }
        else
        {
            Toast.Show("Video Ads not working!", ToastColor.Black, ToastPosition.MiddleCenter);
        }
    }


    public void OnClickCoinButton()
    {
        if(MonoSingleton<PlayerDataManager>.Instance.Coin >= priceLive)
        {
            MonoSingleton<PlayerDataManager>.Instance.DecreaseCoin(priceLive);

            LifeHandler.Instance.RefillLife();
            base.OnEventClose();
        }
        else
        {
            MonoSingleton<PopupManager>.Instance.OpenPopupShopCoin();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Gley.MobileAds;

public class AdManager : MonoBehaviour
{

    private void Start()
    {
        API.Initialize(OnInitialized);

    }

    private void OnInitialized()
    {
        // API.ShowBanner(BannerPosition.Bottom, BannerType.Adaptive); // Disabled banner ads

        if (!API.GDPRConsentWasSet())
        {
            API.ShowBuiltInConsentPopup(PopupCloseds);
        }
    }

    private void PopupCloseds()
    {

    }

    private void OnApplicationPause(bool pause)
    {
        if (pause == false)
        {
            API.ShowAppOpen();
        }
    }
}

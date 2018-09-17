using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InitAdMob : MonoBehaviour {

    public bool isAdMobInitialized;

    public void Start()
    {
        if (!isAdMobInitialized)
        {
#if UNITY_ANDROID
            string appId = "ca-app-pub-4472054890564612~9408933086";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-4472054890564612~9408933086";
#else
        string appId = "unexpected_platform";
#endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);

            MobileAds.SetiOSAppPauseOnBackground(true);

            isAdMobInitialized = true;
        }
    }
}

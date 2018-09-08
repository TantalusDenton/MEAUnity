using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InitAdMob : MonoBehaviour {

    private BannerView bannerView;
 
    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-4472054890564612~9408933086";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
    }
}

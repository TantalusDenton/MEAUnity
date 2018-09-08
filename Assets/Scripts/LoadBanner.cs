using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class LoadBanner : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        showBannerAd();
    }

    private void showBannerAd()
    {
        string adID = "ca-app-pub-3940256099942544/6300978111"; //prod id: "ca-app-pub-4472054890564612/1709039488";

        //***For Testing in the Device***
        /*AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
       .Build();*/

        //***For Production When Submit App***
        AdRequest request = new AdRequest.Builder().Build();

        BannerView bannerAd = new BannerView(adID, AdSize.SmartBanner, AdPosition.Top);
        bannerAd.LoadAd(request);
    }

}
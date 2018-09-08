using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class LoadInterstitial : MonoBehaviour
{
    //private InterstitialAd interstitial =new InterstitialAd(adUnitId);
    private bool RequestComplete = false;
    private bool AdShown = false;

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        InterstitialAd interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }

    }

    /*public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }*/

    public void Start()
    {
        RequestInterstitial();
        //ShowInterstitial();
    }

}

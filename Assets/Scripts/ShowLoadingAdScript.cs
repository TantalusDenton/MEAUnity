using System;
using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class ShowLoadingAdScript : MonoBehaviour
{
    private InterstitialAd interstitial;
    private float deltaTime = 0.0f;
    private static string outputMessage = string.Empty;

    public static string OutputMessage
    {
        set { outputMessage = value; }
    }

    public void Start()
    {

#if UNITY_ANDROID
        string appId = "ca-app-pub-4472054890564612~9408933086";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-4472054890564612~9408933086";
#else
        string appId = "unexpected_platform";
#endif

        MobileAds.SetiOSAppPauseOnBackground(true);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestInterstitial();
    }

    public void Update()
    {
        // Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
        // value.
        this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.1f;
    }

    public void ShowFullscreenAd()
    {
        ShowInterstitial();
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("353626073217213")
            .AddKeyword("game")
            .SetGender(Gender.Male)
            .SetBirthday(new DateTime(1991, 1, 1))
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }
    
    private void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4472054890564612/5905866680";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4472054890564612/5905866680";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    private void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            LoadSceneManager.GoToNewbie();
        }
        else
        {
            MonoBehaviour.print("Interstitial is not ready yet");
        }
    }
    
    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        ShowInterstitial();
        //LoadSceneManager.GoToNewbie();
        MonoBehaviour.print("HandleInterstitialLoaded event received");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        Debug.Log("Ad closed, destroying");
        interstitial.Destroy();
        MonoBehaviour.print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLeftApplication event received");
    }

    #endregion
    
}

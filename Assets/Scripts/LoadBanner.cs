using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class LoadBanner : MonoBehaviour {

    private BannerView bannerView;

    public bool isBannerLoaded;

    // Use this for initialization
    void Start()
    {
        this.RequestBanner();

    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4472054890564612/1709039488";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-4472054890564612/1709039488";
#else
            string adUnitId = "unexpected_platform";
#endif
        if (!isBannerLoaded)
        {
            bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

            // Called when the user returned from the app after an ad click.
            bannerView.OnAdClosed += HandleOnAdClosed;

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder()
                .Build();

            // Load the banner with the request.
            bannerView.LoadAd(request);

            isBannerLoaded = true;
            
            SceneManager.LoadScene(1);
        }
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //bannerView.Destroy();
    }
}
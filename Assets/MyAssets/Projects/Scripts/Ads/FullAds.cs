using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using GoogleMobileAds.Api;

public class FullAds : MonoBehaviour
{
    bool is_close_interstitial = false;
    private InterstitialAd interstitial;

    void Start()
    {
#if UNITY_ANDROID

        string appId = "ca-app-pub-8228022567048160~7058941837";
        //string appId = "ca-app-pub-3940256099942544~3347517113";
#elif UNITY_IPHONE
                 string appId = "あなたのiOS アプリID";
#else
                 string appId = "unexpected_platform";
#endif

        //コメントアウトしても良い
        MobileAds.Initialize(appId);
        RequestInterstitial();
    }
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8228022567048160/3787579534";//real

#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // string adUnitId = "ca-app-pub-3940256099942544/1033173712";//test

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        string testdeviceid = "33BE2250B43518CCDA7DE426D04EE232";
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);


    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        interstitial.Destroy();
        RequestInterstitial();

    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void ShowAds()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();//広告表示
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
// android:value="@integer/google_play_services_version"

public class BannerAd : MonoBehaviour
{

#if UNITY_ANDROID
    string adUnitId = "ca-app-pub-8228022567048160/3265669506";//real

#elif UNITY_IPHONE
                string adUnitId = "あなたのiOS バナーユニットID";
#else
    string adUnitId = "unexpected_platform";
#endif

    // 
    // string adUnitId = "ca-app-pub-3940256099942544/6300978111";//test
    private BannerView bannerView;
    private BannerView topbannerview;
    public bool hide = false;
    public bool show = false;
    void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-8228022567048160~7058941837";
        // string appId = "ca-app-pub-3940256099942544~3347517113";
#elif UNITY_IPHONE
                 string appId = "あなたのiOS アプリID";
#else
                 string appId = "unexpected_platform";
#endif


        //コメントアウトしても良い
        MobileAds.Initialize(appId);


        RequestBanner();
        if (hide)
        {
            hidebanner();
            hide = false;
        }
        if (show)
        {
            showbanner();
            show = false;
        }

    }

    void Update()
    {
        if (hide)
        {
            hidebanner();
            hide = false;
        }
        if (show)
        {
            showbanner();
            show = false;
        }
    }

    AdRequest request;
    private void RequestBanner()
    {
        string testdeviceid = "33BE2250B43518CCDA7DE426D04EE232";
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this);
        if (hide)
        {
            hidebanner();
            hide = false;
        }
    }
    /*void TopBanner()
    {
        topbannerview = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
    }*/
    private void hidebanner()
    {
        Debug.Log("hide");
        if (bannerView != null)
            bannerView.Hide();
    }
    private void showbanner()
    {
        Debug.Log("show");
        bannerView.Show();
    }
}

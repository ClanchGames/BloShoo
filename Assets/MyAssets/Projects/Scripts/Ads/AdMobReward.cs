using System;
using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;

public class AdMobReward : MonoBehaviour
{

    // private string adUnitId = "ca-app-pub-3940256099942544/5224354917";//test
    private string adUnitId = "ca-app-pub-8228022567048160/1161416193";//real
    private AdRequest adRequest;
    private RewardBasedVideoAd rewardBasedVideo;
    private Action rewardedHandler;
    private static bool rewardBasedEventHandlersSet = false;

    static public AdMobReward instance;
    public Game game;
    public GameObject ContinueScreen;
    bool channtomita = false;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-8228022567048160~70589418373";
        //string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        this.RequestRewardBasedVideo();
    }
    void Update()
    {

    }

    private void RequestRewardBasedVideo()
    {
        string testdeviceid = "33BE2250B43518CCDA7DE426D04EE232";
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Create an empty ad request.
        adRequest = new AdRequest.Builder().Build();

        // Reward based video instance is a singleton. Register handlers once to avoid duplicate events.
        if (!rewardBasedEventHandlersSet)
        {
            rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;          // ad has been received.
            rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;    // ad has failed to load.
            rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;          // ad is opened.
            rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;         // ad has started playing.
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;        // ad has rewarded the user.
            rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;          // ad is closed.
            rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication; // ad is leaving the application.

            rewardBasedEventHandlersSet = true;
        }

        // Load
        rewardBasedVideo.LoadAd(adRequest, adUnitId);
    }


    public void Show(Action handler)
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardedHandler = handler;
            rewardBasedVideo.Show();
        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args) { }
    public void HandleRewardBasedVideoFailedToLoad(object sender, EventArgs args)
    {
        StartCoroutine(_waitConnectReward());
    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args) { }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args) { }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //RequestRewardBasedVideo();
        //報酬受け取り時の処理
        rewardedHandler();
        StartCoroutine(_waitConnectReward());
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        //動画を閉じたときに、次の動画を読み込む
        if (!rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.LoadAd(adRequest, adUnitId); // Load
        }
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    // ロードに失敗した場合、1秒待ってから再ロードをする
    IEnumerator _waitConnectReward()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            // 通信ができない場合は、リロードしない
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                RequestRewardBasedVideo();
                break;
            }


        }
    }

}







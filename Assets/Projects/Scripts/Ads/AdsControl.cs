using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsControl : MonoBehaviour
{
    public BannerAd bannerAd;
    public FullAds fullAds;
    public static int fulladscount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnEnable()
    {
        bannerAd.show = true;
        if (gameObject.name == "ScoreScreen" || gameObject.name == "ClearScreen")
        {
            showads();
        }
    }

    void showads()
    {
        fulladscount++;
        if (fulladscount == 3)
        {
            fullAds.ShowAds();
            fulladscount = 0;
        }

    }
}

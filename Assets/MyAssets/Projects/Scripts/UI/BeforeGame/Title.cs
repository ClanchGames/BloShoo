using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public BannerAd bannerAd;
    public GameObject GameArea;
    public GameObject Title_;
    public GameObject Load;
    public static bool restart = false;
    public static bool comehome = false;
    public GameObject demomovie;
    void Awake()
    {

        if (comehome)
        {
            demomovie.SetActive(true);
            bannerAd.show = true;
            comehome = false;
            Load.SetActive(false);
            GameObject BGM_Title = GameObject.Find("BGM_Title");
            AudioSource bgmtitle = BGM_Title.GetComponent<AudioSource>();
            bgmtitle.enabled = true;
        }



        if (restart)
        {
            demomovie.SetActive(false);
            bannerAd.hide = true;
            restart = false;
            GameArea.SetActive(true);
            Load.SetActive(false);
            Title_.SetActive(false);
            GameObject BGM_Normal = GameObject.Find("BGM_Normal");
            AudioSource bgmnormal = BGM_Normal.GetComponent<AudioSource>();
            bgmnormal.enabled = true;
        }


    }

    public void RestartGame()
    {
        restart = true;
        SceneManager.LoadScene("Game");

    }
    public void ComeHome()
    {
        comehome = true;
        SceneManager.LoadScene("Game");
    }

    public void OnClick()
    {
        demomovie.SetActive(false);
        bannerAd.hide = true;
        GameArea.SetActive(true);
        Title_.SetActive(false);
        ChangeBGM();
    }
    void ChangeBGM()
    {
        GameObject BGM_Title = GameObject.Find("BGM_Title");
        AudioSource bgmtitle = BGM_Title.GetComponent<AudioSource>();
        bgmtitle.enabled = false;

        GameObject BGM_Normal = GameObject.Find("BGM_Normal");
        AudioSource bgmnormal = BGM_Normal.GetComponent<AudioSource>();
        bgmnormal.enabled = true;
    }
}

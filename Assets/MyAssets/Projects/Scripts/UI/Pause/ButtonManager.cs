using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{

    public SE se;
    public Title title;
    public GameObject[] CheckBoard;
    public GameObject InputNameBoard;


    public GameObject PauseUI;

    public GameOver GameOver;
    public GameObject CheckBoard_;
    // 
    public GameObject ContinueScreen;
    public Game game;
    //
    public GameObject ScoreScreen;
    public GameObject RankingScreen;
    public InputField playerName;
    public GameObject SaveCheck;

    public GameObject ScoreCheckButton;
    public GameObject ScoreUI;
    public Text ScorePoint;
    public BannerAd bannerAd;
    public AdMobReward adMobReward;
    void Start()
    {

    }
    public void BackButton()
    {
        bannerAd.hide = true;
        Time.timeScale = 1f;
        CheckBoard_.SetActive(false);
        se.ButtonSE();
    }
    public void RetryButton()
    {
        PauseUI.SetActive(false);
        CheckBoard[0].SetActive(true);
        se.ButtonSE();

    }
    public void QuitButton()
    {
        CheckBoard[1].SetActive(true);
        PauseUI.SetActive(false);
        se.ButtonSE();
    }

    public void RetryYes()
    {
        bannerAd.hide = true;
        title.RestartGame();

    }


    public void RetryNo()
    {
        PauseUI.SetActive(true);
        CheckBoard[0].SetActive(false);
        se.ButtonSE();

    }
    public void HomeYes()
    {
        bannerAd.hide = true;
        Time.timeScale = 1f;
        title.ComeHome();

    }
    public void HomeNo()
    {
        PauseUI.SetActive(true);
        CheckBoard[1].SetActive(false);
        se.ButtonSE();
    }
    public void ContinueButton()
    {
        bannerAd.hide = true;
        Time.timeScale = 0.0f;

        /*Game Game = GameObject.Find("GameArea").GetComponent<Game>();
        Game.ContinueGame();*/
        AdMobReward.instance.Show(() =>
         {
             Game Game = GameObject.Find("GameArea").GetComponent<Game>();
             Game.ContinueGame();
         });
    }
    public void ContinueQuit()
    {
        ScoreScreen.SetActive(true);
        ContinueScreen.SetActive(false);
        se.ButtonSE();
    }

    public void ScoreCheck()
    {
        ScoreUI.SetActive(true);
        ScorePoint.text = game.score_.ToString();
        ScoreCheckButton.SetActive(false);
        se.ButtonSE();
    }

    /* public void CheckWorldRanking()
     {
         InputNameBoard.SetActive(true);
     }

     public void EndInputName()
     {
         QuickRanking.Instance.SaveRanking(playerName.text, game.score_);
         SaveCheck.SetActive(true);
         InputNameBoard.SetActive(false);

     }
     public void SaveCheckOK()
     {
         setRankingscreen();
     }
     void setRankingscreen()
     {
         SceneManager.LoadScene("WorldRanking");
     }*/
}

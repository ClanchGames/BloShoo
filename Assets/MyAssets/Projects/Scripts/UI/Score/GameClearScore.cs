using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearScore : MonoBehaviour
{
    public Game game;
    public BossTime bosstime;
    public Text BossBeatTime;
    public Text Bonus;
    public Text ScorePoint;

    int bosskilltime;
    public int scorepoint;
    int bonuspoint;
    int bestbonustime = 20;
    int bestbonuspoint = 100000;
    int ichibyouatarinopoint = 1000;
    //int worstbonustime = 180;
    //int worstbonuspoint = 0;

    void Start()
    {
        bosskilltime = (int)(bosstime.byou);
        if (bosskilltime <= bestbonustime)
            bosskilltime = bestbonustime;
        // if (bosskilltime >= worstbonustime)
        //   bosskilltime = worstbonustime;
        bonuspoint = bestbonuspoint - (bosskilltime - bestbonustime) * ichibyouatarinopoint;
        if (bonuspoint <= 0)
            bonuspoint = 0;

        scorepoint = bonuspoint + game.score_;

        BossBeatTime.text = bosstime.bossbeattime.text;
        Bonus.text = bonuspoint.ToString();
        ScorePoint.text = scorepoint.ToString();
    }

}

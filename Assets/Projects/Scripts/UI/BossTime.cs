using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTime : MonoBehaviour
{
    public bool isbossbattlestart = false;
    public float timeElapsed_BossBeatTime;
    public Game game;
    public Text bossbeattime;
    public float byou;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float shimohutaketa;
        float hunn;

        if (isbossbattlestart && !game.isBossDown)
        {
            timeElapsed_BossBeatTime += Time.deltaTime;

            byou = Mathf.Floor(timeElapsed_BossBeatTime);
            hunn = Mathf.Floor(byou / 60);
            shimohutaketa = byou - (hunn * 60);
            if (shimohutaketa <= 9)
                bossbeattime.text = hunn.ToString() + ":" + "0" + shimohutaketa.ToString();
            else if (shimohutaketa >= 10)
                bossbeattime.text = hunn.ToString() + ":" + shimohutaketa.ToString();
            if (timeElapsed_BossBeatTime >= 600)
                bossbeattime.text = "9:59";
        }
    }
}

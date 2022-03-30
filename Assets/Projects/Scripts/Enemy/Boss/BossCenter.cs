using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenter : MonoBehaviour
{

    public BossParts[] bossparts;
    public BossBackParts[] bossbackparts;





    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector3 pos = rectTransform.localPosition;




        transform.Translate(0, -1.5f, 0);

        if (pos.y <= 300)
        {
            GameObject BGM_Normal = GameObject.Find("BGM_Normal");
            AudioSource normalbgm = BGM_Normal.GetComponent<AudioSource>();
            normalbgm.enabled = false;
            transform.Translate(0, 1.5f, 0);
            Invoke("BossBattleStart", 2f);

        }


    }
    void BossBattleStart()
    {
        RotateStart();
        ChangeBGM();
        HitStart();
        BossAppear();
    }
    void RotateStart()
    {
        transform.Rotate(new Vector3(0, 0, 0.5f));
        ManageBossAttack managebossattack = GameObject.Find("BossAttack").GetComponent<ManageBossAttack>();
        managebossattack.enabled = true;

        GameObject.Find("Boss_back").transform.SetParent(GameObject.Find("Boss").transform);
    }
    void ChangeBGM()
    {


        GameObject BGM_Boss = GameObject.Find("BGM_Boss");
        AudioSource bossbgm = BGM_Boss.GetComponent<AudioSource>();
        bossbgm.enabled = true;
    }

    void HitStart()
    {
        bossparts[0].isHitStart = true;
        bossparts[1].isHitStart = true;
        bossparts[2].isHitStart = true;
        bossparts[3].isHitStart = true;

        bossbackparts[0].isHitStart = true;
        bossbackparts[1].isHitStart = true;
        bossbackparts[2].isHitStart = true;
        bossbackparts[3].isHitStart = true;
    }
    void BossAppear()
    {
        Game Game_ = GameObject.Find("GameArea").GetComponent<Game>();
        Game_.BossAppear = false;
    }
}

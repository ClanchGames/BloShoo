using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBM : MonoBehaviour
{
    public Core core;
    public bool isBossSetPosition = false;
    GameObject BossBack;
    RectTransform EnemyRect;
    AudioSource normalbgm;
    Rigidbody2D body;
    bool bossbattlestart = true;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRect = GameObject.Find("Enemy").GetComponent<RectTransform>();
        BossBack = GameObject.Find("BossBack");
        GameObject BGM_Normal = GameObject.Find("BGM_Normal");
        normalbgm = BGM_Normal.GetComponent<AudioSource>();
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas canvas = Canvas.GetComponent<Canvas>();
        body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, -1) * 100 * canvas.transform.localScale.x;
    }



    void FixedUpdate()
    {
        bool ok = false;
        RectTransform LBMoverRect = GetComponent<RectTransform>();
        Vector3 LBMoverpos = LBMoverRect.localPosition;
        if (LBMoverpos.y <= 160)
        {
            body.bodyType = RigidbodyType2D.Static;
            ok = true;
        }
        if (ok)//定位置についたので攻撃開始
        {

            BossBack.transform.SetParent(EnemyRect, false);
            RectTransform BossBackRect = BossBack.GetComponent<RectTransform>();
            BossBackRect.localPosition = new Vector3(0, 335, 0);

            normalbgm.enabled = false;
            if (bossbattlestart)
            {
                Invoke("BossBattleStart", 2f);
                bossbattlestart = false;
            }

        }
    }
    void BossBattleStart()
    {
        ChangeBGM();
        BossAppear();
    }

    void ChangeBGM()
    {
        GameObject BGM_Boss = GameObject.Find("BGM_Boss");
        AudioSource bossbgm = BGM_Boss.GetComponent<AudioSource>();
        bossbgm.enabled = true;
    }
    void BossAppear()
    {
        isBossSetPosition = true;
        ManageBossAttack managebossattack = GameObject.Find("BossAttack").GetComponent<ManageBossAttack>();
        managebossattack.enabled = true;

        Game Game_ = GameObject.Find("GameArea").GetComponent<Game>();
        Game_.BossAppear = false;
        Game_.SetBossHPBar();
        core.SetHPBar();
        BossTime bossTime = GameObject.Find("BossTime").GetComponent<BossTime>();
        bossTime.isbossbattlestart = true;
    }
}

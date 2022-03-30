using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBMover : MonoBehaviour
{


    public GameObject lastboss;
    public GameObject LBAttackPrefab;
    RectTransform EnemyRect;
    GameObject BossBack;
    AudioSource normalbgm;
    int AttackTimes = 3;
    float movespeed = 1f;
    float rotate = 45f;
    float rotatespeed = 1f;
    public bool isSetPosition = false;
    public bool isright = true;
    public bool isleft = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRect = GameObject.Find("Enemy").GetComponent<RectTransform>();
        BossBack = GameObject.Find("BossBack");
        GameObject BGM_Normal = GameObject.Find("BGM_Normal");
        normalbgm = BGM_Normal.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RectTransform LBMoverRect = GetComponent<RectTransform>();
        Vector3 LBMoverpos = LBMoverRect.localPosition;

        if (LBMoverpos.y > 75)
        {
            transform.Translate(0, -1.5f, 0);
        }
        else//定位置についたので攻撃開始
        {


            BossBack.transform.SetParent(EnemyRect, false);
            RectTransform BossBackRect = BossBack.GetComponent<RectTransform>();
            BossBackRect.localPosition = new Vector3(0, 335, 0);
            ManageBossAttack managebossattack = GameObject.Find("BossAttack").GetComponent<ManageBossAttack>();
            managebossattack.enabled = true;

            normalbgm.enabled = false;
            Invoke("BossBattleStart", 2f);
        }

    }
    void BossBattleStart()
    {
        MoveStart();
        ChangeBGM();
        BossAppear();
    }
    void MoveStart()
    {
        float AttackCount = 0;
        isSetPosition = true;
        RectTransform LBMoverRect = GetComponent<RectTransform>();
        Vector3 LBMoverpos = LBMoverRect.localPosition;

        if (isright)
        {

            if (LBMoverpos.x > 100)
            {

                if (lastboss.transform.localEulerAngles.z >= lastboss.transform.localEulerAngles.z - 90)
                {
                    isright = false;
                    Invoke("ChangeDirectionToLeft", 2f);
                    for (int i = 0; i < AttackTimes; i++)
                    {

                        Invoke("GenerateAttack", AttackCount);
                        AttackCount += 0.2f;
                    }
                    AttackCount = 0;
                }
                else
                {
                    Debug.Log("in");
                    Rotate();
                }
            }
            else
            {
                transform.Translate(movespeed, 0, 0);
            }
        }
        else if (isleft)
        {


            if (LBMoverpos.x < -100)
            {


                if (lastboss.transform.localEulerAngles.z <= lastboss.transform.localEulerAngles.z + 90)
                {
                    isleft = false;
                    Invoke("ChangeDirectionToRight", 2f);
                    for (int i = 0; i < AttackTimes; i++)
                    {

                        Invoke("GenerateAttack", AttackCount);
                        AttackCount += 0.2f;
                    }
                    AttackCount = 0;
                }
                else
                {

                    Rotate();
                }
            }
            else
            {
                transform.Translate(-movespeed, 0, 0);
            }
        }
    }

    void Rotate()
    {
        if (isright)
        {
            lastboss.transform.localEulerAngles = new Vector3(0, 0, rotate);
            rotate -= rotatespeed;
        }
        else if (isleft)
        {
            lastboss.transform.localEulerAngles = new Vector3(0, 0, rotate);
            rotate += rotatespeed;
        }
    }
    void ChangeBGM()
    {


        GameObject BGM_Boss = GameObject.Find("BGM_Boss");
        AudioSource bossbgm = BGM_Boss.GetComponent<AudioSource>();
        bossbgm.enabled = true;
    }
    void BossAppear()
    {
        ManageBossAttack managebossattack = GameObject.Find("BossAttack").GetComponent<ManageBossAttack>();
        managebossattack.enabled = true;

        Game Game_ = GameObject.Find("GameArea").GetComponent<Game>();
        Game_.BossAppear = false;
    }
    void GenerateAttack()
    {
        RectTransform LBMoverRect = GetComponent<RectTransform>();


        GameObject AttackClone = Instantiate(LBAttackPrefab);
        RectTransform AttackTransform = AttackClone.GetComponent<RectTransform>();
        AttackTransform.SetParent(LBMoverRect, false);
        AttackTransform.localPosition = new Vector3(5, -100, 0);

    }
    void ChangeDirectionToLeft()
    {
        isleft = true;

    }
    void ChangeDirectionToRight()
    {
        isright = true;

    }
}




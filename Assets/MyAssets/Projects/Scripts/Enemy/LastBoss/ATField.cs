using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ATField : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip ballhitsound;
    Material nowMaterial;
    public Material HitEffect;
    int hp = 100;
    ManageBossAttack managebossattack;
    LBCenter lbcenter;
    // Start is called before the first frame update
    void Start()
    {
        lbcenter = GameObject.Find("LastBoss").GetComponent<LBCenter>();
        managebossattack = GameObject.Find("BossAttack").GetComponent<ManageBossAttack>();
        audioSource = GetComponent<AudioSource>();
        nowMaterial = GetComponent<Image>().material;
    }


    void OnCollisionEnter2D(Collision2D collisionInfo)//ボールだけ食らう
    {
        if (collisionInfo.gameObject.layer == 8)
        {
            audioSource.PlayOneShot(ballhitsound);
            Ball ball = GameObject.Find("Ball").GetComponent<Ball>();
            LoseHP(ball.BallAttack);
        }
    }
    public void LoseHP(int attack)
    {
        hp -= attack;

        if (hp <= 0)
        {
            managebossattack.isbrokenbarrier = true;
            lbcenter.ModeRed = true;

            Destroy(gameObject);
        }
        else
        {
            HitEffectMethod();
            Invoke("ReturnMaterial", 0.05f);
        }

    }

    void HitEffectMethod()
    {
        gameObject.GetComponent<Image>().material = HitEffect;
    }
    void ReturnMaterial()
    {
        gameObject.GetComponent<Image>().material = nowMaterial;
    }
}


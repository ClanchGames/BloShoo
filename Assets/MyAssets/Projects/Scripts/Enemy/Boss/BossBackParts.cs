using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBackParts : MonoBehaviour
{
    public bool isHitStart = false;
    int life = 10;
    Material nowMaterial;
    public Material HitEffect;
    void Start()
    {
        nowMaterial = GetComponent<Image>().material;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isHitStart)
        {

            if (collision.gameObject.tag == "Ball")
            {
                Ball ball = GameObject.Find("Ball").GetComponent<Ball>();
                LoseHP(ball.BallAttack);
            }
            else if (collision.gameObject.tag == "Beam")
            {
                BeamManager beammanager = GameObject.Find("Beams").GetComponent<BeamManager>();
                LoseHP(beammanager.BeamAttack);
            }
        }
    }
    public void LoseHP(int attack)
    {
        if (isHitStart)
        {
            life -= attack;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                HitEffectMethod();
                Invoke("ReturnMaterial", 0.05f);
            }
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


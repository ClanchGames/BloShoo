using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    public AudioClip ballhitsound;
    public AudioClip beamhitsound;
    public GameObject ATField;

    AudioSource audioSource;
    int Hp = 200;
    int FirstHp;
    Material nowMaterial;
    public Material HitEffect;
    public LBM lbm;
    bool halfHp = false;
    Game game;
    GameObject BossHPBar;
    Slider bosshpbar;
    public bool sethpbar = false;
    // Start is called before the first frame update
    void Start()
    {
        FirstHp = Hp;
        audioSource = GetComponent<AudioSource>();
        nowMaterial = GetComponent<Image>().material;
        game = GameObject.Find("GameArea").GetComponent<Game>();

    }
    public void SetHPBar()
    {
        bosshpbar = GameObject.Find("BossHPBar").GetComponent<Slider>();
        bosshpbar.minValue = 0;
        bosshpbar.maxValue = Hp;
        bosshpbar.value = Hp;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (lbm.isBossSetPosition)
        {
            if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "BallCopy")
            {
                audioSource.PlayOneShot(ballhitsound);
                Ball ball = GameObject.Find("Ball").GetComponent<Ball>();
                LoseHP(ball.BallAttack);
            }
            else if (collision.gameObject.tag == "Beam")
            {
                audioSource.PlayOneShot(beamhitsound);
                BeamManager beammanager = GameObject.Find("Beams").GetComponent<BeamManager>();
                LoseHP(beammanager.BeamAttack);
            }
            if (!halfHp)
                if (Hp <= (FirstHp / 2))
                {

                    ATField.SetActive(true);
                    halfHp = true;
                }
        }
    }
    public void LoseHP(int attack)
    {
        Hp -= attack;
        bosshpbar.value = Hp;
        if (Hp <= 0)
        {
            game.isBossDown = true;
            Invoke("BossDestroy", 1f);
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
    void BossDestroy()
    {
        Destroy(lbm.gameObject);
    }
}

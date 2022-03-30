using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public Rigidbody2D ItemRigidbody;
    public GameObject ItemBox_;
    int hp = 5;
    public bool ItemOpen = false;
    Color color_;
    public bool HitStart = false;



    void Start()
    {
        ItemRigidbody.bodyType = RigidbodyType2D.Kinematic;
        color_ = ItemBox_.GetComponent<Image>().color;
        HitStart = false;

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (HitStart && !ItemOpen)
        {
            LoseHP(1);
        }

    }
    public void LoseHP(int attack)
    {
        hp -= attack;

        if (hp <= 0)
        {
            ItemRigidbody.bodyType = RigidbodyType2D.Dynamic;
            ItemOpen = true;
            HitStart = false;
            Destroy(gameObject);
        }
        else
        {

            HitEffectMethod();
            Invoke("ReturnMaterial", 0.1f);
        }

    }
    void HitEffectMethod()
    {

        ItemBox_.GetComponent<Image>().color = Color.white;


    }
    void ReturnMaterial()
    {

        ItemBox_.GetComponent<Image>().color = color_;

    }
}

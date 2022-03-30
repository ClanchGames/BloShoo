using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{

    public Sprite[] BlockColor;
    public Sprite[] BlockHibi;
    //public AudioClip hitsound;
    AudioSource audioSource;
    int hp_ = 2;
    int color;
    int BlockScore = 1000;
    Material nowMaterial;
    public Material HitEffect;

    private void Start()
    {
        nowMaterial = GetComponent<Image>().material;

        int colornumger = Random.Range(0, 3);
        color = colornumger;
        GetComponent<Image>().sprite = BlockColor[colornumger];
        gameObject.name = "Block" + colornumger;
        audioSource = GetComponent<AudioSource>();
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas canvas = Canvas.GetComponent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, -1) * 100 * canvas.transform.localScale.x;
    }


    /*  void ChooseColor()
      {
          int colornumber = Random.Range(0, 6);
          if (colornumber == 0)
          {
              GetComponent<Image>().color = Color.cyan;
          }
          else if (colornumber == 1)
          {
              GetComponent<Image>().color = Color.green;
          }
          else if (colornumber == 2)
          {
              GetComponent<Image>().color = Color.red;
          }
          else if (colornumber == 3)
          {
              GetComponent<Image>().color = Color.white;
          }
          else if (colornumber == 4)
          {
              GetComponent<Image>().color = Color.yellow;
          }
          else if (colornumber == 5)
          {
              GetComponent<Image>().color = Color.gray;
          }
      }*/


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Game game = GetComponentInParent<Game>();
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 13)
        {
            if (collision.gameObject.layer == 8)
            {
                hp_ = 0;
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.parent.position);
            }
            else
            {
                hp_--;
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.parent.position);
            }

            if (hp_ <= 0)
            {
                game.CreateItemAtRandom(transform.position);
                game.AddScore(BlockScore);
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Image>().sprite = BlockHibi[color];
                HitEffectMethod();
                Invoke("ReturnMaterial", 0.1f);

            }

        }
        else
        {
            Destroy(gameObject);
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

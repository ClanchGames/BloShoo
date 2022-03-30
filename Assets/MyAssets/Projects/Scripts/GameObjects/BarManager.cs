using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public AudioClip ItemGetSound;
    public bool isAddBar = false;
    AudioSource audioSource;
    public Game game;
    GameObject scoretext;
    int destroyblockscore = 500;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)//アイテム取ったとき
        {
            audioSource.PlayOneShot(ItemGetSound);
        }
        if (isAddBar)
        {
            if (collision.gameObject.layer == 9)
            {
                game.AddScore(destroyblockscore);
            }
        }
        if (collision.gameObject.tag == "ScoreItem")
        {
            scoretext = GameObject.Find("ScoreOpen");
            scoretext.GetComponent<Text>().enabled = true;
            Invoke("closescoretext", 1f);
        }
    }
    void closescoretext()
    {
        scoretext.GetComponent<Text>().enabled = false;
    }

}

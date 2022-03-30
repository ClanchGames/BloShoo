using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Field : MonoBehaviour
{
    public GameObject ScoreScreen;
    public GameObject ContinueScreen;
    Game game;
    void Start()
    {
        game = GetComponentInParent<Game>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 11)
            Destroy(collision.gameObject);
        else if (collision.gameObject.tag == "BallCopy")
        { }
        else
        {



            if (game.ContinueTimes == 0)
            {
                if (collision.gameObject.tag != "Ball" && collision.gameObject.tag != "BallCopy")
                    Destroy(collision.gameObject);
                Time.timeScale = 0.0f;
                ContinueScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 0.0f;
                Destroy(collision.gameObject);
                ScoreScreen.SetActive(true);
            }


        }

    }
}



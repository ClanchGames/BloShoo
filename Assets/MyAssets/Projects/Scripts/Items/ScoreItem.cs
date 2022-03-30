using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreItem : MonoBehaviour
{
    private int ScoreItemPoint = 5000;
    GameObject scoretext;

    void Start()
    {

        Canvas canvas = GetComponentInParent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, -1) * 400 * canvas.transform.localScale.x;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Game game = GetComponentInParent<Game>();
            game.AddScore(ScoreItemPoint);

        }



        Destroy(gameObject);

    }

}

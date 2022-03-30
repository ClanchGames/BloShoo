using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    Game game;
    private void FixedUpdate()
    {

        /* if (game.isContinue)
         {

             gameObject.SetActive(true);
         }*/
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        game = GetComponentInParent<Game>();

        if (collision.gameObject.tag != "BallCopy")
        {

            game.life_--;
            gameObject.SetActive(false);


            if (collision.gameObject.layer == 8)
            {


                Ball ball = collision.gameObject.GetComponent<Ball>();
                ball.Reset();
            }
        }
        else if (collision.gameObject.tag == "BallCopy")
        { }
        else
            Destroy(collision.gameObject);
    }


}

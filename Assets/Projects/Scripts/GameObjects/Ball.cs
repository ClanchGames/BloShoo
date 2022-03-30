using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameObject GameArea;
    Game game;
    private float speed_;
    public int BallAttack = 15;
    float firstspeed = 450;
    float ballzurashi = 50f;

    Rigidbody2D body;
    Canvas canvas;
    Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        canvas = GetComponentInParent<Canvas>();
        GameArea = GameObject.Find("GameArea");
        game = GameArea.GetComponent<Game>();
        startpos = transform.position;


        Reset();


    }
    private void FixedUpdate()
    {


        float xvelo = body.velocity.x;
        float yvelo = body.velocity.y;
        //Debug.Log("xvelo" + xvelo);
        //Debug.Log("yvelo" + yvelo);
        if (xvelo < 0 && yvelo < 0)
        {

            xvelo = -speed_;
            yvelo = -speed_;
            body.velocity = new Vector3(xvelo, yvelo, 0);


        }
        else if (xvelo >= 0 && yvelo < 0)
        {
            xvelo = speed_;
            yvelo = -speed_;
            body.velocity = new Vector3(xvelo, yvelo, 0);
        }
        else if (xvelo < 0 && yvelo >= 0)
        {
            xvelo = -speed_;
            yvelo = speed_;
            body.velocity = new Vector3(xvelo, yvelo, 0);
        }
        else if (xvelo >= 0 && yvelo >= 0)
        {
            xvelo = speed_;
            yvelo = speed_;
            body.velocity = new Vector3(xvelo, yvelo, 0);
        }

        if (game.BossAppear || game.ItemAppear || game.isBossDown)
        {
            Reset();
        }





    }


    public void Reset()
    {


        if (gameObject.name == "BlueBall")
        {
            transform.localPosition = new Vector2(50, -250);
            /*   speed_ = 500 * canvas.transform.localScale.x;
               var direction = new Vector3(-1, 1).normalized;
               body.velocity = direction * speed_;*/
        }
        else if (gameObject.name == "GreenBall")
        {

            transform.localPosition = new Vector2(-50, -250);

            /* speed_ = 500 * canvas.transform.localScale.x;
             var direction = new Vector3(-1, 1).normalized;
             body.velocity = direction * speed_;*/

        }
        else if (gameObject.name == "YellowBall")
        {

            transform.localPosition = new Vector2(0, -200);

            /* speed_ = 500 * canvas.transform.localScale.x;
             var direction = new Vector3(-1, 1).normalized;
             body.velocity = direction * speed_;*/
        }
        else
        {

            transform.position = startpos;

        }

        //float random = Random.Range(0.5f, 2);

        speed_ = firstspeed * canvas.transform.localScale.x;
        var direction = new Vector3(1, 1).normalized;
        body.velocity = direction * speed_;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "BallCopy")
        {
            if (collision.gameObject.name == "bottom" || collision.gameObject.layer == 14)
                Reset();
        }
        else if (collision.gameObject.layer == 18)
        {
            Reset();
        }

    }





    private void UpdateVelocity()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        Canvas canvas = GetComponentInParent<Canvas>();



    }






    public void AddSpeed(float addition)
    {

        UpdateVelocity();
    }





}

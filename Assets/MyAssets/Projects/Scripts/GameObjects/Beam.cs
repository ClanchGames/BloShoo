using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{





    // Start is called before the first frame update
    void Start()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas canvas = Canvas.GetComponent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "RightBeam")
            //body.velocity = new Vector2(1, 1) * 600 * canvas.transform.localScale.x;
            body.velocity = new Vector2(0, 1) * 600 * canvas.transform.localScale.x;
        else if (gameObject.tag == "LeftBeam")
            body.velocity = new Vector2(0, 1) * 600 * canvas.transform.localScale.x;
        // body.velocity = new Vector2(-1, 1) * 600 * canvas.transform.localScale.x;
        else
            body.velocity = new Vector2(0, 1) * 600 * canvas.transform.localScale.x;



    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}

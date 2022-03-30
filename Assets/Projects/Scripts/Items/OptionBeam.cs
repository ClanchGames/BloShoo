using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBeam : MonoBehaviour
{
    string name;
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        name = transform.parent.gameObject.name;
        if (name == "Option")
        {
            if (gameObject.name == "OptionC")
                //body.velocity = new Vector2(1, 1) * 600 * canvas.transform.localScale.x;
                body.velocity = new Vector2(0, 1) * 600 * canvas.transform.localScale.x;
            else if (gameObject.name == "OptionR")
                body.velocity = new Vector2(0.3f, 1) * 600 * canvas.transform.localScale.x;
            // body.velocity = new Vector2(-1, 1) * 600 * canvas.transform.localScale.x;
            else if (gameObject.name == "OptionL")
                body.velocity = new Vector2(-0.3f, 1) * 600 * canvas.transform.localScale.x;
        }
        if (name == "RightOption")
        {
            if (gameObject.name == "OptionC")
                //body.velocity = new Vector2(1, 1) * 600 * canvas.transform.localScale.x;
                body.velocity = new Vector2(-0.6f, 1f) * 600 * canvas.transform.localScale.x;
            else if (gameObject.name == "OptionR")
                body.velocity = new Vector2(0, 1) * 600 * canvas.transform.localScale.x;
            // body.velocity = new Vector2(-1, 1) * 600 * canvas.transform.localScale.x;
            else if (gameObject.name == "OptionL")
                body.velocity = new Vector2(-1, 0.5f) * 600 * canvas.transform.localScale.x;
        }
        if (name == "LeftOption")
        {
            if (gameObject.name == "OptionC")
                //body.velocity = new Vector2(1, 1) * 600 * canvas.transform.localScale.x;
                body.velocity = new Vector2(0.6f, 1f) * 600 * canvas.transform.localScale.x;
            else if (gameObject.name == "OptionR")
                body.velocity = new Vector2(1, 0.5f) * 600 * canvas.transform.localScale.x;
            // body.velocity = new Vector2(-1, 1) * 600 * canvas.transform.localScale.x;
            else if (gameObject.name == "OptionL")
                body.velocity = new Vector2(0, 1) * 600 * canvas.transform.localScale.x;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneupItem : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, -1) * 200 * canvas.transform.localScale.x;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bar")
        {
            Game game = GetComponentInParent<Game>();
            game.RecoverHPBar();
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}


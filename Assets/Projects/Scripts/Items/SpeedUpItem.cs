using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{

    public float speedupnumber=100;
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas =GetComponentInParent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, -1) * 200 * canvas.transform.localScale.x;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.AddSpeed(speedupnumber);
        Destroy(gameObject);
    }
    // Update is called once per frame
    
    
}

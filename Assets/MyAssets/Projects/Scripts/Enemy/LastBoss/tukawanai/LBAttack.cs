using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBAttack : MonoBehaviour
{

    float AttackDownSpeed = 600;
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, -1) * AttackDownSpeed * canvas.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

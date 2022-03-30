using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    AudioSource audioSource;
    public int BossAttackDamage = 1;
    public float AttackDownSpeed = 500;

    public float LBAttackDownSpeed = 700;
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameArea").GetComponent<Game>();
        audioSource = GetComponent<AudioSource>();

        Canvas canvas = GetComponentInParent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "LastBossAttack")
            body.velocity = new Vector2(0, -1) * LBAttackDownSpeed * canvas.transform.localScale.x;
        else
            body.velocity = new Vector2(0, -1) * AttackDownSpeed * canvas.transform.localScale.x;
    }
    void FixedUpdate()
    {
        if (game.isBossDown)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "BallCopy" || collision.gameObject.tag == "Beam" || collision.gameObject.tag == "Bar")
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.parent.position);
        }
        Destroy(gameObject);


    }
}

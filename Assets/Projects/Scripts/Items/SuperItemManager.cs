using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperItemManager : MonoBehaviour
{
    public ItemBox itemBox;

    private float ItemDisappear = 20f;
    // private float ItemDisapperCount;

    public bool isItemDisapear = false;
    // Start is called before the first frame update
    void Start()
    {

        GameObject GameArea = GameObject.Find("GameArea");
        Game game = GameArea.GetComponent<Game>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (itemBox.ItemOpen)
        {
            MoveStart();

        }
        if (itemBox.ItemOpen)
        {
            GameObject SuperItem = GameObject.Find("SuperItemArea");
            RectTransform SuperItemRect = SuperItem.GetComponent<RectTransform>();
            gameObject.transform.SetParent(SuperItemRect, true);

            var clones = GameObject.FindGameObjectsWithTag("SuperItem");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
        }

    }
    void MoveStart()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, -1) * 400 * canvas.transform.localScale.x;
        itemBox.ItemOpen = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Game game = GetComponentInParent<Game>();
        if (collision.gameObject.layer == 10)//バーに当たった時
        {


            if (gameObject.name == "BlueBall")
            {
                game.AddBall(0);

            }
            else if (gameObject.name == "GreenBall")
            {
                game.AddBall(1);
            }
            else if (gameObject.name == "YellowBall")
            {
                game.AddBall(2);
            }
            else if (gameObject.name == "GrayBar")
            {

                game.AddBar();
            }
            else if (gameObject.name == "BeamItem")
            {
                game.AddBeam();
            }
            else if (gameObject.name == "SideBeam")
            {
                game.StartSideBeam();
            }
            else if (gameObject.name == "Option")
            {
                game.AddOption(4);
            }
            else if (gameObject.name == "RightOption")
            {
                game.AddOption(5);
            }
            else if (gameObject.name == "LeftOption")
            {
                game.AddOption(6);
            }


        }

        Destroy(gameObject);
        game.ItemAppear = false;

    }

}

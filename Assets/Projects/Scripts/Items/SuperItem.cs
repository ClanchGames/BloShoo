using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperItem : MonoBehaviour
{

    public Rigidbody2D ItemRigidbody;
    public ItemBox itemBox;
    Rigidbody2D body;


    void Start()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas canvas = Canvas.GetComponent<Canvas>();
        body = GetComponent<Rigidbody2D>();

        if (gameObject.name == "SuperItem1")
        {
            body.velocity = new Vector2(1, 0) * 200 * canvas.transform.localScale.x;
        }
        else if (gameObject.name == "SuperItem2")
        {
            body.velocity = new Vector2(-1, 0) * 200 * canvas.transform.localScale.x;
        }
    }
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector3 pos = rectTransform.localPosition;

        if (!itemBox.ItemOpen)
        {

            if (gameObject.name == "SuperItem1")
            {
                if (pos.x >= -130)
                {
                    itemBox.HitStart = true;
                    body.bodyType = RigidbodyType2D.Static;
                }

            }
            else if (gameObject.name == "SuperItem2")
            {

                if (pos.x <= 130)
                {
                    itemBox.HitStart = true;
                    body.bodyType = RigidbodyType2D.Static;
                }


            }

        }


    }



}

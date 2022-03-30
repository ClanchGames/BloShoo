using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public RectTransform bgrect;
    Vector3 toppos;
    Vector3 bottompos;
    public GameObject[] background;
    RectTransform bg0rect;
    RectTransform bg1rect;
    Vector3 direction = new Vector3(0f, -960f, 10f);
    float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject bg0 = Instantiate(background[0]);
        bg0rect = bg0.GetComponent<RectTransform>();
        bg0rect.SetParent(bgrect, false);
        bg0rect.localPosition = new Vector3(0, 960, 0);

        GameObject bg1 = Instantiate(background[1]);
        bg1rect = bg1.GetComponent<RectTransform>();
        bg1rect.SetParent(bgrect, false);
        bg1rect.localPosition = new Vector3(0, 0, 0);
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        bg0rect.localPosition = Vector3.MoveTowards(bg0rect.localPosition, direction, step);
        bg1rect.localPosition = Vector3.MoveTowards(bg1rect.localPosition, direction, step);
        if (bg0rect.localPosition.y <= -960)
        {
            setpos(bg0rect);
        }
        if (bg1rect.localPosition.y <= -960)
        {
            setpos(bg1rect);
        }
    }
    void setpos(RectTransform rect)
    {
        rect.localPosition = new Vector3(0, 960, 0);
    }
}


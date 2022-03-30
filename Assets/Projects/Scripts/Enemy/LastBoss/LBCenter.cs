using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LBCenter : MonoBehaviour
{
    float timeset;
    float rotatechangetime = 10f;
    public LBM lbm;
    float rotatespeed = -1.2f;
    public bool ModeRed = false;
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameArea").GetComponent<Game>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!game.isBossDown)
        {


            if (lbm.isBossSetPosition)
            {
                timeset += Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, rotatespeed));
            }
            if (ModeRed)
            {
                rotatespeed = 1.5f;
                GetComponent<Image>().color = Color.red;
                ModeRed = false;
            }
            if (lbm.isBossSetPosition || ModeRed)
                if (timeset >= rotatechangetime)
                {
                    rotatespeed *= -1;
                    timeset = 0.0f;
                }
        }
    }



}


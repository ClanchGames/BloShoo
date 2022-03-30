using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapToStart : MonoBehaviour
{
    private float nextTime;
    public float interval = 0.3f;   // 点滅周期
    Text text;
    // Use this for initialization
    void Start()
    {

        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1.0f;
        nextTime += Time.deltaTime;

        if (nextTime >= interval)
        {
            text.enabled = !text.enabled;

            nextTime = 0.0f;
        }
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueRestart : MonoBehaviour
{

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void continuerestart()
    {
        text.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;


    // Update is called once per frame

    public void OnClick()
    {

        //　ポーズUIのアクティブ、非アクティブを切り替え
        pauseUI.SetActive(!pauseUI.activeSelf);


        //　ポーズUIが表示されてる時は停止
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
            //　ポーズUIが表示されてなければ通常通り進行
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Sliderを使用するために必要

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{

    public AudioSource[] bgm;

    public Slider m_Slider;



    void Start()
    {
        m_Slider.GetComponent<Slider>().normalizedValue = bgm[0].volume;
        m_Slider.GetComponent<Slider>().normalizedValue = bgm[1].volume;
        m_Slider.GetComponent<Slider>().normalizedValue = bgm[2].volume;
    }

    void Update()
    {
        bgm[0].volume = m_Slider.GetComponent<Slider>().normalizedValue;
        bgm[1].volume = m_Slider.GetComponent<Slider>().normalizedValue;
        bgm[2].volume = m_Slider.GetComponent<Slider>().normalizedValue;
    }
}



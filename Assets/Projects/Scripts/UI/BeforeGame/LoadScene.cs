using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    public GameObject Title;
    public GameObject tips;
    public Text loadtext;
    public GameObject titlescreen;
    public GameObject DemoMovie;
    public GameObject HighScore;
    Image image;



    void Start()
    {
        image = DemoMovie.GetComponent<Image>();
        image.enabled = true;
        Title.SetActive(false);

        StartCoroutine("SetTitle");
    }

    IEnumerator SetTitle()
    {
        yield return new WaitForSeconds(2.0f);
        loadtext.enabled = true;
        tips.SetActive(true);
        titlescreen.SetActive(false);

        yield return new WaitForSeconds(4.5f);
        Title.SetActive(true);

        gameObject.SetActive(false);
        Image image = DemoMovie.GetComponent<Image>();
        image.enabled = false;

        GameObject BGM_Title = GameObject.Find("BGM_Title");
        AudioSource bgmtitle = BGM_Title.GetComponent<AudioSource>();
        bgmtitle.enabled = true;
    }


}

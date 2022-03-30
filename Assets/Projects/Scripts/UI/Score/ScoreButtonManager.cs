using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreButtonManager : MonoBehaviour
{
    Title title;
    AudioSource audioSource;
    public GameObject[] CheckBoard;
    void Start()
    {
        title = GameObject.Find("Title").GetComponent<Title>();
        audioSource = GetComponent<AudioSource>();
    }

    public void RetryButton()
    {
        CheckBoard[0].SetActive(true);
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.parent.position);

    }
    public void QuitButton()
    {
        CheckBoard[1].SetActive(true);
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.parent.position);
    }

    public void RetryYes()
    {
        title.RestartGame();
    }


    public void RetryNo()
    {
        CheckBoard[0].SetActive(false);
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.parent.position);

    }
    public void HomeYes()
    {
        title.ComeHome();
    }
    public void HomeNo()
    {
        CheckBoard[1].SetActive(false);
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.parent.position);
    }




}

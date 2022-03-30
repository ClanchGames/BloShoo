using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip[] SoundEffects;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonSE()
    {
        audioSource.PlayOneShot(SoundEffects[0]);
    }
    public void GameClearSE()
    {
        AudioSource.PlayClipAtPoint(SoundEffects[1], transform.position, 0.5f);
    }
}

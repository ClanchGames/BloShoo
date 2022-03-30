using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class OfficialTwitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void officialtwitter()
    {
        string url = "https://twitter.com/intent/user?user_id=1298189028353650690";
        Application.OpenURL(url);
    }
}

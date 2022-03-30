using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TweetButton : MonoBehaviour
{
    int score;
    GameClearScore gameClearScore;
    // Start is called before the first frame update
    void Start()
    {
        gameClearScore = GameObject.Find("ScoreUI").GetComponent<GameClearScore>();
    }

    public void TweetClick()
    {
        score = gameClearScore.scorepoint;
        string esctext = UnityWebRequest.EscapeURL("ブロシューでスコア" + score.ToString() + "点を出しました! みんなは超えられるかな?");
        string esctag = UnityWebRequest.EscapeURL("ブロシュー");
        string url = "https://twitter.com/intent/tweet?text=" + esctext + "&hashtags=" + esctag;

        //Twitter投稿画面の起動
        Application.OpenURL(url);

    }
}

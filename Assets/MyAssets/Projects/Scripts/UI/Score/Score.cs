using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text ScorePoint;


    // Start is called before the first frame update
    void Start()
    {
        Game game = GameObject.Find("GameArea").GetComponent<Game>();
        ScorePoint.text = game.score_.ToString();

    }

}

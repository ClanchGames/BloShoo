using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionManager : MonoBehaviour
{
    Game game;
    public GameObject OptionBeamPrefab;
    private float timeElapsed;
    float optionbeamgeneratetime = 0.7f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject GameArea = GameObject.Find("GameArea");
        game = GameArea.GetComponent<Game>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!game.isBossDown && !game.BossAppear && !game.ItemAppear)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= optionbeamgeneratetime)
            {
                GenerateBeam();
                timeElapsed = 0.0f;
            }
        }
    }
    void GenerateBeam()
    {

        RectTransform OptionRect = GetComponent<RectTransform>();
        for (int i = 0; i < 3; i++)
        {
            GameObject OptionBeam = Instantiate(OptionBeamPrefab);
            RectTransform OptionBeamRect = OptionBeam.GetComponent<RectTransform>();
            OptionBeamRect.SetParent(OptionRect, false);
            if (i == 0)
            {
                OptionBeamRect.localPosition = new Vector3(0, 30, 0);
                OptionBeam.name = "OptionC";
            }
            else if (i == 1)
            {
                OptionBeamRect.localPosition = new Vector3(25, 20, 0);
                OptionBeam.name = "OptionR";
            }
            else if (i == 2)
            {
                OptionBeamRect.localPosition = new Vector3(-25, 20, 0);
                OptionBeam.name = "OptionL";
            }
        }
    }
}

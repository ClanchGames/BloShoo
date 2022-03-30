using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageBossAttack : MonoBehaviour
{
    float timeElapsed;
    float ChooseAttackSpeed = 4f;

    public bool isbrokenbarrier = false;
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameArea").GetComponent<Game>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!game.isBossDown)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= ChooseAttackSpeed)
            {

                ChooseAttack();
                timeElapsed = 0.0f;


            }

            if (isbrokenbarrier)
            {
                ChooseAttackSpeed -= 2f;
                isbrokenbarrier = false;
            }
        }
        else
        {
            timeElapsed = 0.0f;
        }
    }


    void ChooseAttack()
    {

        int attackpattern = Random.Range(0, 3);
        if (attackpattern == 0)
        {
            AttackPattern("Blue");
        }
        else if (attackpattern == 1)
        {
            AttackPattern("Green");
        }
        else if (attackpattern == 2)
        {
            AttackPattern("Red");
        }
    }

    void AttackPattern(string patterncolor)
    {
        GameObject PatternColor = GameObject.Find("Pattern" + patterncolor);
        if (patterncolor == "Blue")
        {
            var script = PatternColor.GetComponent<PatternBlue>();
            script.enabled = true;
            enabled = false;
        }
        else if (patterncolor == "Green")
        {
            var script = PatternColor.GetComponent<PatternGreen>();
            script.enabled = true;
            enabled = false;
        }
        else if (patterncolor == "Red")
        {
            var script = PatternColor.GetComponent<PatternRed>();
            script.enabled = true;
            enabled = false;
        }

    }

}
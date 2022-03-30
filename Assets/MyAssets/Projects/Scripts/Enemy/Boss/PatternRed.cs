using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRed : MonoBehaviour
{
    int count = 0;


    float timeElapsed;

    int[] xpos = { -175, 175, -230, 230 };


    int AttackTimes = 2;
    public float AttackSpeedRed = 0.5f;
    public GameObject Attack_redPrefab;
    public RectTransform RectPatternRed;
    public GameObject BossAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        timeElapsed += Time.deltaTime;
        if (timeElapsed >= AttackSpeedRed)
        {


            GameObject Attack_red = Instantiate(Attack_redPrefab);
            RectTransform RedTransform = Attack_red.GetComponent<RectTransform>();
            RedTransform.SetParent(RectPatternRed, false);
            RedTransform.localPosition = new Vector2(xpos[0 + (count * 2)], 300);

            GameObject Attack_red2 = Instantiate(Attack_redPrefab);
            RectTransform RedTransform2 = Attack_red2.GetComponent<RectTransform>();
            RedTransform2.SetParent(RectPatternRed, false);

            RedTransform2.localPosition = new Vector2(xpos[1 + (count * 2)], 300);


            timeElapsed = 0.0f;

            count++;

            if (count == AttackTimes)
            {

                timeElapsed = 0.0f;
                count = 0;
                ManageBossAttack managebossattack = BossAttack.GetComponent<ManageBossAttack>();
                managebossattack.enabled = true;

                enabled = false;





            }
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternGreen : MonoBehaviour
{
    int count = 0;
    float timeElapsed;

    int[] xpos = { -175, 175, -230, 230 };

    int choosexpos;
    int AttackTimes = 5;
    public float AttackSpeedGreen = 0.5f;
    public GameObject Attack_greenPrefab;
    public RectTransform RectPatternGreen;
    public GameObject BossAttack;

    // Start is called before the first frame update
    void Start()
    {
        int randomnum = Random.Range(0, 4);//int Randomは以上、未満
        choosexpos = randomnum;
    }

    // Update is called once per frame
    void Update()
    {


        timeElapsed += Time.deltaTime;
        if (timeElapsed >= AttackSpeedGreen)
        {


            GameObject Attack_green = Instantiate(Attack_greenPrefab);
            RectTransform GreenTransform = Attack_green.GetComponent<RectTransform>();
            GreenTransform.SetParent(RectPatternGreen, false);





            GreenTransform.localPosition = new Vector2(xpos[choosexpos], 300);

            timeElapsed = 0.0f;

            count++;

            if (count == AttackTimes)
            {


                timeElapsed = 0.0f;
                ManageBossAttack managebossattack = BossAttack.GetComponent<ManageBossAttack>();
                count = 0;

                int randomnum = Random.Range(0, 4);//int Randomは以上、未満
                choosexpos = randomnum;
                managebossattack.enabled = true;

                enabled = false;


            }
        }


    }

}

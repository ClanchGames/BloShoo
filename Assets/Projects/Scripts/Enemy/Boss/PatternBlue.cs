using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBlue : MonoBehaviour
{
    int count = 0;

    int[] xpos = { -175, 175, -230, 230 };
    float timeElapsed;
    int AttackTimes = 5;
    public float AttackSpeedBlue = 0.5f;
    public GameObject Attack_bluePrefab;
    public RectTransform RectPatternBlue;
    public GameObject BossAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        timeElapsed += Time.deltaTime;
        if (timeElapsed >= AttackSpeedBlue)
        {


            GameObject Attack_blue = Instantiate(Attack_bluePrefab);
            RectTransform BlueTransform = Attack_blue.GetComponent<RectTransform>();
            BlueTransform.SetParent(RectPatternBlue, false);



            int choosexpos = Random.Range(0, 4);//int Randomは以上、未満

            BlueTransform.localPosition = new Vector2(xpos[choosexpos], 300);

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

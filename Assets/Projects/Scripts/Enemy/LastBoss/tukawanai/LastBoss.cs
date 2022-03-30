using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBoss : MonoBehaviour
{


    public GameObject LBMoverObject;
    LBMover lBMover;

    bool issetposition;
    bool isright;
    bool isleft;
    public bool issetrightposition;
    public bool issetleftposition;
    float a;
    float firstrotation;

    // Start is called before the first frame update
    void Start()
    {
        lBMover = LBMoverObject.GetComponent<LBMover>();
        a = transform.localEulerAngles.z;
        firstrotation = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        issetposition = lBMover.isSetPosition;
        isright = lBMover.isright;
        isleft = lBMover.isleft;


        if (issetposition)
        {
            MoveStart();
        }
    }


    void MoveStart()
    {

    }












    /* void RotateStart()
     {
         if (isright)
         {
             if (transform.localEulerAngles.z >= 45f)
             {
                 if (transform.localEulerAngles.z == -315f)
                     Debug.Log(transform.localEulerAngles.z);
                 transform.localEulerAngles = new Vector3(0, 0, a);
                 a -= rotatespeed;
                 if (transform.localEulerAngles.z <= -315f)
                 {
                     Debug.Log("in");
                     transform.localEulerAngles = new Vector3(0, 0, -315f);
                 }
                 if (transform.localEulerAngles.z == -315f)
                 {

                     issetrightposition = true;
                     a = firstrotation;
                     transform.localEulerAngles = new Vector3(0, 0, a);
                 }
             }
         }
         else if (isleft)
         {
             if (transform.localEulerAngles.z <= 405f)
             {
                 transform.localEulerAngles = new Vector3(0, 0, a);
                 a += rotatespeed;
                 if (transform.localEulerAngles.z >= 405f)
                 {
                     transform.localEulerAngles = new Vector3(0, 0, 405f);
                 }
                 if (transform.localEulerAngles.z == 405f)
                 {
                     issetleftposition = true;
                     a = firstrotation;
                     transform.localEulerAngles = new Vector3(0, 0, a);
                 }
             }
         }
     }*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarMove : MonoBehaviour
{
    Vector3 epos;
    Vector3 BarPos;
    float distance;



    public void OnTouch(BaseEventData arg)
    {
        Debug.Log("touch");
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        PointerEventData e = arg as PointerEventData;
        BarPos = this.transform.position;
        epos = e.position;
    }
    public void OnDrag(BaseEventData arg)
    {
        Debug.Log("drag");
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        PointerEventData e = arg as PointerEventData;

        Vector3 prePos = this.transform.position;
        Vector3 epos2 = e.position;
        Vector3 diff = epos2 - epos;
        diff.z = 0.0f;

        this.transform.position = BarPos + diff;
        this.transform.position = new Vector3(this.transform.position.x, prePos.y, prePos.z);
        var Recttransform = GetComponent<RectTransform>();
        Vector2 localPosition = Recttransform.anchoredPosition;

        localPosition.x = Mathf.Clamp(localPosition.x, -230, 230);
        /* if(isAddBar)
             localPosition.x = Mathf.Clamp(localPosition.x, -140, 140);
             */
        Recttransform.anchoredPosition = localPosition;

    }

}

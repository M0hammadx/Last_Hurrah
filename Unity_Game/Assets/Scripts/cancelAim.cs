using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cancelAim : MonoBehaviour
    ,IDropHandler
{
    public aim aimscript;

    public void OnDrop(PointerEventData eventData)
    {
        aimscript.CancelAim();
    }
}

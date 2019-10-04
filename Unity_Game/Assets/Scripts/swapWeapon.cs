using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class swapWeapon : MonoBehaviour
    ,IPointerClickHandler
{
    public Weapon[] slots;
    public aim aimScript;

    int current = 0;

    private void Awake()
    {
        aimScript.SwapWeapon(slots[current]);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        current = (current + 1) % slots.Length;
        aimScript.SwapWeapon(slots[current]);
    }
}

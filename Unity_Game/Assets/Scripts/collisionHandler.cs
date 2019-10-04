using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    private List<Targetable> thingsInRange;

    private void Awake()
    {
        thingsInRange = new List<Targetable>();
    }

    public List<Targetable> GetTargetList()
    {
        return thingsInRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Targetable target = collision.GetComponent<Enemy>();
        if (target != null)
            thingsInRange.Add(target);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Targetable target = collision.GetComponent<Enemy>();
        if (target != null)
            thingsInRange.Remove(target);
    }
}

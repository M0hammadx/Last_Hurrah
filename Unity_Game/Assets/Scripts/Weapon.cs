using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject {
    public new string name;
    public string description;

    public Sprite artwork;

    public float startAngle;
    public float endAngle;
    public float startRange;
    public float endRange;
    public float minDamage;
    public float maxDamage;
    public float critDamage;
    public float startCrit;
    public float endCrit;
    public float overCrit;
    public float startMiss;
    public float endMiss;
    public float manaCost;
    public float coolDown;
    public float chargeTime;
    public float overTime;

    public string attackType;

    bool IsMiss(float time)
    {
        float ratio = Mathf.Min(1, time / chargeTime);
        return Random.Range(0f, 1) <= (startMiss + (endMiss - startMiss) * ratio);
    }

    bool IsCrit(float time)
    {
        float over = Mathf.Max(0, time - chargeTime);
        if (over == 0)
        {
            float ratio = Mathf.Min(1, time / chargeTime);
            return Random.Range(0f, 1) <= (startCrit + (endCrit - startCrit) * ratio);
        }
        float ratioOver = Mathf.Min(1, over / overTime);
        return Random.Range(0f, 1) <= (endCrit + (overCrit - endCrit) * ratioOver);
    }

    public float GetDamage(float time)
    {
        if (IsMiss(time))
            return 0;
        else if (IsCrit(time))
            return critDamage;
        float ratio = Mathf.Min(1, time / chargeTime);
        float damage = minDamage + (maxDamage - minDamage) * ratio;
        return damage;
    }

    public float GetRange(float time)
    {
        float ratio = Mathf.Min(1, time / chargeTime);
        return startRange + (endRange - startRange) * ratio;
    }

    public float GetAngle(float time)
    {
        float ratio = Mathf.Min(1, time / chargeTime);
        return startAngle + (endAngle - startAngle) * ratio;
    }
}

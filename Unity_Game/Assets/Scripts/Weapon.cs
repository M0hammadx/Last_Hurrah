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
    public float manaCost;
    public float coolDown;
    public float chargeTime;

    public string attackType;
}

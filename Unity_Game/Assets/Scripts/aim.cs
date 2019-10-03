using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(drawRange))]
[RequireComponent(typeof(SpriteRenderer))]
public class aim : MonoBehaviour {

    public Weapon weapon;

    public Transform player;
    public Joystick joystick;
    private drawRange draw;
    private MeshProvider mesh;
    private Transform range;

    private float chargeTimer = 0;

    private void Awake()
    {
        draw = GetComponent<drawRange>();
        mesh = GetComponent<MeshProvider>();
        GetComponent<SpriteRenderer>().sprite = weapon.artwork;
        range = transform.Find("Range");
    }

	
	// Update is called once per frame
	void Update () {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            //TODO check stamina
            //aim
            player.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            chargeTimer += Time.deltaTime;
            chargeTimer = Mathf.Min(chargeTimer, weapon.chargeTime);
            float ratio = chargeTimer / weapon.chargeTime;
            draw.RenderArc(weapon.endRange, weapon.endAngle);
            mesh.RenderMesh(weapon.startRange + (weapon.endRange - weapon.startRange) * ratio, weapon.startAngle + (weapon.endAngle - weapon.startAngle) * ratio);
            range.gameObject.SetActive(true);
            draw.lineRenderer.enabled = true;
        }
        else
        {
            range.gameObject.SetActive(false);
            draw.lineRenderer.enabled = false;
            if (chargeTimer > 0)
            {
                //hit
                float damage = weapon.minDamage + (weapon.maxDamage - weapon.minDamage) * (chargeTimer / weapon.chargeTime);
                chargeTimer = 0;
            }
        }
    }
}

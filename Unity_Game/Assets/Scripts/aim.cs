using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(drawRange))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(MeshProvider))]
public class aim : MonoBehaviour
{

    public Weapon weapon;

    public Transform player;
    public Joystick joystick;
    public GameObject cancelAim;

    private drawRange draw;
    private MeshProvider mesh;
    private Transform range;
    private collisionHandler rangeHandler;

    private float chargeTimer = 0;
    private float coolDown = 0;
    private float swapCoolDown = 1;

    private void Awake()
    {
        draw = GetComponent<drawRange>();
        mesh = GetComponent<MeshProvider>();
        range = transform.Find("Range");
        rangeHandler = range.GetComponent<collisionHandler>();
    }

    public void CancelAim()
    {
        chargeTimer = 0;
    }

    public void SwapWeapon(Weapon newWeapon)
    {
        coolDown = swapCoolDown;
        weapon = newWeapon;
        GetComponent<SpriteRenderer>().sprite = newWeapon.artwork;
    }

    void Update()
    {
        Vector3 aimVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        coolDown = Mathf.Max(0, coolDown - Time.deltaTime);

        if (aimVector != Vector3.zero)
        {
            player.rotation = Quaternion.LookRotation(Vector3.forward, aimVector);
            if (coolDown == 0)
            {
                //TODO check stamina
                chargeTimer += Time.deltaTime;
                draw.RenderArc(weapon.endRange, weapon.endAngle);
                mesh.RenderMesh(weapon.GetRange(chargeTimer), weapon.GetAngle(chargeTimer));
                range.gameObject.SetActive(true);
                draw.lineRenderer.enabled = true;
                cancelAim.SetActive(true);
            }
        }
        else
        {
            if (chargeTimer > 0)
            {
                foreach (Targetable target in rangeHandler.GetTargetList())
                {
                    target.TakeDamage(weapon.GetDamage(chargeTimer));
                }
                chargeTimer = 0;
                coolDown = weapon.coolDown;
            }
            range.gameObject.SetActive(false);
            draw.lineRenderer.enabled = false;
            cancelAim.SetActive(false);
        }
    }
}

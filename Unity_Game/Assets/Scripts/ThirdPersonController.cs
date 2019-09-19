using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float WalkSpeed = 2;
    public float RunSpeed = 4;

    public float TurnSmoothlyTime = .2f;
    float TurnSmoothlyVelocity;

    public float SpeedSmoothlyTime = .1f;
    float SpeedSmoothlyVelocity;
    float CurrentSpeed;

    Animator anim;
    public Transform cam;


    void Start()
    {
        anim = GetComponent<Animator>();
       // cam = Camera.main.transform;
    }

    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 InputDirection = input.normalized;

        //بحسب الزاوية اللي باصص ليها عشان اتحرك ناحيتها 
        if(InputDirection != Vector2.zero)
        {
            float TargetRotation = Mathf.Atan2(InputDirection.x, InputDirection.y) * Mathf.Rad2Deg + cam.eulerAngles.y; 
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetRotation, ref TurnSmoothlyVelocity, TurnSmoothlyTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);

        if(running)
        {
            float targetSpeed = RunSpeed * InputDirection.magnitude;
            CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targetSpeed, ref SpeedSmoothlyVelocity, SpeedSmoothlyTime);
            transform.Translate(transform.forward * CurrentSpeed * Time.deltaTime, Space.World);
            float AnimSpeed = 1 * InputDirection.magnitude;
            anim.SetFloat("Blend", AnimSpeed , SpeedSmoothlyTime , Time.deltaTime);

        }
        else
        {
            float targetSpeed = WalkSpeed * InputDirection.magnitude;
            CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targetSpeed, ref SpeedSmoothlyVelocity, SpeedSmoothlyTime);
            transform.Translate(transform.forward * CurrentSpeed * Time.deltaTime, Space.World);
            float AnimSpeed = .5f * InputDirection.magnitude;
            anim.SetFloat("Blend", AnimSpeed, SpeedSmoothlyTime, Time.deltaTime);
        }

    }
}

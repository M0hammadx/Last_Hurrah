using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public bool LockCursor;
    public float MouseSensitivity = 10;
    public Transform player;
    public float DistanceFromPlayer = 2;
   // public Vector2 PitchMinMax = new Vector2(-40, 85);

    public float RotationSmoothTime = .12f;
    Vector3 RotationSmoothVelocity;
    Vector3 CurrentRotation;

   // float yaw;
  //  float pitch;

    void Start()
    {
        if(LockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        //yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
       // pitch -= Input.GetAxis("Mouse Y") * MouseSensitivity;

       // pitch = Mathf.Clamp(pitch, PitchMinMax.x, PitchMinMax.y);

      //  CurrentRotation = Vector3.SmoothDamp(CurrentRotation, new Vector3(pitch, yaw), ref RotationSmoothVelocity, RotationSmoothTime);
       // transform.eulerAngles = CurrentRotation;

        transform.position = player.position - transform.forward * DistanceFromPlayer;
    }



}

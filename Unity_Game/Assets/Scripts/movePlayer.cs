using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float baseMoveSpeed = 8f;
    public Joystick joystick;
    public Joystick aimJoyStick;

    private void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        Vector3 aimVector = (Vector3.right * aimJoyStick.Horizontal + Vector3.up * aimJoyStick.Vertical);

        if (moveVector != Vector3.zero)
        {
            if (aimVector == Vector3.zero)
            {
                moveSpeed = baseMoveSpeed;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            }
            else
            {
                moveSpeed = baseMoveSpeed * 0.5f;
            }
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}

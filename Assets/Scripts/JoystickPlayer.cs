using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    public float speed;
    public FixedJoystick joystick;
    public Rigidbody rb;
    private float worldAngle;
    public Vector3 northPole;

    private void Start()
    {
      
    }

    public void HandlePlayerRotation(Vector3 origin, Vector3 axis, float angle){

      rb = GetComponent<Rigidbody>();
      Quaternion q = Quaternion.AngleAxis(angle, axis);
      rb.MovePosition(q * (rb.transform.position - origin) + origin);
      rb.MoveRotation(rb.transform.rotation * q);

    }

    public void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        worldAngle = Vector3.Angle(rb.transform.position, northPole);

        HandlePlayerRotation(Vector3.zero, Vector3.right * horizontal * 50f * Time.fixedDeltaTime, worldAngle);

        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
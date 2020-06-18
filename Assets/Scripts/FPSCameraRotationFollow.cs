using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraRotationFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public FixedJoystick joystick;
    public Transform player;
    private float X, Y;

    // Update is called once per frame
    void FixedUpdate()
    {
      X = joystick.Horizontal * moveSpeed;
      Y = joystick.Vertical * moveSpeed;
      player.Rotate(0f, X, 0f);
    }
}

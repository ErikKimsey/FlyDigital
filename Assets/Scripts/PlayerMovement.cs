using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private Vector3 moveDirection;
    public FixedJoystick joystick;
    public Rigidbody rb;
    private float inputX, inputY;
    private Vector3 currentDirectionVertex;

    void HandleXMovement() {
        inputX = joystick.Horizontal * moveSpeed * Time.deltaTime;
        if (inputX > 0)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (inputX < 0)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        } 
    }

    void HandleZMovement() {
      Debug.Log("joystick.Vertical");
      Debug.Log(joystick.Vertical);
        inputY = joystick.Vertical * moveSpeed * Time.deltaTime;
        inputX = joystick.Horizontal * moveSpeed * Time.deltaTime;
        if (inputY > 0)
        {
            currentDirectionVertex = Vector3.forward * Time.deltaTime;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            HandleXMovement();
        }
        if (inputY < 0)
        {
            currentDirectionVertex = -Vector3.forward * Time.deltaTime;
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            HandleXMovement();
        }
        if(inputY == 0){
          transform.Translate(currentDirectionVertex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(inputX, 0f, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate() {
      HandleZMovement();
      GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection));
    }
}

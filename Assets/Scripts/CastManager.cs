using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject fly;
    private Rigidbody fly_rb;
    private static Gyroscope m_gyro;
    private Vector3 attitude;
    public float speed;
    public GameObject fly_prefab;

    void Start()
    {
      m_gyro = SensorManager.m_gyro;
      attitude = m_gyro.userAcceleration;
    }

    public void ReadyCast(){
      // fly = GameObject.CreatePrimitive(PrimitiveType.Cube);
      // fly.transform.position = new Vector3(0f, 2f, 10f);
    }

    public void Cast(){
      Vector3 movement = new Vector3(attitude.x, Mathf.Abs(attitude.y+2f), Mathf.Abs(attitude.z+2f*12f));
      GameObject fly_instance;
      fly_instance = Instantiate(fly_prefab, fly_prefab.transform.position, transform.rotation);
      // fly_rb = fly.AddComponent<Rigidbody>();
      fly_rb = fly_instance.GetComponent<Rigidbody>();
      fly_rb.AddForce(movement * speed);
    }

    private void OnMouseDown()
    {
      ReadyCast();
      Debug.Log("DOWN MOUSE");
    }

    private void OnMouseUp()
    {
      Cast();
      Debug.Log("EXIT MOUSE");
    }

    private void HandleTouch(){
    if (Input.touchCount > 0)
        {
          Debug.Log("TOUCHED");
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                  ReadyCast();
                  break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    
                  break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                  Cast();
                  break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
      HandleTouch();
    }
}

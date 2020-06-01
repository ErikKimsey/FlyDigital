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
      Debug.Log("ReadyCast");
    }

    public void Cast(){
      Vector3 movement = new Vector3(attitude.x, Mathf.Abs(attitude.y+2f), Mathf.Abs(attitude.z+2f*12f));
      GameObject fly_instance;
      fly_instance = Instantiate(fly_prefab, fly_prefab.transform.position, transform.rotation);
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
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                  ReadyCast();
                  break;

                case TouchPhase.Ended:
                  Cast();
                  break;
            }
        }
    }

    void Update()
    {
      HandleTouch();
    }
}

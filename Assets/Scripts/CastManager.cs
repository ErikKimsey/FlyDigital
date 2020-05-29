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

    void Start()
    {
      m_gyro = SensorManager.m_gyro;
      attitude = m_gyro.userAcceleration;
      ReadyCast();
    }

    public void ReadyCast(){
      fly = GameObject.CreatePrimitive(PrimitiveType.Cube);
      fly.transform.position = new Vector3(0f, 2f, 3f);
      fly_rb = fly.AddComponent<Rigidbody>();
      Cast();
    }

    public void Cast(){
      Vector3 movement = new Vector3(attitude.x+2f, Mathf.Abs(attitude.y+2f), Mathf.Abs(attitude.z+2f));
      fly_rb.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
      ReadyCast();
      Debug.Log(m_gyro.attitude);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject fly;
    private Rigidbody fly_rb;
    private static Gyroscope m_gyro;
    private Quaternion attitude;
    private Vector3 acceleration;
    public float speed;
    public GameObject fly_prefab;
    ParticleChargeManager chargeParticles;

    void Start()
    {
      m_gyro = SensorManager.m_gyro;
      acceleration = m_gyro.userAcceleration;
    }

    public void ReadyCast(){
      chargeParticles = GetComponent<ParticleChargeManager>();
      chargeParticles.ChargeParticles();
      acceleration = m_gyro.userAcceleration;
    }

    public void Cast(){
      Vector3 movement = new Vector3(attitude.x, Mathf.Abs(attitude.y+2f), Mathf.Abs(attitude.z+2f*12f));
      Debug.Log(attitude);
      GameObject fly_instance;
      fly_instance = Instantiate(fly_prefab, fly_prefab.transform.position, transform.rotation);
      fly_rb = fly_instance.GetComponent<Rigidbody>();
      fly_rb.AddForce(movement * speed);
      chargeParticles.ReleaseParticles();
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

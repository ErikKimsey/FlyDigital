using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject fly;
    private Rigidbody fly_rb;
    // private static Gyroscope m_gyro;
    private Quaternion attitude;
    private Vector3 acceleration;
    public float speed;
    public GameObject fly_prefab;
    ParticleChargeManager chargeParticles;
    SensorManager m_gyro;
    private Vector3 highestAccel;

    void Start()
    {
      chargeParticles = GetComponent<ParticleChargeManager>();
      m_gyro = GetComponent<SensorManager>();
      highestAccel = Vector3.zero;
    }

    public void ReadyCast(){
      chargeParticles.ChargeParticles();
      acceleration = m_gyro.GetAcceleration();
      attitude = m_gyro.GetAttitude();
      if(acceleration.y > highestAccel.y){
        highestAccel = acceleration;
      }
    }

    public void Cast(){
      Vector3 movement = new Vector3(attitude.x, Mathf.Abs(attitude.y*2f), Mathf.Abs(attitude.z+2f*12f));
      attitude = new Quaternion(0f, Mathf.Abs(attitude.y) * 5f, Mathf.Abs(attitude.z) * 5, attitude.w);
      Debug.Log("acceleration");
      Debug.Log(highestAccel);
      GameObject fly_instance;
      fly_instance = Instantiate(fly_prefab, fly_prefab.transform.position, Quaternion.identity);
      fly_rb = fly_instance.GetComponent<Rigidbody>();
      fly_rb.velocity = new Vector3(highestAccel.x, Mathf.Abs(highestAccel.y),Mathf.Abs(highestAccel.z)) * 20f;
      Debug.Log("fly_rb.velocity");
      Debug.Log(fly_rb.velocity);
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

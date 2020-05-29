using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject fly;
    private static Gyroscope m_gryo;

    void Start()
    {
      m_gryo = SensorManager.m_gyro;
    }

    public void ReadyCast(){
      // fly = GameObject.CreatePrimitive()
    }

    public void Cast(){

    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log(m_gryo.attitude);
    }
}

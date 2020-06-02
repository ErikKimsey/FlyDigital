using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SensorManager : MonoBehaviour
{
    public TextMeshProUGUI x;
    public TextMeshProUGUI y;
    public TextMeshProUGUI z;
    private string xStr;
    private string yStr;
    private string zStr;
    public static Gyroscope m_gyro;
    private Quaternion gyroAttitude;
    private Vector3 gyroAcceleration;
    public GameObject cube;
    private GameObject sphere;

    void Start()
    {
      Screen.orientation = ScreenOrientation.Portrait;
      m_gyro = Input.gyro;
      
      m_gyro.enabled = true;
      // x = GameObject.Find("x").GetComponent<TextMeshProUGUI>();
      // y = GameObject.Find("y").GetComponent<TextMeshProUGUI>();
      // z = GameObject.Find("z").GetComponent<TextMeshProUGUI>();
    }

    public Vector3 GetAcceleration(){
      return gyroAcceleration;
    }

    public Quaternion GetAttitude(){
      return gyroAttitude;
    }

    void Update()
    {
      gyroAttitude = m_gyro.attitude;
      gyroAcceleration = m_gyro.userAcceleration;
      // xStr = gyroAttitude.ToString();
      // yStr = gyroAcceleration.ToString();
      // x.SetText(xStr);
      // y.SetText(yStr);
    }
}

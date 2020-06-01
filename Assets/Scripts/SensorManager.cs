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
    private Quaternion gyroOutput;
    public GameObject cube;
    private GameObject sphere;

    void Start()
    {
      Screen.orientation = ScreenOrientation.Portrait;
      m_gyro = Input.gyro;
      Debug.Log((m_gyro));
      m_gyro.enabled = true;
      x = GameObject.Find("x").GetComponent<TextMeshProUGUI>();
      y = GameObject.Find("y").GetComponent<TextMeshProUGUI>();
      z = GameObject.Find("z").GetComponent<TextMeshProUGUI>();
      // button.
    }

    // Update is called once per frame
    void Update()
    {
      gyroOutput = m_gyro.attitude;
    }
}

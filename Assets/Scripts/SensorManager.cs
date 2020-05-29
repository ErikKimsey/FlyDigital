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
    private Gyroscope m_gyro;
    private Quaternion gyroOutput;
    public GameObject cube;
    private GameObject sphere;

    void Start()
    {
      Screen.orientation = ScreenOrientation.Portrait;
      m_gyro = Input.gyro;
      m_gyro.enabled = true;
      x = GameObject.Find("x").GetComponent<TextMeshProUGUI>();
      y = GameObject.Find("y").GetComponent<TextMeshProUGUI>();
      z = GameObject.Find("z").GetComponent<TextMeshProUGUI>();
      // button.
    }

    public void Cast(){
      Debug.Log("CAST");
      sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      sphere.transform.position = new Vector3(0, 5.5f, 12f);
      sphere.AddComponent(typeof(Rigidbody));
    }

    // Update is called once per frame
    void Update()
    {
      gyroOutput = m_gyro.attitude;
      xStr = gyroOutput.x.ToString();
      yStr = gyroOutput.y.ToString();
      zStr = gyroOutput.z.ToString();
      
      float xPos = gyroOutput.x + Time.deltaTime + cube.transform.position.x;
      float yPos = gyroOutput.y + Time.deltaTime + cube.transform.position.y;
      cube.transform.position = new Vector3(xPos, yPos, 12f);
      // x.SetText(gyroOutput.x.ToString());
      x.SetText(gyroOutput.ToString());
      // x.SetText(gyroOutput.x.ToString());
      y.SetText(m_gyro.userAcceleration.ToString());
      z.SetText(gyroOutput.z.ToString());
    }
}

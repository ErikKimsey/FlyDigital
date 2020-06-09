using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsActions : MonoBehaviour
{
    private GameObject clouds;
    public Vector3 rotationPoint;
    public float rotationRate;
    public Vector3 rotationDirection;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      transform.RotateAround(rotationPoint, rotationDirection, rotationRate * Time.deltaTime);
    }
}

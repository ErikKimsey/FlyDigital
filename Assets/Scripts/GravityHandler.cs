using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    private Vector3 userSurfaceDistance;
    private Rigidbody userRB;
    // private Rigidbody userRB;
    public GameObject planet;
    public float gravity;

    void Start()
    {
      userRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      userSurfaceDistance = (userRB.transform.position - planet.transform.position).normalized;
      userRB.AddForce(userSurfaceDistance * -gravity);
    }
}

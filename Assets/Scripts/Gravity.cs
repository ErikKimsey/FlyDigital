using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update
    public Planet attractorPlanet;
    private Transform playerTransform;
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(attractorPlanet){
            attractorPlanet.Attract(playerTransform);
        }
    }
}

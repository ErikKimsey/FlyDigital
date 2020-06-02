using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSplash : MonoBehaviour
{
    
    public ParticleSystem splash;

    private void OnCollisionEnter(Collision other)
    {
      Vector3 splashPos = other.collider.transform.position;
      Instantiate(splash, splashPos, Quaternion.identity);
      // ParticleSystem clone = Instantiate(splash, splashPos, Quaternion.identity);
      splash.Play();
    }
}

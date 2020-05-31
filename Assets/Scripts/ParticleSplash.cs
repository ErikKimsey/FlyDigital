using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSplash : MonoBehaviour
{
    
    public ParticleSystem splash;
      
    void Awake() {
        splash = GetComponent<ParticleSystem>();
    }
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
      Debug.Log(other.collider.transform.position);
      Vector3 splashPos = other.collider.transform.position;
      ParticleSystem clone = Instantiate(splash, splashPos, Quaternion.identity);
      // firework.GetComponent<ParticleSystem>().Play();
      clone.Play();
    }

    void OnTriggerEnter (Collider col)  {
      splash.Play();
    }
    
    void Update()
    {
        
    }
}

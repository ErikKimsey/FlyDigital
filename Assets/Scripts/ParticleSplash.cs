using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSplash : MonoBehaviour
{
    
    private ParticleSystem _psystem;
      
    void Awake() {
        _psystem = GetComponent<ParticleSystem>();
    }
    void Start()
    {
        
    }

    void OnTriggerEnter (Collider col)  {
      _psystem.Play();
    }
    
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleChargeManager : MonoBehaviour
{
    
    public ParticleSystem chargingParticles;

    // -- On ReadyCast --
    // * Play particles,
    public void ChargeParticles(){
      Debug.Log("CHARGE PLAYING");
      chargingParticles.Play();
    }

    // -- On Cast --
    // * Stop Particles
    public void ReleaseParticles(){
      Debug.Log("CHARGE STOPPING");
      chargingParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

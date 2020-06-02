using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleChargeManager : MonoBehaviour
{
    
    public ParticleSystem chargingParticles;

    // -- On ReadyCast --
    // * Play particles,
    public void ChargeParticles(){
      if(chargingParticles.isStopped) chargingParticles.Play();
    }

    // -- On Cast --
    // * Stop Particles
    public void ReleaseParticles(){
      chargingParticles.Stop();
    }
}

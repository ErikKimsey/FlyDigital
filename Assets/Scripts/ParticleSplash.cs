using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSplash : MonoBehaviour
{
    
    public ParticleSystem splash;
    private IEnumerator destroyClone;

    private void OnCollisionEnter(Collision other)
    {
      // ParticleSystem clone;
      
        Vector3 splashPos = other.collider.transform.position;
        Instantiate(splash, splashPos, Quaternion.identity);
      // clone.Play();

      // Destroy(clone,2f);
      // destroyClone = DestroyClone(clone);
      // StartCoroutine(destroyClone);
    }

    private IEnumerator DestroyClone(ParticleSystem _clone){
      Debug.Log(_clone);
      yield return new WaitForSeconds(2f);
    }
}

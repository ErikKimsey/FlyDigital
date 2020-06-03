using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSplash : MonoBehaviour
{
    
    public ParticleSystem splash;
    private IEnumerator destroyClone;

    private void OnCollisionEnter(Collision other)
    {
      Vector3 splashPos = other.collider.transform.position;
      
      ParticleSystem clone = Instantiate(splash, splashPos, Quaternion.identity);
      clone.Play();

      destroyClone = DestroyClone(clone);
      StartCoroutine(destroyClone);
    }

    private IEnumerator DestroyClone(ParticleSystem clone){
      yield return new WaitForSeconds(0.5f);
      clone.Stop();
      clone.Clear();
      Debug.Log("destroy");
      Debug.Log(clone.isStopped);
      Destroy(clone);
      Debug.Log(clone);
    }
}

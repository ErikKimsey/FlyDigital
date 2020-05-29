using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SensorManager sm;
    void Start()
    {
      
    }

    public void Cast(){
      sm.Cast();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

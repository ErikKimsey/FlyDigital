using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void QuitApp(){
      Debug.Log("QUIT APP");
      Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}

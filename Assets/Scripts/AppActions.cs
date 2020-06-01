using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppActions : MonoBehaviour
{
    public void QuitApp(){
      Debug.Log("QUIT APP");
      Application.Quit();
    }
}

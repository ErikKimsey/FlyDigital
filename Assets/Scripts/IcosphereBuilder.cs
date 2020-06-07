using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosphereBuilder : MonoBehaviour
{
    [SerializeField]
    private int maxVertices = 12;
    [SerializeField]
    private int maxTris = 20;
    [SerializeField]
    private int sideLength;

    private float theta;

    private int[] tris;
    private Vector3[] vertices;

    private float xPos, yPos, zPos;

    private int triIter = 0;
    private int vertIter = 0;

    void Start()
    {
      tris = new int[]{};
      xPos = 0f;
      yPos = 0f;
      zPos = 0f;
      theta = (1 + Mathf.Sqrt(5))/sideLength;
    }



    void CreateVertices(){

      vertices = new Vector3[]{};
      theta = (1 + Mathf.Sqrt(5))/sideLength;
      for (int i = 0; i < maxVertices; i++){
        if(i % 6 == 0) {
          vertices[i] = new Vector3(theta * -1, i, i * -1);
        } else if(i % 5 ==0) {
          vertices[i] = new Vector3(i * -1, theta * -1f, i);
        } else if(i % 4 == 0) {
          vertices[i] = new Vector3(i, i * -1, theta);
        } else if(i % 3 == 0 ) {
          vertices[i] = new Vector3(theta + 1, i, i+1);
        } else if(i % 2 == 0) {
          vertices[1] = new Vector3(i + 1, theta + 1f, i);
        } else {
          vertices[i] = new Vector3(i, i + 1, theta);
        }
        Debug.Log(vertices[i]);
      }
    }

      void CreateTris(){

        // Creating array of indices,
        // indices pertain to that of the vertices[]
        // indices exist in a pattern of: 
        // (a, b, c), (b,c,d), (c,d,e), (d,e,f), (e,f,g),...
        // (1,2,3), (2,3,4), (3,4,5), (4,5,6), (5,6,7)
        // 
        for (int i = 0; i < maxTris; i++) {
          tris[i] = i;
          tris[i + 1] = tris[i + 3] = i + 1;
          tris[i + 2] = tris[i + 4] = i + 2;
        }
        Debug.Log(tris);
      }


      /**
      * iterate number of vertices,
      *** in each iteration:
      ****** assign iterating tris index to corresponding verticies: e.g., 
      * tris[0] = vertices[0],
      * tris[1] = vertices[1],
      * tris[2] = vertices[2],
      * tris[3] = vertices[2],
      * tris[4] = vertices[1],
      * tris[5] = vertices[3],
      * tris[6] = vertices[2],
      * tris[7] = vertices[3],
      * tris[8] = vertices[4],
      * tris[9] = vertices[4],
      * tris[10] = vertices[3],
      * tris[11] = vertices[5],
      */
    }
}

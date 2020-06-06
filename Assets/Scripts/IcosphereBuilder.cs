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

      // (0, +/-1, theta)
      // (+/-1 +/-theta, 0)
      // (+/-theta, 0, +/-1)
      // theta = (1 + sqrt(5))/2  ; where "2" is side length


      vertices = new Vector3[]{};
      for (int i = 0; i < maxVertices; i++){
        for (int j = 0; j<3 ; j++)   {
          vertices[vertIter] = new Vector3(i, i+1, theta + i);
          vertices[vertIter + 1] = new Vector3(i + 1, theta + 1, i);
          vertices[vertIter + 2] = new Vector3(theta + 1, i, i+1);
        }
        vertIter += 4;
      }

      void CreateTris(){

        // Creating array of indices,
        // indices pertain to that of the vertices[]
        // indices exist in a pattern of: 
        // (a, b, c), (b,c,d), (c,d,e), (d,e,f), (e,f,g),...

        for (int i = 0; i < maxTris; i++){
          for (int j = 0; j < 6; j++){
            tris[i] = i;
            tris[triIter + 1] = tris[triIter + 3] = i + 1;
            // tris[triIter + 2] = 
          }
        }
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

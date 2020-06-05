using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosphereBuilder : MonoBehaviour
{
    private int maxVertices = 24;
    private int[] tris;
    private Vector3[] vertices;

    private int xPos, yPos, zPos;

    void Start()
    {
      tris = new int[]{maxVertices};
      vertices = new Vector3[]{};   
      xPos = yPos = zPos = 0;
    }

    void CreateVertices(){

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
      for(int i=0; i<12; i++){
        int triIndex = i;
        for(int j=0; j<4; j++){
          vertices[i] = new Vector3(xPos, yPos, zPos);
          vertices[i+1] = vertices[i ] = new Vector3(xPos + j * 0.5f, yPos + 1, zPos + j * 0.5f);
          vertices[i+2] = new Vector3(xPos + j + 1, yPos * j + 1, zPos * j + 0.5f);
          tris[triIndex] ;
          // tris = 1,2,3,/3,2,4,/3,4,5,/5,4,6,/5,6,7/
        }

      }
    }
}

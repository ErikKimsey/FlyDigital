using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralMesh : MonoBehaviour
{
    private Vector3[] vertices;
    private int[] tris;
    public int verticesMax;

    private Mesh pgMesh;

    void Start(){
      pgMesh = GetComponent<MeshFilter>().mesh;
      BuildMesh();
      DrawMesh();
    }

    private void BuildMesh(){
      vertices = new Vector3[]{
        new Vector3(0f,0f,0f), 
        new Vector3(0f, 2f, 0f),
        new Vector3(2f, 0f, 2f),
        
        // new Vector3(0f, 0f, -1f),
        // new Vector3(0f, 0f, -1f),
        // new Vector3(0f, 0f, -1f),

      };

      tris = new int[]{
        0,1,2
      };
    }

    private void DrawMesh(){
      pgMesh.vertices = vertices;
      pgMesh.triangles = tris;
    }
}

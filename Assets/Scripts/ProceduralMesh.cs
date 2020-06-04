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
    private MeshFilter pgMeshFilter;
    private MeshRenderer pgMeshRenderer;

    void Start(){
      // pgMesh = new Mesh();
      pgMesh = GetComponent<MeshFilter>().mesh;
      // pgMeshRenderer = gameObject.AddComponent<MeshRenderer>();
      // pgMesh = pgMeshFilter.mesh;
      BuildMesh();
      DrawMesh();
    }

    private void BuildMesh(){
      vertices = new Vector3[]{
        new Vector3(0f,0f,0f), 
        new Vector3(0f, 0f, 1f),
        new Vector3(1f, 0f, 1f)
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

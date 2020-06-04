using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralMesh : MonoBehaviour
{
    private Vector3[] vertices;
    private int[] tris;
    public int verticesMax;

    private Mesh pgMesh;
    private MeshFilter pgMeshFilter;
    private MeshRenderer pgMeshRenderer;

    void Start(){
      pgMesh = new Mesh();
      pgMeshFilter = gameObject.AddComponent<MeshFilter>();
      pgMeshRenderer = gameObject.AddComponent<MeshRenderer>();
    }

    private void BuildMesh(){

    }


}

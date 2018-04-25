using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshMaker : MonoBehaviour {

    public Vector3[] newVertices;
    public Vector3[] newNormals;
    public Vector2[] newUV;
    public int[] newTriangles;
    void Start() {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.normals = newNormals;
        mesh.uv = newUV;
        mesh.triangles = newTriangles; }
}

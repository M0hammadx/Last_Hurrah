using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshProvider : MonoBehaviour {

    private Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    private drawRange draw;

    private void Awake()
    {
        draw = GetComponent<drawRange>();
        mesh = GetComponentInChildren<MeshFilter>().mesh;
    }

    public void RenderMesh(float radius, float angle)
    {
        makeMeshData(radius, angle);
        CreateMesh();
    }

    void makeMeshData(float radius, float angle)
    {
        //create an array of vertices
        vertices = draw.CalculateArcArray(radius, angle);

        //create an array of integers
        triangles = new int[(draw.resolution-1)*3];
       
        for (int i=0; i+1< draw.resolution; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3  + 1] = i+2;
            triangles[i * 3  + 2] = i+1;
        }
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class sensor_cubev1 : MonoBehaviour
{
    //public float distance = Random.Range(200, 500); //random the sight of the player
    public float distance = 100;
    public float angle = 70; //human sight angle.
    public float height = 1.5f; //sight height.
    public Color meshColor = Color.blue;

    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Mesh CreateNewMesh() {
        Mesh mesh = new Mesh();
        
        int numVertices = 24;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;
        

        int i = 0;
        
        //left side
        vertices[i++] = bottomCenter;
        vertices[i++] = bottomLeft;
        vertices[i++] = topLeft;

        vertices[i++] = topLeft;
        vertices[i++] = topCenter;
        vertices[i++] = bottomCenter;

        //right
        vertices[i++] = bottomCenter;
        vertices[i++] = bottomRight;
        vertices[i++] = topRight;

        vertices[i++] = topRight;
        vertices[i++] = topCenter;
        vertices[i++] = bottomCenter;

        //front
        vertices[i++] = bottomLeft;
        vertices[i++] = bottomRight;
        vertices[i++] = topRight;

        vertices[i++] = topRight;
        vertices[i++] = topLeft;
        vertices[i++] = bottomLeft;

        //top
        vertices[i++] = topCenter;
        vertices[i++] = topLeft;
        vertices[i++] = topRight;

        //bottom
        vertices[i++] = bottomCenter;
        vertices[i++] = bottomLeft;
        vertices[i++] = bottomRight;

        for(int j = 0; j < numVertices; j++) {
            triangles[j] = j;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();


        return mesh;
    }

    private void OnValidate() {
        mesh = CreateNewMesh();
    }
    private void OnDrawGizmos() {
        if (mesh) {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }

    }
}

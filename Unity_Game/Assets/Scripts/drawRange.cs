using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class drawRange : MonoBehaviour {

    public LineRenderer lineRenderer;
    public int resolution = 10;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = resolution + 2;
    }

    // Use this for initialization
    void Start () {
        lineRenderer.enabled = false;
	}

    public void RenderArc(float radius, float angle)
    {
        Vector3[] vertices = CalculateArcArray(radius, angle);
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].x -= 0.067f;
            vertices[i].y -= 0.067f;
        }
        lineRenderer.SetPositions(vertices);
    }

    public Vector3[] CalculateArcArray(float radius, float angle)
    {
        Vector3[] arcArray = new Vector3[resolution + 2];
        
        float startAngle = - angle / 2f;
        float endAngle = angle / 2f;

        float cangle = startAngle;
        arcArray[0] = arcArray[resolution+1]  = new Vector3(0, 0, 0);

        for (int i = 1; i <= resolution; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * cangle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * cangle) * radius;

            arcArray[i] = new Vector3(x, y,0);

            cangle += (angle / resolution);
        }
        return arcArray;
    }
}

public static class Vector2Extension
{

    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}

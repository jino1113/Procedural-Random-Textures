using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 10;  // �������ҧ�ͧ Plane
    public int height = 10; // �����٧�ͧ Plane
    public float scale = 1.0f;  // ��Ҵ�ͧ Noise
    public float heightMultiplier = 2.0f; // ��ҷ��з��������ٹ�ͧ�����٧���

    private MeshFilter meshFilter;
    private Mesh mesh;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        CreateTerrain();
    }

    void CreateTerrain()
    {
        Vector3[] vertices = new Vector3[(width + 1) * (height + 1)];
        int[] triangles = new int[width * height * 6];

        for (int i = 0, z = 0; z <= height; z++)
        {
            for (int x = 0; x <= width; x++)
            {
                float y = Mathf.PerlinNoise(x * scale, z * scale) * heightMultiplier; // �ӹǳ�����٧���� Perlin Noise
                vertices[i] = new Vector3(x, y, z); // ���ҧ�ش vertices �ͧ���Шش�� Plane
                i++;
            }
        }

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + width + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + width + 1;
                triangles[tris + 5] = vert + width + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}

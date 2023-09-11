using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public int cloudHeight = 100; // The height at which the clouds should appear

    [SerializeField] private Texture2D cloudPattern = null; // 2D texture that holds the cloud pattern
    bool[,] cloudData; // Array of clouds representing where clouds are. True = cloud, False = no cloud

    // Lists to hold vertex, triangle, and normal data for the cloud mesh
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector3> normals = new List<Vector3>();

    int vertCount; // Counter for the number of vertices generated
    int cloudTexWidth; // Width of the cloud texture, assumed to be a square

    // Start is called before the first frame update
    private void Start()
    {
        cloudTexWidth = cloudPattern.width; // Retrieve the width of the cloud texture

        Vector3 worldCentre = new Vector3(0, cloudHeight, 0); // Set the position for clouds
        transform.position = worldCentre;

        MeshFilter mF = GetComponent<MeshFilter>(); // Get the MeshFilter component attached to this GameObject
        LoadCloudData(); // Load cloud data from the texture
        mF.mesh = GetCloudMesh(); // Generate and set the cloud mesh
    }

    // Method to load cloud data from the 2D texture into the bool array
    private void LoadCloudData()
    {
        cloudData = new bool[cloudTexWidth, cloudTexWidth];
        Color[] cloudTex = cloudPattern.GetPixels(); // Get pixel data from the texture

        // Populate the cloudData array based on the alpha value of the texture's pixels
        for (int x = 0; x < cloudTexWidth; x++)
        {
            for (int y = 0; y < cloudTexWidth; y++)
            {
                cloudData[x, y] = (cloudTex[y * cloudTexWidth + x].a > 0); // True if alpha > 0 (i.e., not transparent)
            }
        }
    }

    // Method to create a Mesh from the cloud data
    private Mesh GetCloudMesh()
    {
        // Loop through cloud data to generate mesh vertices, triangles, and normals
        for (int x = 0; x < cloudTexWidth; x++)
        {
            for (int y = 0; y < cloudTexWidth; y++)
            {
                if (cloudData[x, y]) // If there's a cloud at this position
                    addCloudMeshData(x, y);
            }
        }

        Debug.Log("Generated " + vertices.Count + " vertices."); // Logging the count of generated vertices

        Mesh mesh = new Mesh(); // Create a new Mesh
        mesh.vertices = vertices.ToArray(); // Set the mesh vertices
        mesh.triangles = triangles.ToArray(); // Set the mesh triangles
        mesh.normals = normals.ToArray(); // Set the mesh normals
        return mesh;
    }

    // Method to populate mesh data for a single cloud
    private void addCloudMeshData(int x, int z)
    {
        // Add four vertices for each cloud tile
        vertices.Add(new Vector3(x, 0, z));
        vertices.Add(new Vector3(x, 0, z + 1));
        vertices.Add(new Vector3(x + 1, 0, z + 1));
        vertices.Add(new Vector3(x + 1, 0, z));

        // Add normals. These are facing downwards (Vector3.down)
        for (int i = 0; i < 4; i++)
            normals.Add(Vector3.down);

        // Add two triangles to make a quad for each cloud tile
        // Triangle 1
        triangles.Add(vertCount + 1);
        triangles.Add(vertCount);
        triangles.Add(vertCount + 2);

        // Triangle 2
        triangles.Add(vertCount + 2);
        triangles.Add(vertCount);
        triangles.Add(vertCount + 3);

        // Increment the vertex count by 4 (because we added 4 vertices)
        vertCount += 4;
    }
}

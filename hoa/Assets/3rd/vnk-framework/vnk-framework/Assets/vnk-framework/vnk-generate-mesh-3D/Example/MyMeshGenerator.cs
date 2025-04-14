using UnityEngine;
//using static BMesh;
//using static Yoolax.Framework.BMesh;
//using static BMesh; // otherwise you'll have to write "BMesh.Vertex" etc.

namespace Yoolax.Framework
{
    //public class MyMeshGenerator : MonoBehaviour
    //{
    //    //BMesh mesh; // We keep a reference to the BMesh

    //    //void Start()
    //    //{
    //    //    mesh = new BMesh();
    //    //    Vertex v1 = mesh.AddVertex(-1, 0, -1);
    //    //    Vertex v2 = mesh.AddVertex(1, 0, -1);
    //    //    Vertex v3 = mesh.AddVertex(1, 0, 1);
    //    //    Vertex v4 = mesh.AddVertex(-1, 0, 1);
    //    //    mesh.AddFace(v1, v2, v3, v4);

    //    //    // Set the current mesh filter to use our generated mesh
    //    //    BMeshUnity.SetInMeshFilter(mesh, GetComponent<MeshFilter>());
    //    //}

    //    //// In the editor, draw some debug information about the mesh
    //    //private void OnDrawGizmos()
    //    //{
    //    //    if (mesh != null)
    //    //    {
    //    //        Gizmos.matrix = transform.localToWorldMatrix;
    //    //        BMeshUnity.DrawGizmos(mesh);
    //    //    }
    //    //}

    //    public int width = 15;
    //    public int height = 15;

    //    BMesh mesh;

    //    BMesh GenerateGrid()
    //    {
    //        BMesh bm = new BMesh();
    //        for (int j = 0; j < height; ++j)
    //        {
    //            for (int i = 0; i < width; ++i)
    //            {
    //                bm.AddVertex(i, 0, j); // vertex # i + j * w
    //                if (i > 0 && j > 0) bm.AddFace(i + j * width, i - 1 + j * width, i - 1 + (j - 1) * width, i + (j - 1) * width);
    //            }
    //        }
    //        return bm;
    //    }

    //    void Start()
    //    {
    //        mesh = GenerateGrid();
    //        foreach (Vertex v in mesh.vertices)
    //        {
    //            v.point.y = Mathf.Sin(v.point.x + v.point.z); // Vertical displacement
    //        }
    //        BMeshUnity.SetInMeshFilter(mesh, GetComponent<MeshFilter>());
    //    }

    //    private void OnDrawGizmos()
    //    {
    //        Gizmos.matrix = transform.localToWorldMatrix;
    //        if (mesh != null) BMeshUnity.DrawGizmos(mesh);
    //    }
    //}
}
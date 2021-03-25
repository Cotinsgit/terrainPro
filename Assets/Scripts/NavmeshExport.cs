using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.IO;

public class NavmeshExport : MonoBehaviour {

    [MenuItem("Tools/Navmesh Export")]
    static void Export() {
        NavMeshTriangulation navMeshTriangulation = NavMesh.CalculateTriangulation();

        string path = Application.dataPath + "/obj/" + SceneManager.GetActiveScene().name + ".obj";
        Debug.Log("Create directory " + path);

        string dirPath = Path.GetDirectoryName(path);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        StreamWriter streamWriter = new StreamWriter(path);
        //顶点  
        for (int i = 0; i < navMeshTriangulation.vertices.Length; i++)
        {
            streamWriter.WriteLine("vertice  " + navMeshTriangulation.vertices[i].x + " " + navMeshTriangulation.vertices[i].y 
                + " " + navMeshTriangulation.vertices[i].z);
        }

        //索引  
        for (int i = 0; i < navMeshTriangulation.indices.Length;)
        {
            streamWriter.WriteLine("indice " + (navMeshTriangulation.indices[i] + 1) + " " + (navMeshTriangulation.indices[i + 1] + 1) 
                + " " + (navMeshTriangulation.indices[i + 2] + 1));
            i = i + 3;
        }

        streamWriter.Flush();
        streamWriter.Close();

        AssetDatabase.Refresh();

        Debug.Log("NavMesh Export Success");
    }
}

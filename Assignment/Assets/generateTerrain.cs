using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class generateTerrain : MonoBehaviour
{

    // to initalize height and detail of the landscape
    int height = 5;
    float detail = 5.0f;
    // public GameObject tree;
    // to keep track of trees available so when trees are destroyed, trees are available to be placed on a different plane
    List<GameObject> myTrees = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // mesh is taken from the object attached to this 
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3 [] vertices = mesh.vertices;

        // looping over mesh
        for(int v = 0; v < vertices.Length; v++)
        {
            // lifting vertices by taking y position of each vertices in the mesh
            // perlin noise lifts taking values from x and y position of the vertex
            // using position of the plane as offset for function so plane isnt repeated entirely           
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detail,
                                            (vertices[v].z + this.transform.position.z)/detail)*height;

             // Debug.Log(vertices[v].y);

              if(vertices[v].y > 2.7 && Random.Range(0,100) < 10)
              {
                  GameObject newTree = treeBuild.getTree();
                  if(newTree != null)
                  {
                  Vector3 treePos = new Vector3(vertices[v].x + this.transform.position.x,
                                                                            vertices[v].y,
                                                                            vertices[v].z + this.transform.position.z);
                    // trees now also disappear from behind deping on where player is moving
                    newTree.transform.position = treePos;
                    newTree.SetActive(true);
                    myTrees.Add(newTree);
                    }    
              }                              
        }

        // setting calculated vertices into mesh
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        // to explore
        this.gameObject.AddComponent<MeshCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

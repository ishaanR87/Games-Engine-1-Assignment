using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeBuild : MonoBehaviour
{

    // number of trees being generated
        int numTrees = 100;
        // from this object
        public GameObject treePrefab;
        // array of trees
        GameObject[] trees;

    // Start is called before the first frame update
    void Start()
    {   
        trees = new GameObject[numTrees];
        for(int i = 0; i< numTrees; i++)
        {
            trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            trees[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

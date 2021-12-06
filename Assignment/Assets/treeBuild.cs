using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeBuild : MonoBehaviour
{

    // number of trees being generated
        static int numTrees = 100;
        // from this object
        public GameObject treePrefab;
        // array of trees
       static GameObject[] trees;

    // Start is called before the first frame update
    void Start()
    {   
        // set array to be size of numtrees to allocate memory
        trees = new GameObject[numTrees];
        for(int i = 0; i< numTrees; i++)
        {
            trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            // trees made inactive
            trees[i].SetActive(false);
        }
    }
    	
    // loops through trees to look for unactive trees and will return them
    static public GameObject getTree()
    {
        for(int i = 0; i < numTrees; i++)
        {
            if(!trees[i].activeSelf)
            {
                return trees[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

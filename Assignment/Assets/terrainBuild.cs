using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// each plane will be placed into a tile
class Tile 
{
    public GameObject aTile;
    public float creationTime;

    // constructor to link to game object 
    public Tile(GameObject t, float ct)
    {
        aTile = t;
        creationTime = ct;
    }
}

public class terrainBuild : MonoBehaviour
{

    // plane prefab and player, need to know where player is to genrate more terrain
    public GameObject plane;
    public GameObject player;

    // size needed to add more tiles
    int planeSize = 10;
    // how many tiles around player
    int halfTileX = 10;
    int halfTileZ = 10;

    // where player is and was 
    Vector3 startPos;

    // can index game objects based on x and z position 
    Hashtable tiles = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        // creates connecting plain
        for(int x = -halfTileX; x < halfTileX; x++)
        {
            for(int z = -halfTileZ; z < halfTileZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize+startPos.x)
                                            ,0,
                                            (z * planeSize+startPos.z));
                GameObject t = (GameObject) Instantiate(plane, pos, Quaternion.identity);
                
                // name given based on x and z position
                string tileName = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tileName;
                // new tile created which sets the tile game object with update time
                Tile tile = new Tile(t, updateTime);
                // adding tile to hash table
                tiles.Add(tileName,tile);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

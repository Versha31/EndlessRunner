using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilefab;
    public float spawnz=0;
    public float len = 30;
    public int numTiles = 6;
    public List<GameObject> actvTiles = new List<GameObject>();
    public Transform player;


    void Start()
    {
      for(int i = 0; i < numTiles; i++)
        {
            if (i == 0)
            {
                spawnTile(0);
            }
            else
            {
                spawnTile(Random.Range(0, tilefab.Length));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 35 > spawnz - (numTiles * len))
        {
            spawnTile(Random.Range(0, tilefab.Length));
            TiletileGoAway();
        }
    }

    public void TiletileGoAway()
    {
        Destroy(actvTiles[0]);
        actvTiles.RemoveAt(0);
    }
    public void spawnTile(int index)
    {
        GameObject go = Instantiate(tilefab[index], transform.forward * spawnz, transform.rotation);
        spawnz += len;
        actvTiles.Add(go);
    }
}

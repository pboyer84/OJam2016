using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class TileRoot : MonoBehaviour
{

    public int depth = 0;
    

    public bool shouldSpawnEnemy = true;

    void Update()
    {
        if (shouldSpawnEnemy && depth > 3)
        {
            shouldSpawnEnemy = false;

            generateEnemy();


            if (depth > 6)
            {
                generateEnemy();
            }

            if (depth > 9)
            {
                generateEnemy();
            }
        }

    }

    private void generateEnemy()
    {
        int randomEnemy = Random.Range(0, 2);

        GameObject enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/" + (randomEnemy == 1 ? "Drone" : randomEnemy == 2 ? "Tank" : "Turret")));

        Tile[] tiles = GetComponentsInChildren<Tile>();


        int randomSpawn = Random.Range(0, tiles.Length - 1);

        enemy.transform.position = tiles[randomSpawn].transform.position;
        enemy.transform.position += new Vector3(0, 0.654f, 0.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        //  Debug.Log("trigger");

        if(col.GetComponent<PlayerMove>())
        ModuleSystem.generateNext(depth);



    }

}

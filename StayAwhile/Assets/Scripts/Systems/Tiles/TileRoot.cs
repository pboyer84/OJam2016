using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class TileRoot : MonoBehaviour
{

    public int depth = 0;
    
    public void Start()
    {
       // generateEnemy();
    }


    public bool shouldSpawnEnemy = true;

    void Update()
    {
        if (shouldSpawnEnemy && depth > 3)
        {
            shouldSpawnEnemy = false;

            generateEnemy();


            if (depth > 7)
            {
                generateEnemy();
            }
            
        }

    }

    private void generateEnemy()
    {
        int randomEnemy = Random.Range(0, 3);

        GameObject enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/" + (randomEnemy == 1 ? "Tank" : randomEnemy == 2 ? "Drone" : "Turret")));

        Tile[] tiles = GetComponentsInChildren<Tile>();


        int randomSpawn = Random.Range(0, tiles.Length);

        enemy.transform.position = tiles[randomSpawn].transform.position;
        enemy.transform.position += new Vector3(0, 2.2f, 0.0f);
        if (randomEnemy == 2)
        {
            enemy.transform.position += new Vector3(0, 3.5f, 0.0f);
        }

		if (randomEnemy != 1 && randomEnemy != 2)
		{
			enemy.transform.position -= new Vector3(0, 1.5f, 0.0f);
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<PlayerMove>())
        ModuleSystem.generateNext(depth);
		
    }

}

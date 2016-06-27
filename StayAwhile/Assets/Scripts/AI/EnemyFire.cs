using UnityEngine;

public class EnemyFire : MonoBehaviour {

    public Transform ProjectileSpawn;
    public GameObject ProjectilePrefab;    
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
    public void Fire()
    {
        GameObject projectile = (GameObject)Instantiate(ProjectilePrefab, ProjectileSpawn.position, ProjectileSpawn.rotation);
    }
}

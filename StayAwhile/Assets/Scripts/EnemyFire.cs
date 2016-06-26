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
        GameObject projectile = (GameObject)Instantiate(ProjectilePrefab, ProjectileSpawn.position, Quaternion.identity);
        Fireball fb = projectile.GetComponent<Fireball>();
        fb.Orient(player);
    }
}

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
        Vector3 inFront = transform.position + transform.forward;
        GameObject projectile = (GameObject)Instantiate(ProjectilePrefab, ProjectileSpawn.position, transform.rotation);
    }
}

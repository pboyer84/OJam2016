using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {

    public Transform ProjectileSpawn;
    public GameObject ProjectilePrefab;
    public float FirePeriod = 2.0f;
    public float timer;

    private GameObject player;
    private Fireball fb;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= FirePeriod)
        {
            timer = 0f;
            GameObject projectile = (GameObject)Instantiate(ProjectilePrefab, ProjectileSpawn.position, Quaternion.identity);
            Fireball fb = projectile.GetComponent<Fireball>();
            fb.Orient(player);
        }
	}
}

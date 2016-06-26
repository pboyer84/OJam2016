using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    public Transform GunPoint;
    public Transform DebugTarget;
    public float FireDistance = 10f;
    public AudioClip HitVulnerableEnemy;
    public AudioClip HitImmuneEnemy;
    public AudioSource Player;
    public GameObject RailShotPrefab;

    private bool isGunFiring = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            isGunFiring = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            isGunFiring = true;
        }
    }

    void FixedUpdate()
    {
        if (isGunFiring)
        {
            RaycastHit hitInfo;
            Ray r = new Ray(GunPoint.position, GunPoint.forward);
            if (Physics.Raycast(r, out hitInfo, FireDistance))
            {
                EnemyHealth health = hitInfo.transform.gameObject.GetComponent<EnemyHealth>();
                if (health != null)
                {
                    if (health.IsVulnerable)
                    {
                        GameObject shot = (GameObject)Instantiate(RailShotPrefab, transform.position, Quaternion.identity);
                        RailShot s = shot.GetComponent<RailShot>();
                        Vector3 shotStart = GunPoint.position + (GunPoint.forward * 0.1f);
                        Vector3 shotEnd = GunPoint.position + (GunPoint.forward * FireDistance);
                        s.Init(shotStart, shotEnd);
                        Player.clip = HitVulnerableEnemy;
                        Player.Play();
                        Destroy(hitInfo.collider.gameObject.transform.parent.gameObject);
                    }
                    else
                    {
                        Player.clip = HitImmuneEnemy;
                        Player.Play();
                    }
                }

            }
            else
            {
                Debug.Log("Hit nothing");
            }

        }
    }
}

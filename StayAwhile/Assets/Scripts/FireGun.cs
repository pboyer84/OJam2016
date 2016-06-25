using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    public float FireDistance = 10f;
    public AudioClip HitVulnerableEnemy;
    public AudioClip HitImmuneEnemy;
    public AudioSource Player;
    public GameObject RailShotPrefab;

    private bool isGunFiring = false;
    // Use this for initialization
	void Start () {
	    
	}
	
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
            Ray r = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(r, out hitInfo, FireDistance))
            {
                MeshRenderer mr = hitInfo.transform.gameObject.GetComponent<MeshRenderer>();
                if (mr != null)
                {
                    if (mr.material.name == "Good")
                    {
                        GameObject shot = (GameObject)Instantiate(RailShotPrefab, transform.position, Quaternion.identity);
                        RailShot s = shot.GetComponent<RailShot>();
                        Vector3 shotStart = transform.position + (transform.forward * 0.1f);
                        Vector3 shotEnd = transform.position + (transform.forward * FireDistance);
                        s.Init(shotStart, shotEnd);
                        Player.Play();
                    }
                }
            }

        }
    }
}

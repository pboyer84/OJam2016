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
    
    // Use this for initialization
	void Start ()
    {

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
        Debug.DrawRay(GunPoint.position, GunPoint.forward, Color.cyan);
        if (isGunFiring)
        {
            Debug.Log("Fire!");
            RaycastHit hitInfo;
            Ray r = new Ray(GunPoint.position, GunPoint.forward);
            if (Physics.Raycast(r, out hitInfo, FireDistance))
            {
                Debug.Log("Hit: " + hitInfo.transform.gameObject.name);
                MeshRenderer mr = hitInfo.transform.gameObject.GetComponent<MeshRenderer>();
                if (mr != null)
                {
                    Debug.Log("mr name is " + mr.material.name);
                    if (mr.material.name == "HitTheBeat (Instance)")
                    {
                        GameObject shot = (GameObject)Instantiate(RailShotPrefab, transform.position, Quaternion.identity);
                        RailShot s = shot.GetComponent<RailShot>();
                        Vector3 shotStart = GunPoint.position + (GunPoint.forward * 0.1f);
                        Vector3 shotEnd = GunPoint.position + (GunPoint.forward * FireDistance);
                        s.Init(shotStart, shotEnd);
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

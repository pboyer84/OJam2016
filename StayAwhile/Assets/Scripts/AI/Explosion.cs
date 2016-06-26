using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    private bool isExploding = false;
    public int Damage = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isExploding)
        {
            isExploding = true;
            StartCoroutine(Explode());
        }
	}

    IEnumerator Explode()
    {
        for (float i = 1; i < 10; i+=0.3f)
        {
            transform.localScale = new Vector3(i,i, i);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Health target = coll.gameObject.GetComponent<Health>();
            if (target != null)
            {
                target.Value -= Damage;
                target.DisplayDamageFx();
                target.ShakeCamera();
            }
        }
    }
}

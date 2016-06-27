using UnityEngine;

public class TouchAttack : MonoBehaviour {

    public int Damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("foooo");
        if (coll.gameObject.tag == "Player")
        {
            Health target = coll.gameObject.GetComponent<Health>();
            if (target != null)
            {
                target.Value -= Damage;
                target.DisplayDamageFx();
                target.ShakeCamera();
            }
            Destroy(gameObject);
        }
    }
}

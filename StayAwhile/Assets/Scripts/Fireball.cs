using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour {

    public float Speed;
    public int Damage;
    private Rigidbody myBody;


    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
    public void Orient(GameObject target)
    {
        transform.LookAt(target.transform);
    }

	void FixedUpdate ()
    {
        myBody.velocity = transform.forward * Speed;
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile hit: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Health target = collision.gameObject.GetComponent<Health>();
            if (target != null)
            {
                target.Value -= Damage;
                target.DisplayDamageFx();
            }
        }
        Destroy(gameObject);
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankShell : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        myBody.AddForce(transform.forward * Speed);
    }

    void OnCollisionEnter(Collision collision)
    {
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

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour {

    public float Speed;
    public int Damage;
    public float SecondsToLive = 20f;
    private Rigidbody myBody;
    private float timeToLiveTimer = 0f;

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

    void Update()
    {
        timeToLiveTimer += Time.deltaTime;
        if (timeToLiveTimer > SecondsToLive)
        {
            Destroy(gameObject);
        }
    }

	void FixedUpdate ()
    {
        myBody.velocity = transform.forward * Speed;
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

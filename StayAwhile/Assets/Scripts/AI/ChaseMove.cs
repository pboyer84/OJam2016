using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChaseMove : MonoBehaviour {

    public float MaxSpeed;

    private Rigidbody myBody;
    private GameObject player;
    private float CurrentSpeed;
    

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myBody = GetComponent<Rigidbody>();
    }

    void Start () {
        CurrentSpeed = MaxSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    void FixedUpdate()
    {
        if (CurrentSpeed > 0f)
        {
            transform.LookAt(player.transform.position);
        }
        myBody.velocity = transform.forward * CurrentSpeed;
    }

    public void ToggleSpeed()
    {
        CurrentSpeed = CurrentSpeed == 0 ? MaxSpeed : 0f;
    }
}

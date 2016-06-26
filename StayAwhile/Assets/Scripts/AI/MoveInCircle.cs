using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveInCircle : MonoBehaviour {

    public float Radius;
    public float Speed;

    private float angle;
    private Rigidbody myBody;
    private Vector3 anchor;
    private GameObject player;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        anchor = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.LookAt(player.transform.position);
        angle += Speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        float newX = Mathf.Cos(angle) * Radius;
        float newZ = Mathf.Sin(angle) * Radius;
        transform.position = anchor + new Vector3(newX, 0f, newZ);
    }
}

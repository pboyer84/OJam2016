using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour {

    public float WalkSpeed = 5f;

    private CharacterController myBody;
    private float xMov;
    private float zMov;
    private float xMouse;
    private float yMouse;

    void Awake()
    {
        myBody = GetComponent<CharacterController>();
    }

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        xMov = Input.GetAxis("Horizontal");
        zMov = Input.GetAxis("Vertical");
        xMouse = Input.GetAxis("Mouse X");
	}

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, xMouse * 15f);
        Vector3 movement = transform.forward * zMov + transform.right * xMov;
        myBody.Move(movement * WalkSpeed * Time.deltaTime);
    }
}

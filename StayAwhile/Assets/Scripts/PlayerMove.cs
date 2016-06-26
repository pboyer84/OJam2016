using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour, SongListener
{

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
        SongEvents.Add(this);
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
        myBody.SimpleMove(movement * WalkSpeed);
    }

    Tile lastTile = null;
    TileType currentSong = TileType.Red;
    void OnTriggerEnter(Collider other)
    {
        Tile isTile = other.gameObject.GetComponent<Tile>();
        if (isTile)
        {
            if (lastTile == null)
            {
                lastTile = isTile;
                return;
            }

            if (lastTile.tileType == currentSong)
            {
              

                if (isTile.tileType != lastTile.tileType)
                {
                    Debug.Log("Player is leaving a song tile while its music is still playing. Kill the player for not staying awhile to listen.");

                    Health playerHealth = GetComponent<Health>();
                    playerHealth.Value -= 1000;
                }
            }

            lastTile = isTile;


        }
//        Debug.Log(other.name);
        //        Destroy(other.gameObject);
    }

    public void onSongEvent(SongEventType eventType, TileType songType)
    {
        if (eventType == SongEventType.OnSongStarted)
        {
            currentSong = songType;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(EnemyFire))]
[RequireComponent(typeof(EnemyHealth))]
public class TankController : MonoBehaviour {

    private AudioSource tankSounds;
    public BeatDetector MyBeat;
    


    private EnemyFire Attack;
    private EnemyHealth Health;
    private ChaseMove Movement;
    
    bool IsVulnerable;
    bool IsAttacking;

    void Awake()
    {
        tankSounds = GetComponent<AudioSource>();
        Health = GetComponent<EnemyHealth>();
        Movement = GetComponent<ChaseMove>();

        switch (SongManager.instance.songColor)
        {
            case TileType.Blue: MyBeat = SongManager.instance.blueSong.beat; break;
            case TileType.Green: MyBeat = SongManager.instance.greenSong.beat; break;
            case TileType.Red: MyBeat = SongManager.instance.redSong.beat; break;
            case TileType.Yellow: MyBeat = SongManager.instance.yellowSong.beat; break;
            default: MyBeat = SongManager.instance.redSong.beat; break;
        }
    }

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (MyBeat.IsBeat)
        {
            Health.ToggleVulnerable();
            Movement.ToggleSpeed();
        }

        switch (SongManager.instance.songColor)
        {
            case TileType.Blue: MyBeat = SongManager.instance.blueSong.beat; break;
            case TileType.Green: MyBeat = SongManager.instance.greenSong.beat; break;
            case TileType.Red: MyBeat = SongManager.instance.redSong.beat; break;
            case TileType.Yellow: MyBeat = SongManager.instance.yellowSong.beat; break;
            default: MyBeat = SongManager.instance.redSong.beat; break;
        }
    }
}

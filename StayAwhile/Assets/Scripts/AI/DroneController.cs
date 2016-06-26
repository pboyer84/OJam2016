using UnityEngine;

[RequireComponent(typeof(EnemyFire))]
[RequireComponent(typeof(EnemyHealth))]
public class DroneController : MonoBehaviour {

    public BeatDetector MyBeat;
    private EnemyFire Attack;
    private EnemyHealth Health;

    void Awake()
    {
        Attack = GetComponent<EnemyFire>();
        Health = GetComponent<EnemyHealth>();

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
	void Update () {
	    if (MyBeat.IsQuarterBeat)
        {
            Attack.Fire();
        }
        if (MyBeat.IsHalfBeat)
        {
            Health.ToggleVulnerable();
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

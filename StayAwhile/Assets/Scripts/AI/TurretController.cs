using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFire))]
[RequireComponent(typeof(EnemyHealth))]
public class TurretController : MonoBehaviour {

    public int ShotsPerBurst = 1;
    public float DegreesPerRotation = 30f;
    public BeatDetector MyBeat;

    private EnemyFire Attack;
    private EnemyHealth Health;
    private Vector3 Rotation = new Vector3(0f, 90f, 0f);
    private GameObject TurretHead;

    void Awake()
    {
        TurretHead = transform.FindChild("Turret_Head").gameObject;
        switch (SongManager.instance.songColor)
        {
            case TileType.Blue: MyBeat = SongManager.instance.blueSong.beat; break;
            case TileType.Green: MyBeat = SongManager.instance.greenSong.beat; break;
            case TileType.Red: MyBeat = SongManager.instance.redSong.beat; break;
            case TileType.Yellow: MyBeat = SongManager.instance.yellowSong.beat; break;
            default: MyBeat = SongManager.instance.redSong.beat; break;
        }
    }

    void Start () {
        Attack = GetComponent<EnemyFire>();
        Health = GetComponent<EnemyHealth>();
        Rotation = new Vector3(0f, DegreesPerRotation, 0f);
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
            TurretHead.transform.Rotate(Rotation);
        }

		if(SongManager.instance)
        switch (SongManager.instance.songColor)
        {
            case TileType.Blue: MyBeat = SongManager.instance.blueSong.beat; break;
            case TileType.Green: MyBeat = SongManager.instance.greenSong.beat; break;
            case TileType.Red: MyBeat = SongManager.instance.redSong.beat; break;
            case TileType.Yellow: MyBeat = SongManager.instance.yellowSong.beat; break;
            default: MyBeat = SongManager.instance.redSong.beat; break;
        }
    }

    IEnumerator FireWaitFire()
    {
        for (int i = 0; i < ShotsPerBurst; i++)
        {
            Attack.Fire();
            yield return new WaitForSeconds(0.2f);
        }
    }
}

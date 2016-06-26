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
    }
}

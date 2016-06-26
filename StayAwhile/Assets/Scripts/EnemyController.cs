using UnityEngine;

[RequireComponent(typeof(EnemyFire))]
[RequireComponent(typeof(EnemyHealth))]
public class EnemyController : MonoBehaviour {

    public BeatDetector MyBeat;
    private EnemyFire Attack;
    private EnemyHealth Health;

    void Awake()
    {
        Attack = GetComponent<EnemyFire>();
        Health = GetComponent<EnemyHealth>();
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
	}
}

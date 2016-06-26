using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class EnemyHealth : MonoBehaviour {

    public bool IsVulnerable { get; private set; }
    public float VulnerablePeriod = 0.5f;

    public Material Immune;
    public Material Vulnerable;

    private MeshRenderer Display;

    private float vulnerabilityTimer = 0f;

    void Awake()
    {
        Display = GetComponent<MeshRenderer>();
    }

    // Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void ToggleVulnerable()
    {
        if (IsVulnerable)
        {
            BecomeImmune();
        }
        else
        {
            BecomeVulnerable();
        }
    }

    private void BecomeVulnerable()
    {
        IsVulnerable = true;
        Display.material = Vulnerable;
    }

    private void BecomeImmune()
    {
        IsVulnerable = false;
        Display.material = Immune;
    }

}

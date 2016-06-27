using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public bool IsVulnerable { get; private set; }
    public float VulnerablePeriod = 0.5f;

    public Material Immune;
    public Material Vulnerable;

    private MeshRenderer[] Display;

    private float vulnerabilityTimer = 0f;

    void Awake()
    {
        Display = GetComponentsInChildren<MeshRenderer>();
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
        foreach (Renderer r in Display)
        {
            //r.material = Vulnerable;
            r.material.color = Color.green;
        }
    }

    private void BecomeImmune()
    {
        IsVulnerable = false;
        foreach (Renderer r in Display)
        {
            //r.material = Immune;
            r.material.color = Color.white;
        }
    }

}

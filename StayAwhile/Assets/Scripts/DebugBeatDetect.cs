using UnityEngine;

public class DebugBeatDetect : MonoBehaviour, AudioProcessor.AudioCallbacks
{
    private int beatCounter = 0;
    private float beatTimer;
    private float beatTolerance = 0.25f;

    public Material Good;
    public Material Bad;
    public Material Neutral;

    public MeshRenderer Feedback;

    public void onOnbeatDetected()
    {
        beatCounter++;
        beatTimer = 0f;
        Debug.Log("Beat " + beatCounter);
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fired on beat");
        }
    }

    public void onSpectrum(float[] spectrum)
    {

    }


    // Use this for initialization
    void Start ()
    {
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.addAudioCallback(this);

    }

    // Update is called once per frame
    void Update ()
    {
        beatTimer += Time.deltaTime;
	    if (Input.GetButtonDown("Fire1") && beatTimer <= beatTolerance)
        {
            Debug.Log("Fired on beat!");
            Feedback.material = Good;
        }
        if (Input.GetButtonDown("Fire1") && beatTimer > beatTolerance)
        {
            Debug.Log("Fired too late");
            Feedback.material = Bad;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Feedback.material = Neutral;
        }
    }
}

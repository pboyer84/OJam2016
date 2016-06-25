using UnityEngine;

public class DebugBeatDetect : MonoBehaviour, AudioProcessor.AudioCallbacks
{
    private int beatCounter = 0;
    private float beatTimer;
    private float beatTolerance = 0.15f;

    public Material Good;
    public Material Bad;
    public Material Neutral;

    public MeshRenderer[] Feedback;

    public void onOnbeatDetected()
    {
        beatCounter++;
        beatTimer = 0f;
//        Debug.Log("Beat " + beatCounter);
        foreach (MeshRenderer r in Feedback)
        {
            r.material = Good;
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
        if (beatTimer > beatTolerance)
        {
            foreach (MeshRenderer mr in Feedback)
            {
                mr.material = Neutral;
            }     
        }
    }
}

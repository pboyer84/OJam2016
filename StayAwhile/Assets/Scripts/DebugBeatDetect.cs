using UnityEngine;

public class DebugBeatDetect : MonoBehaviour, AudioProcessor.AudioCallbacks
{
    private int beatCounter = 0;
    private float beatTimer;
    public float beatTolerance = 0.25f;
    public float knob = 10f;
    public Material Good;
    public Material Bad;
    public Material Neutral;
    public bool BeatOccuring = true;


    public MeshRenderer[] Feedback;

    public void onOnbeatDetected()
    {
        beatCounter++;
        beatTimer = 0f;
        Debug.Log("Beat " + beatCounter);
        foreach (MeshRenderer r in Feedback)
        {
            if (r != null)
            {
                r.material = Good;
            }
        }
    }

    public void onSpectrum(float[] spectrum)
    {
        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i]*100, 0);
            Debug.DrawLine(start, end, Color.red);
        }
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
            foreach (MeshRenderer r in Feedback)
            {
                if (r != null)
                {
                    r.material = Neutral;
                }
            }     
        }
    }
}

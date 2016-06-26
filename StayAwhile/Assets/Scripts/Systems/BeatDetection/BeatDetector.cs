using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BeatDetector : MonoBehaviour
{

    public float BaseTimeInSecond;

    private float Beat { get { return BaseTimeInSecond; } }
    private float HalfBeat { get { return BaseTimeInSecond / 2; } }
    private float QuarterBeat { get { return BaseTimeInSecond / 4; } }

    private float BeatTimer;
    private float HalfBeatTimer;
    private float QuarterBeatTimer;

    public bool IsStarted { get; set; }
    public bool IsBeat { get; private set; }
    public bool IsHalfBeat { get; private set; }
    public bool IsQuarterBeat { get; private set; }

    void Awake()
    {
        IsStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStarted)
        {
            UpdateBeatTimer();
            UpdateHalfBeatTimer();
            UpdateQuarterBeatTimer();
        }
    }

    private void UpdateBeatTimer()
    {
        BeatTimer += Time.deltaTime;
        if (BeatTimer >= Beat)
        {
            BeatTimer = 0f;
            IsBeat = true;
        }
        else
        {
            IsBeat = false;
        }
    }

    private void UpdateHalfBeatTimer()
    {
        HalfBeatTimer += Time.deltaTime;
        if (HalfBeatTimer >= HalfBeat)
        {
            HalfBeatTimer = 0f;
            IsHalfBeat = true;
        }
        else
        {
            IsHalfBeat = false;
        }
    }

    private void UpdateQuarterBeatTimer()
    {
        QuarterBeatTimer += Time.deltaTime;
        if (QuarterBeatTimer >= QuarterBeat)
        {
            QuarterBeatTimer = 0f;
            IsQuarterBeat = true;
        }
        else
        {
            IsQuarterBeat = false;
        }
    }
}
using UnityEngine;
using System.Collections;
using System;

public class MoveAway : MonoBehaviour, AudioProcessor.AudioCallbacks, SongListener
{
    public void onOnbeatDetected()
    {
        
    }

    public void onSongEvent(SongEventType eventType, TileType songType)
    {
        if(eventType == SongEventType.OnSongStarted)
        {
            GetComponent<Light>().color = TileFunc.toColor(songType);

            GetComponent<Renderer>().material.SetColor("_Color", TileFunc.toColor(songType));
        }
    }


    float beat = 0;
    public void onSpectrum(float[] spectrum)
    {
        beat = 0;

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i] * 10, 0);

            if (spectrum[i] * 10 > beat)
            {
                beat = spectrum[i] * 10.0f;
            }
            Debug.DrawLine(start, end, Color.white);
        }
    }

    // Use this for initialization

    public float speed = 10.0f;

    void Start () {
        SongEvents.Add(this);
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.addAudioCallback(this);

        GetComponent<Renderer>().material.SetColor("_Color", TileFunc.toColor(TileType.Red));
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().intensity = beat;
 


        if (ModuleSystem.get().depth > 0 && ModuleSystem.get().depth * 70.0f > gameObject.transform.position.z)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + Time.deltaTime * speed);
        }
    }
}

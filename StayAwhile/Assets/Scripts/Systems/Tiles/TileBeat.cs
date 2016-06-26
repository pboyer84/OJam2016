﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;

public class TileBeat : MonoBehaviour, AudioProcessor.AudioCallbacks, SongListener
{

    public TileType tileType;

    public float rampTime = 0;

    void Start()
    {
        SongEvents.Add(this);
        
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.addAudioCallback(this);

        GetComponent<Renderer>().material.SetColor("_color", TileFunc.toColor(tileType));

        transform.localScale *= 1.15f;

        if (tileType == TileType.Red && ModuleSystem.get().depth < 3)
        {
            enabledSong = true;
        }
    }

	void OnDestroy() {
		SongEvents.Remove (this);

		AudioProcessor processor = FindObjectOfType<AudioProcessor>();
		if(processor)
		processor.removeAudioCallback (this);

	}

    
    float beat = 0;

    public void OnDrawGizmos()
    {
        try
        {
            if (gameObject)
                if (GetComponent<Renderer>())
                    if (GetComponent<Renderer>().sharedMaterial)
                    {
              //          GetComponent<Renderer>().material.SetVector("_origin", gameObject.transform.position);
              //          GetComponent<Renderer>().material.SetColor("_color", TileFunc.toColor(tileType));
                    }
        }
        catch (UnityException e)
        {

        }


    }

    public void onOnbeatDetected()
    {

    }

    public void onSpectrum(float[] spectrum)
    {
        beat = 0;

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i] * 10, 0);

            if (spectrum[i] * 10 > beat)
            {
                beat = spectrum[i];
            }
            Debug.DrawLine(start, end, Color.white);
        }
    }

    void Update()
    {
        GetComponent<Renderer>().material.SetVector("_origin", gameObject.transform.position);
        GetComponent<Renderer>().material.SetFloat("_beat", beat);
        GetComponent<Renderer>().material.SetFloat("_rampup", rampTime);


        if (enabledSong)
        {
            rampTime += Time.deltaTime * 2.0f;
        }
        else
        {
            rampTime -= Time.deltaTime * 2.0f;
        }

        rampTime = Mathf.Clamp(rampTime, 0.0f, 1.0f);
    }

    Boolean enabledSong = false;
    public void onSongEvent(SongEventType eventType, TileType songType)
    {
        if(eventType == SongEventType.OnSongEnded)
        {
            if(songType == tileType)
            {
                enabledSong = false;
            }
        }

        if (eventType == SongEventType.OnSongStarted)
        {
            if (songType == tileType)
            {
                enabledSong = true;
            }
            if (songType != tileType)
            {
                enabledSong = false;
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;

public class Tile : MonoBehaviour, AudioProcessor.AudioCallbacks, SongListener
{

    public TileType tileType;

    public GameObject tilePulse;
    public GameObject tileBeat;

    void Start()
    {
        tilePulse = Instantiate(Resources.Load<GameObject>("Prefabs/Tiles/TilePulse"));
        tileBeat = Instantiate(Resources.Load<GameObject>("Prefabs/Tiles/TileBeat"));

        tilePulse.transform.parent = gameObject.transform;
        tileBeat.transform.parent = gameObject.transform;

        tilePulse.transform.localPosition = Vector3.zero;
        tileBeat.transform.localPosition = Vector3.zero;

        tilePulse.GetComponent<TilePulse>().tileType = tileType;
        tileBeat.GetComponent<TileBeat>().tileType = tileType;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        bounds.Expand(300000.0f);
        mesh.bounds = bounds;

        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.addAudioCallback(this);

        SongEvents.Add(this);

        GetComponent<Renderer>().material.SetColor("_Color", TileFunc.toColor(tileType));

        GetComponent<BoxCollider>().isTrigger = true;
        GetComponent<BoxCollider>().size = new Vector3(1.01f, 10, 1.01f);

        if(tileType == TileType.Red)
        {
            enabledSong = true;
        }
    }
    
    public void OnDrawGizmos()
    {
        if (gameObject)
            if (GetComponent<Renderer>())
                if (GetComponent<Renderer>())
                {
                 //   GetComponent<Renderer>().material.SetColor("_Color", TileFunc.toColor(tileType));
                }

    }

    public void onOnbeatDetected()
    {

    }

    public void onSpectrum(float[] spectrum)
    {
      
    }

    void Update()
    {
       
    }

    Boolean enabledSong = false;
    public void onSongEvent(SongEventType eventType, TileType songType)
    {
        if (eventType == SongEventType.OnSongEnded)
        {
            if (songType == tileType)
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

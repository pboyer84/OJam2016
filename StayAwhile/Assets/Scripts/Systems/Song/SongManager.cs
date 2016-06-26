using UnityEngine;
using System.Collections;



public class SongManager : MonoBehaviour {

    public TileType songColor = TileType.Red;

    public AudioClip redSong;
    public AudioClip blueSong;
    public AudioClip greenSong;
    public AudioClip yellowSong;

    public static SongManager instance;

    void Start () {
        instance = this;

        SongEvents.Occured(SongEventType.OnSongStarted, TileType.Red);
    }

    public float switchSongTime = 10.0f;
    public static float currentTime = 0;

    bool isFirstSwitch = true;
    void Update () {
        currentTime += Time.deltaTime;
        
        if(currentTime > switchSongTime)
        {
            currentTime = 0;

            TileType newType = TileFunc.randomType();

            if(isFirstSwitch) {
                isFirstSwitch = false;
                newType = TileType.Blue;
            }

            while(newType == songColor)
            {
                newType = TileFunc.randomType();
            }

            SongEvents.Occured(SongEventType.OnSongEnded, songColor);
            
            songColor = newType;

            SongEvents.Occured(SongEventType.OnSongStarted, newType);

            AudioSource audio = GameObject.Find("InputListener").GetComponent<AudioSource>();
            audio.Stop();

            if (songColor == TileType.Red)
            {
                audio.clip = redSong;        
            }
            if (songColor == TileType.Blue)
            {
                audio.clip = blueSong;
            }
            if (songColor == TileType.Green)
            {
                audio.clip = greenSong;
            }
            if (songColor == TileType.Yellow)
            {
                audio.clip = yellowSong;
            }

            audio.Play();


        }

    }
}

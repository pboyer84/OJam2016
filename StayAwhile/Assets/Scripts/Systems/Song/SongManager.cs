using UnityEngine;
using System.Collections;



public class SongManager : MonoBehaviour {

    public TileType songColor = TileType.Red;

    public AudioClip redAudioClip;
    public AudioClip blueAudioClip;
    public AudioClip greenAudioClip;
    public AudioClip yellowAudioClip;

    public Song redSong;
    public Song blueSong;
    public Song greenSong;
    public Song yellowSong;

    public static SongManager instance;
    
    void Awake()
    {
		SongEvents.WipeSystem ();

        redSong = new Song();
        redSong.audio = redAudioClip;
        redSong.beat = (BeatDetector)gameObject.AddComponent(typeof(BeatDetector));
        redSong.beat.BaseTimeInSecond = 2;
        
        blueSong = new Song();
        blueSong.audio = blueAudioClip;
        blueSong.beat = (BeatDetector)gameObject.AddComponent(typeof(BeatDetector));
        blueSong.beat.BaseTimeInSecond = 2;

        greenSong = new Song();
        greenSong.audio = greenAudioClip;
        greenSong.beat = (BeatDetector)gameObject.AddComponent(typeof(BeatDetector));
        greenSong.beat.BaseTimeInSecond = 1;


        yellowSong = new Song();
        yellowSong.audio = yellowAudioClip;
        yellowSong.beat = (BeatDetector)gameObject.AddComponent(typeof(BeatDetector));
        yellowSong.beat.BaseTimeInSecond = 1;
    }

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
                audio.clip = redSong.audio;        
            }
            if (songColor == TileType.Blue)
            {
                audio.clip = blueSong.audio;
            }
			if (songColor == TileType.Green) {
				audio.clip = greenSong.audio;
				audio.pitch = 0.75f;
			} else {
				audio.pitch = 1;
			}
            if (songColor == TileType.Yellow)
            {
                audio.clip = yellowSong.audio;
            }

            audio.Play();


        }

    }
}

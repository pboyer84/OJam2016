using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SongEventType
{
    OnSongStarted, OnSongEnded
}

public interface SongListener
{
    void onSongEvent(SongEventType eventType, TileType songType);
}
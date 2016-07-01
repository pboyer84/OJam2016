using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Handles events on inventory changes
public class SongEvents
{

    private List<SongListener> list = new List<SongListener>();

	public static void WipeSystem() {
		get().list.Clear();
	}

    private static SongEvents instance = null;
    private static SongEvents get()
    {
        if (instance == null)
        {
            instance = new SongEvents();
        }

        return instance;
    }

    private SongEvents() { }


    public static void Add(SongListener item)
    {
        if (!get().list.Contains(item))
        {
            get().list.Add(item);
        }
    }

    public static void Remove(SongListener item)
    {
        if (!get().list.Contains(item))
        {
			get().list.Remove(item);
        }
    }

    public static void Occured(SongEventType eventType, TileType songType)
    {
//        Debug.Log("Occured");

        foreach (SongListener item in get().list)
        {
            item.onSongEvent(eventType, songType);
        }
    }
}
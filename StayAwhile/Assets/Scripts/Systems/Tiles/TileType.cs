using System;
using UnityEngine;

public enum TileType
{
	Red,
	Blue,
	Green,
	Yellow
}

public abstract class TileFunc
{
	public static Color toColor(TileType tileType) {
		if(tileType == TileType.Red) {
			return Color.red;
		} else if(tileType == TileType.Blue) {
			return Color.blue;
		} else if(tileType == TileType.Green) {
			return Color.green;
		}  else if(tileType == TileType.Yellow) {
			return Color.yellow;
		}  else {
			return Color.red;
		}
	}

    public static TileType randomType()
    {
        int choice = UnityEngine.Random.Range(1, 4);
        
        if (choice == 1)
        {
            return TileType.Red;
        }
        else if (choice == 2)
        {
            return TileType.Blue;
        }
        else if (choice == 3)
        {
            return TileType.Green;
        }
        else if (choice == 4)
        {
            return TileType.Yellow;
        }
        else {
            return TileType.Red;
        }
    }
}


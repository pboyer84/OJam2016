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
}


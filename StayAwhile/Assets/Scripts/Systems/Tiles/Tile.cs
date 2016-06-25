using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Tile : MonoBehaviour {


	public TileType tileType;


	void Start () {
	

		GetComponent<Renderer> ().material.SetColor ("_Color", TileFunc.toColor(tileType));
	}

	float pulse = 0;

	void Update () {
		pulse += Time.deltaTime * 200.0f;

		if (tileType == TileType.Red) {
			GetComponent<Renderer> ().material.SetFloat ("_Pulse", pulse);

		}
	}
}

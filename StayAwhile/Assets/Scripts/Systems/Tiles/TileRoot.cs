using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class TileRoot : MonoBehaviour {

	public int depth = 0;
    
    void OnTriggerEnter(Collider col) {
      //  Debug.Log("trigger");
		ModuleSystem.generateNext (depth );
	}

}

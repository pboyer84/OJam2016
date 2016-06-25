using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModuleSystem : MonoBehaviour {

	private string filePath = "Assets/Resources/Prefabs/Modules";

	private static ModuleSystem instance = null;
	private static ModuleSystem get() {
		if (instance == null) {

			GameObject found = GameObject.Find ("ModuleSystem");

			if (found) {
				instance = found.GetComponent<ModuleSystem> ();
			}

			if (instance == null) {
				GameObject created = Resources.Load<GameObject> ("Prefabs/Modules/ModuleSystem");
				instance = created.GetComponent<ModuleSystem> ();
			}
		}

		return instance;
	}

	public void Start() {
		generateNext (-1);
	}


	List<TileRoot> roots = new List<TileRoot>();

	int depth = -1;

	public static void generateNext(int depth) {
		while (get().depth - 4 <= depth) {

			get ().depth++;

			GameObject area = Instantiate(Resources.Load<GameObject> ("Prefabs/Modules/1"));
			if (area) {
			//	area.transform.parent = get ().gameObject.transform;
				area.transform.parent = get().gameObject.transform;

				area.transform.position = new Vector3 (0, 0, get ().depth * 70);

				Debug.Log ("aasdasd");

				area.GetComponent<TileRoot> ().depth = get ().depth;

				get ().roots.Add (area.GetComponent<TileRoot> ());
			}

		}

	}
}
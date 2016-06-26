using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModuleSystem : MonoBehaviour {

	private string filePath = "Assets/Resources/Prefabs/Modules";

    public GameObject sphere;

	private static ModuleSystem instance = null;
	public static ModuleSystem get() {
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
        GameObject.Instantiate(sphere);

		generateNext (-1);
        
	}


	List<TileRoot> roots = new List<TileRoot>();

	public int depth = -1;

	public static void generateNext(int depth) {
 //       Debug.Log("Num: " + get().roots.Count);

        while (get().roots.Count > 6)
        {
            GameObject.Destroy(get().roots[0].gameObject);
            get().roots.RemoveAt(0);

            
        }

		while (get().depth <= depth + 1)
        {

            get().depth++;
           

           
         //   generate(-1);
            generate(0);
        }

    }

    private static void generate(int side)
    {
        string chosen = get().depth == 0 ? "0" : Random.Range(1, 10).ToString();


        GameObject area = Instantiate(Resources.Load<GameObject>("Prefabs/Modules/" + chosen));
        if (area)
        {
            area.transform.parent = get().gameObject.transform;

            area.transform.position = new Vector3(side * 70, 0, get().depth * 70);
            area.GetComponent<TileRoot>().depth = get().depth;

            get().roots.Add(area.GetComponent<TileRoot>());
        }
    }
}
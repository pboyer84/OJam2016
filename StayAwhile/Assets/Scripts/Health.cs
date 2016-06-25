using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int Value;
    public Text Display;
    public Image DamageSplash;
    public float DamageSplashDuration = 0.1f;
    private float timer;
	// Update is called once per frame
	void Update () {

        if (Display != null)
        {
            Display.text = Value.ToString();
        }

        

        
	}

    public void DisplayDamageFx()
    {
        if (DamageSplash != null)
        {
            DamageSplash.enabled = true;
            StartCoroutine(WaitThenRemoveDamageSplash());
        }
    }

    IEnumerator WaitThenRemoveDamageSplash()
    {
        yield return new WaitForSeconds(DamageSplashDuration);
        DamageSplash.enabled = false;
        yield return null;   
    }
}

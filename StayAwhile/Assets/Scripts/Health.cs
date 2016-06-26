using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int Value;
    public Text Display;
    public Image DamageSplash;
    public float DamageSplashDuration = 0.1f;
    private float timer;
    private float shakeAmount = 0.3f;
    private float shake = 0f;
    private float decreaseFactor = 2.0f;
    private bool alive = true;

    void Start()
    {
        ConfigureHUDForPlayer();
    }

    // Update is called once per frame
	void Update () {

        if (Value <= 0 && alive)
        {
            alive = false;
            Die();
            StartCoroutine(FallSideways());
        }

        if (Display != null)
        {
            Display.text = Value.ToString();
        }

        if (shake > 0)
        {
            Camera.main.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;

        }
        else
        {
            shake = 0.0f;
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

    public void ShakeCamera()
    {
        shake = 1.0f;
    }

    IEnumerator WaitThenRemoveDamageSplash()
    {
        yield return new WaitForSeconds(DamageSplashDuration);
        DamageSplash.enabled = false;
        yield return null;   
    }

    private void ConfigureHUDForPlayer()
    {
        if (gameObject.tag == "Player")
        {
            GameObject theHUD = GameObject.Find("HUD");
            if (theHUD == null)
            {
                GameObject HUDPrefab = Resources.Load<GameObject>(@"Prefabs/Player/HUD");
                theHUD = GameObject.Instantiate(HUDPrefab);
            }
            HUD foo = theHUD.GetComponent<HUD>();
            Display = foo.HealthValue;
            DamageSplash = foo.DamageSplash;
        }
    }

    public void Die()
    {
        DamageSplash.enabled = true;
        MouseLook mouseControls = GetComponentInChildren<MouseLook>();
        PlayerMove moveControls = GetComponent<PlayerMove>();
        mouseControls.enabled = false;
        moveControls.enabled = false;

    }

    IEnumerator FallSideways()
    {
        int increment = 5;
        Vector3 fallRotation = new Vector3(0f, 0f, increment);

        for (int i = 0; i < 90; i+=increment)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(fallRotation);
        }
    }


}

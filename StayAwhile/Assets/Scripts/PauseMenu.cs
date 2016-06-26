using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PausePanel;

    void Awake()
    {
        PausePanel = GameObject.Find("PausePanel");
        PausePanel.SetActive(false);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetButtonDown("Cancel"))
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
        }
	}

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}

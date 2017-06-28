using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mundo : MonoBehaviour {
    AudioSource _audio;

	void Awake () {
        DontDestroyOnLoad(gameObject);
        _audio = GetComponent<AudioSource>();
	}
	void Update () {
        ReturnToMenu();
	}
    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void ReturnToMenu()
    {
        if(Input.GetButton("Cancel"))
        {
            ChangeScene("Menu");
            _audio.Stop();
        }
    }
}

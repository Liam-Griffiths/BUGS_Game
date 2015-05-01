using UnityEngine;
using System.Collections;

public class Pause_Script : MonoBehaviour 
{
	public Texture pauseUp;
	public Texture pauseDown;
	public Texture resumeUp;
	public Texture resumeDown;
	public GUISkin menuSkin;
	public GameObject pauseMenu;

	public bool paused;


	void Start ()
	{
		paused = false;

	}


	public void pause()
	{
		paused = true;
		pauseMenu.SetActive (true);
		Time.timeScale = 0;
		GetComponent<GUITexture>().texture = resumeUp;
	}

	public void resume()
	{
		paused = false;
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
		GetComponent<GUITexture>().texture = pauseUp;
	}
}

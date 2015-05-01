using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GUIText guiTimer;
	public CastleController castle;
	public float levelTimer;
	private float startTime;


	void Start () 
	{
		castle = GameObject.Find("Castle").GetComponent<CastleController>();
		guiTimer = GameObject.Find("GUI Game Timer").GetComponent<GUIText>();
		guiTimer.fontSize = (int)(Screen.width * 0.03f);
		startTime = Time.time;
	}


	void Update () 
	{
		if(castle.currentHealth <= 0)
		{
			WinScreen();
		}

		float newTime = levelTimer - Time.time + startTime;
		guiTimer.text = ((int)newTime).ToString();

		if(newTime < 0)
		{
			LoseScreen();
		}
	
	}


	private void WinScreen()
	{
		Application.LoadLevel(1);
	}

	
	private void LoseScreen()
	{
		Application.LoadLevel(1);
	}
}

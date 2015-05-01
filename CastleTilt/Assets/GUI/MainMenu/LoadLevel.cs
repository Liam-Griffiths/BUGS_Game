using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
//	public Rect boundary;
	public GUISkin menuSkin;

	// Use this for initialization
	void Start () {
		Debug.Log (Screen.width + " " + Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		int width = Screen.width;
		int height = Screen.height;

		GUI.skin = menuSkin;

		if (GUI.Button(new Rect(0.280f*width, 0.336f*height, 0.500f*width, 0.141f*height), ""))
		{
			Application.LoadLevel("InGame");
		}

		if (GUI.Button(new Rect(0.442f*width, 0.654f*height, 0.221f*width, 0.141f*height), ""))
		{
			Application.LoadLevel("MainMenu");
		}
	}
}

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture[] menuScreens;
	public int menuIndex;
	public GUISkin menuSkin;
	public GUISkin creditsSkin;
//	public Rect boundary;

	// Use this for initialization
	void Start ()
	{
		menuIndex = 0;
		Debug.Log (Screen.width + " " + Screen.height);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnGUI()
	{
		int width = Screen.width;
		int height = Screen.height;

		GUI.skin = menuSkin;
		GUI.skin.button.fontSize = Mathf.FloorToInt (0.035f * width);

		GUI.DrawTexture(new Rect(0, 0, width, height), menuScreens[menuIndex]);

		if (menuIndex == 0)
		{
			GUIUtility.RotateAroundPivot (-20, new Vector2(width / 2, height / 2));

			if (GUI.Button(new Rect(0.204f*width, 0.187f*height, 0.270f*width, 0.125f*height), ""))
			{
				Debug.Log("Let's Play!");
				Application.LoadLevel("InGame");
			}

			if (GUI.Button(new Rect(0.204f*width, 0.397f*height, 0.325f*width, 0.125f*height), ""))
			{
				Debug.Log("How to Play");
				menuIndex = 1;
			}

			if (GUI.Button(new Rect(0.204f*width, 0.612f*height, 0.210f*width, 0.116f*height), ""))
			{
				menuIndex = 2;
			}
		}
		else if (menuIndex == 1)
		{
			GUI.skin = creditsSkin;
			
			if (GUI.Button(new Rect(0.849f*width, 0.763f*height, 0.123f*width, 0.197f*height), ""))
			{
				menuIndex = 0;
			}
		}
		else if (menuIndex == 2)
		{
			GUI.skin = creditsSkin;

			if (GUI.Button(new Rect(0.849f*width, 0.763f*height, 0.123f*width, 0.197f*height), ""))
			{
				menuIndex = 0;
			}
		}
	}
}

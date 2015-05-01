using UnityEngine;
using System.Collections;

public class SoundToggle : MonoBehaviour {
	public Texture soundOnUp;
	public Texture soundOnDown;
	public Texture soundOffUp;
	public Texture soundOffDown;
//	public bool soundOn;

	// Use this for initialization
	void Start ()
	{
//		soundOn = true;
		if (AudioListener.volume == 0)
		{
			GetComponent<GUITexture>().texture = soundOffUp;
		}
		else
		{
			GetComponent<GUITexture>().texture = soundOnUp;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMouseDown()
	{
		if (AudioListener.volume == 1)
		{
			GetComponent<GUITexture>().texture = soundOnDown;
		}
		else
		{
			GetComponent<GUITexture>().texture = soundOffDown;
		}
	}

	void OnMouseUp()
	{
//		soundOn = !soundOn;
		if (AudioListener.volume == 1)
		{
			AudioListener.volume = 0;
			GetComponent<GUITexture>().texture = soundOffUp;
		}
		else
		{
			AudioListener.volume = 1;
			GetComponent<GUITexture>().texture = soundOnUp;
		}
	}
}

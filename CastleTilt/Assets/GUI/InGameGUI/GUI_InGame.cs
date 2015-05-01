using UnityEngine;
using System.Collections;

public class GUI_InGame : MonoBehaviour 
{
	private Pause_Script pauseScript;
	private Spawner spawner;

	// GUI TEXTURES
	public Texture2D small_Active;
	public Texture2D small_Selected;
	public Texture2D small_Unavailable;
	
	public Texture2D medium_Active;
	public Texture2D medium_Selected;
	public Texture2D medium_Unavailable;
	
	public Texture2D heavy_Active;
	public Texture2D heavy_Selected;
	public Texture2D heavy_Unavailable;
	
	public Texture2D cooldown_load;
	Color alphaColor;
	Color opaqueColor;

	float NowTime = 0;

	// button scales

	public float buttonScaleFactor;
	int button_Height;
	int button_Width;
	int button_Pushdown;
	public int button_spacing;

	float heavyNextCast = 0;
	float mediumNextCast = 0;
	float smallNextCast = 0;

	public float heavyCooldown;
	public float mediumCooldown;
	public float smallCooldown;

	public int current_unit; // 0 heavy, 1 medium , 2 smallling

	// Touch Parameters
	public Vector2 touchPosition;
	public float touch_Range = 0.3f; // touches for placement of enemies will occur within 30% of the edges to the left and the right
	protected int minLeft_Range = 0;
	protected int maxLeft_Range; // maximum pixel value;
	protected int minRight_Range;
	protected int maxRight_Range;

	private bool isRight;

	private Transform leftSpawnPoint;
	private Transform rightSpawnPoint;

	
	void Start ()
	{
		spawner = GameObject.Find ("GLOBAL_SCRIPTS").GetComponent<Spawner> ();
		pauseScript = GameObject.Find ("PauseButton").GetComponent<Pause_Script> ();
		leftSpawnPoint = GameObject.Find("SpawnPoint Left").transform;
		rightSpawnPoint = GameObject.Find("SpawnPoint Right").transform;

		alphaColor = GUI.color;
		alphaColor.a = 0.5f;
		opaqueColor = GUI.color;

		heavyNextCast = 0;
		mediumNextCast = 0;
		smallNextCast = 0;
		
		// Calc the touch range for placement of units
		maxLeft_Range = (int)(Screen.width * touch_Range);
		minRight_Range = Screen.width - (int)(Screen.width * touch_Range);
		maxRight_Range = Screen.width;

		ScaleButtons (); // Scale gui buttons to screen size on start
	}


	// Update is called once per frame
	void Update () 
	{
		NowTime = Time.time;
	}


	void ScaleButtons()
	{
		button_Height = (int)(Screen.width * buttonScaleFactor);
		button_Width = button_Height; // make square
		button_Pushdown = (int)(button_Height * 0.18); // push down by half the button width
		button_spacing = (int)(button_Height * 0.1); // space by ten percent of button width
	}

	void OnGUI()
	{
		Event e = Event.current;	

		// CHECK TO DRAW PAUSE BUTTON
		if (pauseScript.paused == true)
		{
			GUI.skin = pauseScript.menuSkin;
			
			int width = Screen.width;
			int height = Screen.height;
			
			GUI.skin = pauseScript.menuSkin;
			GUI.skin.button.fontSize = Mathf.FloorToInt (0.035f * width);
			
			if (GUI.Button(new Rect(0.268f*width, 0.254f*height, 0.334f*width, 0.168f*height), ""))
			{
				pauseScript.resume();
			}
			
			if (GUI.Button(new Rect(0.268f*width, 0.468f*height, 0.315f*width, 0.168f*height), ""))
			{
				Debug.Log("Restarting");
				Time.timeScale = 1;
				Application.LoadLevel((Application.loadedLevelName));
			}
			
			//329, 320, 200, 100
			if (GUI.Button(new Rect(0.268f*width, 0.709f*height, 0.186f*width, 0.168f*height), ""))
			{
				Debug.Log("Main Menu");
				Application.LoadLevel("MenuScene");
			}
		}





		// IF NOT IN PAUSE MENU DRAW OTHER STUFF
		else
		{
			Rect smallButton = new Rect((Screen.width - button_Width) / 2 - (button_Width + button_spacing), button_Pushdown, button_Width, button_Height);
			
			// Select appropriate texture.
			if (NowTime < smallNextCast) 
			{
				GUI.DrawTexture (smallButton, small_Unavailable); // unavailable
				float loadRatio = (smallCooldown - (smallNextCast - NowTime)) / smallCooldown * button_Height;
				Rect cooldownRect = new Rect((Screen.width - button_Width) / 2 - (button_Width + button_spacing), (button_Pushdown + button_Height) - loadRatio, button_Width, loadRatio);
				
				GUI.color = alphaColor;
				GUI.DrawTexture(cooldownRect, cooldown_load);
				GUI.color = opaqueColor;
			} 
			else if (current_unit == 2) 
			{ 
				// hardcoded value, i know bad.
				GUI.DrawTexture (smallButton, small_Selected);
			} 
			else 
			{
				GUI.DrawTexture (smallButton, small_Active);
			}
			
			if (e.type == EventType.MouseDown) 
			{
				if (smallButton.Contains(e.mousePosition))
				{
					if (NowTime > smallNextCast) 
					{
						current_unit = 2; // 2 is the hard coded value for the small unit
					}
					return;
				}
			}
			
			Rect mediumButton = new Rect((Screen.width - button_Width) / 2, button_Pushdown, button_Width, button_Height);
			
			// Select appropriate texture.
			if (NowTime < mediumNextCast) 
			{
				GUI.DrawTexture (mediumButton, medium_Unavailable); // unavailable
				float loadRatio = (mediumCooldown - (mediumNextCast - NowTime)) / mediumCooldown * button_Height;
				Rect cooldownRect = new Rect((Screen.width - button_Width) / 2, (button_Pushdown + button_Height) - loadRatio, button_Width, loadRatio);
				
				GUI.color = alphaColor;
				GUI.DrawTexture(cooldownRect, cooldown_load);
				GUI.color = opaqueColor;
			} 
			else if (current_unit == 1) 
			{ 
				GUI.DrawTexture (mediumButton, medium_Selected);
			} 
			else 
			{
				GUI.DrawTexture (mediumButton, medium_Active);
			}
			
			if (e.type == EventType.MouseDown) 
			{
				if (mediumButton.Contains(e.mousePosition))
				{
					if (NowTime > mediumNextCast) 
					{
						current_unit = 1;	// 1 is the hard coded value for the medium unit
					}
					return;
				}
			}
			
			Rect heavyButton = new Rect((Screen.width - button_Width) / 2 + (button_Width + button_spacing), button_Pushdown, button_Width, button_Height);
			
			// Select appropriate texture.
			if (NowTime < heavyNextCast)
			{
				GUI.DrawTexture (heavyButton, heavy_Unavailable); // unavailable
				float loadRatio = (heavyCooldown - (heavyNextCast - NowTime)) / heavyCooldown * button_Height;
				Rect cooldownRect = new Rect((Screen.width - button_Width) / 2 + (button_Width + button_spacing), (button_Pushdown + button_Height) - loadRatio, button_Width, loadRatio);
				
				GUI.color = alphaColor;
				GUI.DrawTexture(cooldownRect, cooldown_load);
				GUI.color = opaqueColor;
				
			} 
			else if (current_unit == 0) 
			{ 
				// hardcoded value, i know bad.
				GUI.DrawTexture (heavyButton, heavy_Selected);
			} 
			else
			{
				GUI.DrawTexture (heavyButton, heavy_Active);
			}
			
			if (e.type == EventType.MouseDown) 
			{
				if (heavyButton.Contains(e.mousePosition))
				{
					if (NowTime > heavyNextCast) 
					{
						current_unit = 0; // 0 is the hard coded value for the heavy unit

					}
					return;
				}
			}
		}
		// CHECK FOR PAUSE BUTTON PRESS
		if(pauseScript.gameObject.GetComponent<GUITexture>().HitTest(Input.mousePosition))
		{
			if(e.type == EventType.MouseDown)
			{
				if (pauseScript.paused)
				{
					pauseScript.gameObject.GetComponent<GUITexture>().texture = pauseScript.resumeDown;
				}
				else
				{
					pauseScript.gameObject.GetComponent<GUITexture>().texture = pauseScript.pauseDown;
				}
			}
			if(e.type == EventType.mouseUp)
			{

				if (pauseScript.paused)
				{
					pauseScript.resume();
				}
				else
				{
					pauseScript.pause();
				}
			}
			return;
		}
			
		if(e.type == EventType.MouseDown && pauseScript.paused == false)
		{
			
			//touchPosition = Input.GetTouch(0)|'/p;.position;
			touchPosition.x = Input.mousePosition.x;
			touchPosition.y = Input.mousePosition.y;
			
			if((touchPosition.x > minLeft_Range) && (touchPosition.x < maxLeft_Range)) // check for left touch
			{
				isRight = false;
				Unit_Spawn(leftSpawnPoint); // spawn on the left transform
			}
			
			if((touchPosition.x > minRight_Range) && (touchPosition.x < maxRight_Range)) // check for right touch
			{
				isRight = true;
				Unit_Spawn(rightSpawnPoint); // spawn on the right transform
			}
		}
	}

	void Unit_Spawn(Transform _spawnPoint)
	{
		switch (current_unit)
		{
		case 2:
			if (NowTime > smallNextCast)
			{
				spawner.SpawnSmall(_spawnPoint, isRight);
				smallNextCast = smallCooldown + NowTime;
			}
			break;
		case 1:
			if (NowTime > mediumNextCast)
			{
				spawner.SpawnMedium(_spawnPoint, isRight);
				mediumNextCast = mediumCooldown + NowTime;
			}
			break;
		case 0:
			if (NowTime > heavyNextCast)
			{
				spawner.SpawnHeavy(_spawnPoint, isRight);
				heavyNextCast = heavyCooldown + NowTime;
			}
			break;
		}
	}
}

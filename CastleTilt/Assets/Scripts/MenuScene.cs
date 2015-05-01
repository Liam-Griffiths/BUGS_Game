using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void LoadMenu(){
		Application.LoadLevel("MenuScene");
	}

	public void LoadGame(){
		Application.LoadLevel("InGame");
	}

	public void LoadBattle(){
		Application.LoadLevel("GameScene");
	}

	public void LoadCredits(){
		Application.LoadLevel("CreditsScene");
	}

	public void LoadTutorial(){
		Application.LoadLevel("TutorialScene");
	}

	public void LoadOptions(){
		Application.LoadLevel("OptionsScene");
	}
}

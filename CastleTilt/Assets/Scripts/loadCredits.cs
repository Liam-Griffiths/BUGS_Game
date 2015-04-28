using UnityEngine;
using System.Collections;

public class loadCredits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void LoadCredits(){
		Application.LoadLevel("CreditsScene");
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// quick and dirty, i know

public class CastleSelection : MonoBehaviour {

	private GameObject SelectedCastle;
	public GameObject EasyPrefab;
	public GameObject MediumPrefab;
	public GameObject HardPrefab;

	// Use this for initialization
	void Start () {

	}

	public void SelectEasy()
	{
		SelectedCastle = EasyPrefab;
	}

	public void SelectMedium()
	{
		SelectedCastle = MediumPrefab;
	}

	public void SelectHard()
	{
		SelectedCastle = HardPrefab;
	}

	public GameObject FindCastle()
	{
		return SelectedCastle;
	}
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSelection : MonoBehaviour {

	[System.Serializable] public struct Units
	{	
		public string unitName;
		public GameObject prefab;
		public int cooldownSeconds;
		public int count;
	}

	public List<Units> UnitList; // all possible units
	public List<Units> SelectedUnits; // units seleted by payer to send to the object manager

	// Use this for initialization
	void Start () {
	
	}

	// gui needs to select the units you want but this function selects them placeholder
	void TestingSelection()
	{
		SelectedUnits.Add(UnitList [0]);
		SelectedUnits.Add(UnitList [1]);
		SelectedUnits.Add(UnitList [2]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

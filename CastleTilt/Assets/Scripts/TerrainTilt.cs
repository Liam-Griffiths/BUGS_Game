using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainTilt : MonoBehaviour 
{
	public List<GameObject> UnitArrayLeft;
	public List<GameObject> UnitArrayRight;
	public List<UnitController> ControllersLeft;
	public List<UnitController> ControllersRight;

	private float totalWeight;


	void Start()
	{
		UnitArrayLeft = new List<GameObject>();
		UnitArrayRight = new List<GameObject>();
		ControllersLeft = new List<UnitController>();
		ControllersRight = new List<UnitController>();
	}


	void Update ()
	{
		totalWeight = 0;

		// Remove Dead Units
		for (int i = 0; i < UnitArrayLeft.Count; i++)
		{
			if(UnitArrayLeft[i].transform.parent == null)
			{
				ControllersLeft.RemoveAt(i);
				UnitArrayLeft.RemoveAt(i);
			}
		}
		for (int i = 0; i < UnitArrayRight.Count; i++)
		{
			if(UnitArrayRight[i].transform.parent == null)
			{
				ControllersRight.RemoveAt(i);
				UnitArrayRight.RemoveAt(i);
			}
		}

		// Calculate weight
		for (int i = 0; i < UnitArrayLeft.Count; i++)
		{
			totalWeight += UnitArrayLeft[i].GetComponent<UnitController>().weight;
		}
		for (int i = 0; i < UnitArrayRight.Count; i++)
		{
			totalWeight += UnitArrayRight[i].GetComponent<UnitController>().weight;
		}

		Quaternion newRot = Quaternion.Euler(-totalWeight + 0, 180, 0);
		gameObject.transform.rotation = Quaternion.Lerp (gameObject.transform.rotation, newRot, 0.1f);

		//Debug.Log (totalWeight);

		// Change Speeds
		for (int i = 0; i < UnitArrayLeft.Count; i++)
		{
			ControllersLeft[i].currentSpeed = ControllersLeft[i].defaultSpeed + (ControllersLeft[i].defaultSpeed * totalWeight/11);
		}
		for (int i = 0; i < UnitArrayRight.Count; i++)
		{
			ControllersRight[i].currentSpeed = ControllersRight[i].defaultSpeed + (ControllersRight[i].defaultSpeed * totalWeight/11 * (-1));
		}

	}

}

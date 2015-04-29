using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CastleController : MonoBehaviour 
{

	[System.Serializable] public class TargetUnit
	{
		public bool isBeingTargetted;
		public GameObject prefab;
	}

	public List<TargetUnit> leftUnits;
	public List<TargetUnit> rightUnits;
	public List<UnitController> ControllersLeft;
	public List<UnitController> ControllersRight;

	public float currentHealth;
	public float maxHealth;

	private GameObject GUICastleHealth;

	void Start () 
	{
		leftUnits = new List<TargetUnit>();
		rightUnits = new List<TargetUnit>();
		ControllersLeft = new List<UnitController>();
		ControllersRight = new List<UnitController>();

		GUICastleHealth = GameObject.Find ("GUICastleHealth");
		currentHealth = maxHealth;
	}


	public void AddUnit(GameObject inputPrefab, int spawnSide)
	{
		// 0 spawnSide is left, 1 is right
		if(spawnSide == 0)
		{
			TargetUnit newObj = new TargetUnit();
			newObj.prefab = inputPrefab;
			newObj.isBeingTargetted = false;
			leftUnits.Add(newObj);
			ControllersLeft.Add(newObj.prefab.GetComponent<UnitController>());
		}

		if(spawnSide == 1)
		{
			TargetUnit newObj = new TargetUnit();
			newObj.prefab = inputPrefab;
			newObj.isBeingTargetted = false;
			rightUnits.Add(newObj);
			ControllersRight.Add(newObj.prefab.GetComponent<UnitController>());
		}
	}


	/*public void RemoveUnit(GameObject removePrefab, int spawnSide)
	{
		// 0 spawnSide is left, 1 is right
		if(spawnSide == 0)
		{
			foreach(TargetUnit current in leftUnits)
			{
				if(current.prefab == removePrefab)
				{
					leftUnits.Remove(current);
				}
			}
		}
		
		if(spawnSide == 1)
		{
			foreach(TargetUnit current in rightUnits)
			{
				if(current.prefab == removePrefab) 
				{
					rightUnits.Remove(current);
				}
			}
		}
	}

	*/


	void Update()
	{
		for (int i = 0; i < leftUnits.Count; i++)
		{
			if(ControllersLeft[i].isDead == true)
			{
				leftUnits.RemoveAt(i);
				ControllersLeft.RemoveAt(i);
			}
		}
		for (int i = 0; i < rightUnits.Count; i++)
		{
			if(ControllersRight[i].isDead == true)
			{
				rightUnits.RemoveAt(i);
				ControllersRight.RemoveAt(i);
			}
		}
	}


	public void TakeDamage(int damageTaken)
	{
		currentHealth -= damageTaken;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);

		float percentage = currentHealth / maxHealth;
		GUICastleHealth.transform.localScale = new Vector3 (percentage * 0.2f, GUICastleHealth.transform.localScale.y, GUICastleHealth.transform.localScale.z);
		GUICastleHealth.transform.position = new Vector3 (0.505f - ((1 - percentage) * 0.07f), GUICastleHealth.transform.position.y, GUICastleHealth.transform.position.z);
	}
}

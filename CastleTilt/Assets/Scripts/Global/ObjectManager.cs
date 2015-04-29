/*
 * 
 * 
 *	Author: Bogdan Predscu
 *  Description: Instantiates objects on load to improve performance on mobile platforms. 
 * 
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour 
{
	[System.Serializable] public struct ObjectToManage
	{
		public GameObject prefab;
		public int count;
	}
	public ObjectToManage small;
	public ObjectToManage medium;
	public ObjectToManage big;
	public ObjectToManage arrow;
	public ObjectToManage castleArrow;

	private List<GameObject> smallUnits;
	private List<GameObject> mediumUnits;
	private List<GameObject> bigUnits;
	private List<GameObject> ballistaBullets;
	private List<GameObject> castleBullets;


	void Start () 
	{
		smallUnits = new List<GameObject>();
		mediumUnits = new List<GameObject>();
		bigUnits = new List<GameObject>();
		ballistaBullets = new List<GameObject>();
		castleBullets = new List<GameObject>();

		for (int i=0; i<small.count; i++)
		{
			GameObject myObj = (GameObject)Instantiate(small.prefab, Vector3.zero, Quaternion.identity);
			myObj.SetActive(false);
			smallUnits.Add(myObj);
		}

		for (int i=0; i<medium.count; i++)
		{
			GameObject myObj = (GameObject)Instantiate(medium.prefab, Vector3.zero, Quaternion.identity);
			myObj.SetActive(false);
			mediumUnits.Add(myObj);
		}

		for (int i=0; i<big.count; i++)
		{
			GameObject myObj = (GameObject)Instantiate(big.prefab, Vector3.zero, Quaternion.identity);
			myObj.SetActive(false);
			bigUnits.Add(myObj);
		}
		
		for (int i=0; i<arrow.count; i++)
		{
			GameObject myObj = (GameObject)Instantiate(arrow.prefab, Vector3.zero, Quaternion.identity);
			myObj.SetActive(false);
			ballistaBullets.Add(myObj);
		}

		for (int i=0; i<castleArrow.count; i++)
		{
			GameObject myObj = (GameObject)Instantiate(castleArrow.prefab, Vector3.zero, Quaternion.identity);
			myObj.SetActive(false);
			castleBullets.Add(myObj);
		}
	}


	public GameObject GetSmall() 
	{
		for(int i=0; i<small.count; i++)
		{
			if(!smallUnits[i].activeInHierarchy)
			{
				return smallUnits[i];
			}
		}
		Debug.LogError("YOU NEED MORE Small");
		// Add Extra Unit
		GameObject myObj = (GameObject)Instantiate(small.prefab, Vector3.zero, Quaternion.identity);
		myObj.SetActive(false);
		smallUnits.Add(myObj);
		small.count++;

		return smallUnits[small.count - 1];
	}

	public GameObject GetMedium() 
	{
		for(int i=0; i<medium.count; i++)
		{
			if(!mediumUnits[i].activeInHierarchy)
			{
				return mediumUnits[i];
			}
		}

		// Add Extra Unit
		GameObject myObj = (GameObject)Instantiate(medium.prefab, Vector3.zero, Quaternion.identity);
		myObj.SetActive(false);
		mediumUnits.Add(myObj);
		medium.count++;
		
		return mediumUnits[medium.count - 1];
	}

	public GameObject GetBig() 
	{
		for(int i=0; i<big.count; i++)
		{
			if(!bigUnits[i].activeInHierarchy)
			{
				return bigUnits[i];
			}
		}

		// Add Extra Unit
		GameObject myObj = (GameObject)Instantiate(big.prefab, Vector3.zero, Quaternion.identity);
		myObj.SetActive(false);
		bigUnits.Add(myObj);
		big.count++;
		
		return bigUnits[big.count - 1];
	}


	public GameObject GetBallistaArrow() 
	{
		for(int i=0; i<arrow.count; i++)
		{
			if(!ballistaBullets[i].activeInHierarchy)
			{
				return ballistaBullets[i];
			}
		}
		
		// Add Extra Unit
		GameObject myObj = (GameObject)Instantiate(arrow.prefab, Vector3.zero, Quaternion.identity);
		myObj.SetActive(false);
		ballistaBullets.Add(myObj);
		arrow.count++;
		
		return ballistaBullets[arrow.count - 1];
	}

	public GameObject GetCastleArrow() 
	{
		for(int i=0; i<castleArrow.count; i++)
		{
			if(!castleBullets[i].activeInHierarchy)
			{
				return castleBullets[i];
			}
		}
		
		// Add Extra Unit
		GameObject myObj = (GameObject)Instantiate(castleArrow.prefab, Vector3.zero, Quaternion.identity);
		myObj.SetActive(false);
		castleBullets.Add(myObj);
		castleArrow.count++;
		
		return castleBullets[castleArrow.count - 1];
	}
}

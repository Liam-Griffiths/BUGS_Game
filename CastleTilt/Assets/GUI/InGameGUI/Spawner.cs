/*
 * 
----- Name: Brains Eden, Unit Spawn Script
----- Date: 05/07/2014
----- Author: Liam Griffiths.
----- Known Bugs: Clunky, but faster to write.

*/

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	private ObjectManager objManager;
	private CastleController castle;
	private GameObject terrain;
	private Transform leftSpawnPoint;
	private Transform rightSpawnPoint;
	


	// Use this for initialization
	void Start () 
	{
		// Instantiate References
		objManager = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<ObjectManager>();
		terrain = GameObject.Find("Ground");
		castle = GameObject.Find ("Castle").GetComponent<CastleController> ();
	}


	public void SpawnSmall(Transform _spawnPoint, bool _isRight)
	{
		GameObject myObj = objManager.GetSmall();
		myObj.transform.position = _spawnPoint.position + new Vector3(0, 0, Random.Range(-1.0f, 1.0f));
		myObj.transform.rotation = _spawnPoint.rotation;
		myObj.transform.parent = terrain.transform;
		myObj.GetComponent<Rigidbody>().useGravity = false;
		myObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		if(_isRight)
		{
			terrain.GetComponent<TerrainTilt>().UnitArrayRight.Add(myObj);
			terrain.GetComponent<TerrainTilt>().ControllersRight.Add(myObj.GetComponent<UnitController>());
			castle.AddUnit(myObj, 1);
		}
		else
		{
			terrain.GetComponent<TerrainTilt>().UnitArrayLeft.Add(myObj);
			terrain.GetComponent<TerrainTilt>().ControllersLeft.Add(myObj.GetComponent<UnitController>());
			castle.AddUnit(myObj, 0);
		}
		myObj.SetActive(true);
	}

	public void SpawnMedium(Transform _spawnPoint, bool _isRight)
	{
		GameObject myObj = objManager.GetMedium();
		myObj.transform.position = _spawnPoint.position + new Vector3(0, 0, Random.Range(-1.0f, 1.0f));
		myObj.transform.rotation = _spawnPoint.rotation;
		myObj.transform.parent = terrain.transform;
		myObj.GetComponent<Rigidbody>().useGravity = false;
		myObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		if(_isRight)
		{
			terrain.GetComponent<TerrainTilt>().UnitArrayRight.Add(myObj);
			terrain.GetComponent<TerrainTilt>().ControllersRight.Add(myObj.GetComponent<UnitController>());
			castle.AddUnit(myObj, 1);
		}
		else
		{
			terrain.GetComponent<TerrainTilt>().UnitArrayLeft.Add(myObj);
			terrain.GetComponent<TerrainTilt>().ControllersLeft.Add(myObj.GetComponent<UnitController>());
			castle.AddUnit(myObj, 0);
		}
		myObj.SetActive(true);
	}

	public void SpawnHeavy(Transform _spawnPoint, bool _isRight)
	{
		GameObject myObj = objManager.GetBig();
		myObj.transform.position = _spawnPoint.position + new Vector3(0, 0, Random.Range(-1.0f, 1.0f));
		myObj.transform.rotation = _spawnPoint.rotation;
		myObj.transform.parent = terrain.transform;
		myObj.GetComponent<Rigidbody>().useGravity = false;
		myObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		if(_isRight)
		{
			terrain.GetComponent<TerrainTilt>().UnitArrayRight.Add(myObj);
			terrain.GetComponent<TerrainTilt>().ControllersRight.Add(myObj.GetComponent<UnitController>());
			castle.AddUnit(myObj, 1);
		}
		else
		{
			terrain.GetComponent<TerrainTilt>().UnitArrayLeft.Add(myObj);
			terrain.GetComponent<TerrainTilt>().ControllersLeft.Add(myObj.GetComponent<UnitController>());
			castle.AddUnit(myObj, 0);
		}
		myObj.SetActive(true);
	}
}

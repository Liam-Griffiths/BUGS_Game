using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirePoint : MonoBehaviour 
{

	public GameObject targetObject = null; 
	public GameObject projectile;

	public int fireDirection;

	public float fireRate;
	float timer;

	CastleController castleScript;

	// Use this for initialization
	void Start () 
	{
		castleScript = transform.parent.gameObject.GetComponent<CastleController>();
	}

	void GetTarget()
	{
		if(fireDirection == 0)
		{
			for(int i=0; i<castleScript.leftUnits.Count; i++)
			{
				if(castleScript.leftUnits[i].isBeingTargetted != true)
				{
					castleScript.leftUnits[i].isBeingTargetted = true;
					targetObject = castleScript.leftUnits[i].prefab;
					break;
				}
			}
		}

		if(fireDirection == 1)
		{
			for(int i=0; i<castleScript.rightUnits.Count; i++)
			{
				if(castleScript.rightUnits[i].isBeingTargetted != true) 
				{
					castleScript.rightUnits[i].isBeingTargetted = true;
					targetObject = castleScript.rightUnits[i].prefab;
					break;
				}
			}
		}
	}

	void CheckTarget()
	{
		if(targetObject != null)
		{
			if(fireDirection == 0)
			{
				bool flag = false;

				for(int i=0; i<castleScript.leftUnits.Count; i++)
				{
					if(castleScript.leftUnits[i].prefab == targetObject) // might not be finding the prefab, therefore everything gets targettedS
					{
						flag = true;
					}
				}

				if(flag == false)
				{
					targetObject = null;
				}
			}
			
			if(fireDirection == 1)
			{
				bool flag = false;
				
				for(int i=0; i<castleScript.rightUnits.Count; i++)
				{
					if(castleScript.rightUnits[i].prefab == targetObject)
					{
						flag = true;
					}
				}

				if(flag == false)
				{
					targetObject = null;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		//transform.LookAt(targetObject.transform);

		timer += Time.deltaTime;
		//CheckTarget();
		if(timer > fireRate)
		{

			CheckTarget();

			if(targetObject == null)
			{
				GetTarget();
			}
			else
			{
				GameObject firedProjectile; 
				firedProjectile = Instantiate (projectile, transform.position, transform.rotation) as GameObject;

				HomingProjectile projScript = (HomingProjectile)firedProjectile.GetComponent("HomingProjectile"); // Get script.
				projScript.target = targetObject;

				timer = 0; // reset timer for fire rate
			}
		}

	}
}

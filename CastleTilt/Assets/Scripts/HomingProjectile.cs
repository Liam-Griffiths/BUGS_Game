using UnityEngine;
using System.Collections;

public class HomingProjectile : MonoBehaviour
{

	public float speed;
	public int damage;

	public GameObject impactParticles;
	
	public GameObject target;
	

	void Update ()
	{
		transform.position += transform.forward* speed * Time.deltaTime;
		transform.LookAt(target.transform); // Homes the projectile.
	}


	void OnTriggerEnter(Collider other) 
	{
		GameObject instance = Instantiate (impactParticles, transform.position, Quaternion.Inverse(transform.rotation)) as GameObject;
		if(other.gameObject.layer == 9)
		{
			other.GetComponent<UnitController>().TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}

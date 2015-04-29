using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed;
	public int damage;
	private CastleController castle;

	public GameObject impactParticles;

	// Use this for initialization
	void Start ()
	{
		castle = GameObject.Find("Castle").GetComponent<CastleController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == 11)
		{
			GameObject instance = Instantiate (impactParticles, transform.position, Quaternion.Inverse(transform.rotation)) as GameObject;
			castle.TakeDamage (damage);
			Debug.Log ("Hide");
			gameObject.SetActive (false);
		}

	}


}

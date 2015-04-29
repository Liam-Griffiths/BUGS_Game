using UnityEngine;
using System.Collections;

public class ParticleDestroyDelay : MonoBehaviour {

	private ParticleSystem particles;


	public void Start() 
	{
		particles = GetComponent<ParticleSystem>();
	}

	public void Update() 
	{
		if(particles)
		{
			if(!particles.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}

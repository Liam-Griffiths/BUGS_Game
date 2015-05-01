using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour 
{
	public float currentHealth;
	public float maxHealth;
	public float defaultSpeed;
	public float currentSpeed;
	public int damage;
	public float weight;
	public float maxWeight;
	public float attackCooldown;
	private float nextAttack;
	public GameObject projectile;
	private Animator anim;
	private ObjectManager objManager;
	private CastleController castle;
	//private GameObject terrain;
	public bool isRanged;
	public GameObject deathEffect;

	public string state;
	public bool isDead;
	public float killTime;

	private AudioSource sound;
	public AudioClip[] attack;
	public AudioClip move;
	

	void Start()
	{
		objManager = GameObject.Find("GLOBAL_SCRIPTS").GetComponent<ObjectManager>();
		castle = GameObject.Find("Castle").GetComponent<CastleController>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void OnEnable ()
	{
		//terrain = GameObject.Find("Ground");
		isDead = false;
		anim = GetComponent<Animator>();
		anim.enabled = true;
		state = "moving";
		nextAttack = 0;
		currentHealth = maxHealth;
		sound = GetComponent<AudioSource> ();
		sound.clip = move;
		sound.loop = true;
		sound.volume = 0.5f;
		sound.Play ();
		if (isRanged)
		{
			state = "attacking";
		}

		anim.SetBool ("Walk", true);
		anim.SetBool ("Attack", false);
		anim.SetBool ("Dead", false);

	}
	

	void Update ()
	{
		float dist = Vector3.Distance (transform.position, Vector3.zero);
		if(isDead == true && Time.time > killTime)
		{
			KillUnit();
			return;
		}

		if (dist > 15 && isDead == false)
		{
			state = "move";
			transform.parent = null;
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			anim.enabled = false;
			isDead = true;
			killTime = Time.time + 5;
		}
		else if(isDead == false)
		{
			GetComponent<Rigidbody>().velocity = transform.forward * currentSpeed + transform.up * (-5);
			weight = transform.position.x / 20 * maxWeight + Mathf.Sign(transform.position.x) * maxWeight / 2;
			//currentSpeed = 30 * transform.rotation.z;
		}

		if (state == "attacking")
		{
			if (Time.time > nextAttack)
			{
				if (isRanged)
				{
					rangeAttack();
				}
				else
				{
					meleeAttack();
				}

				nextAttack = Time.time + attackCooldown;
			}
				
		}	
	}


	void rangeAttack()
	{
		GameObject myObj = objManager.GetBallistaArrow();
		myObj.transform.position = transform.position;
		myObj.transform.rotation = transform.rotation * Quaternion.Euler (-20, 0, 0);
		myObj.SetActive(true);
		Debug.Log ("Show");

		sound.clip = attack [Mathf.FloorToInt (Random.value * attack.Length)];
		sound.loop = false;
		sound.Play();

		anim.SetBool ("Walk", false);
		anim.SetBool ("Attack", true);
		anim.SetBool ("Dead", false);

	}

	void LateUpdate()
	{
		if(isDead == false)
		{
			anim.SetBool ("Walk", true);
			anim.SetBool ("Attack", false);
			anim.SetBool ("Dead", false);
		}
	}


	void meleeAttack()
	{
		castle.TakeDamage(damage);
		int rValue = Random.Range (0, attack.Length-1);
		Debug.Log (rValue);
		sound.clip = attack [rValue];
		if (gameObject.name == "Ram Prefab(Clone)")
		{
			sound.volume = 1;
		}
		sound.loop = false;
		sound.Play();

		anim.SetBool ("Walk", false);
		anim.SetBool ("Attack", true);
		anim.SetBool ("Dead", false);
	}
	


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			Debug.Log ("Attacking");
			state = "attacking";
		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			Debug.Log ("Moving");
			state = "moving";
		}
	}

	public void TakeDamage(int damageTaken)
	{
		currentHealth -= damageTaken;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);

		if (currentHealth <= 0)
		{
			if(isDead == false)
			{
				anim.SetBool ("Walk", false);
				anim.SetBool ("Attack", false);
				anim.SetBool ("Dead", true);

				//transform.parent = null;
				//rigidbody.useGravity = true;
				//rigidbody.constraints = RigidbodyConstraints.None;
				//anim.enabled = false;
				//rigidbody.velocity  =  Vector3.zero;
				state = "move";
				isDead = true;
				killTime = Time.time + 5;
			}
		}
	}


	private void KillUnit()
	{
		GameObject instance = Instantiate (deathEffect, transform.position, Quaternion.identity) as GameObject;
		transform.parent = null;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		anim.enabled = false;
		gameObject.SetActive (false);

	}
}

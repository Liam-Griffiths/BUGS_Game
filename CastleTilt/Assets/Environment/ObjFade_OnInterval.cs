using UnityEngine;
using System.Collections;

/*
 *  Author: Liam Griffiths.
 * 
 *  Fading in and out on an interval.
 *  If you have a problem set your material to "Transparent/Diffuse"
 * 
 */

public static class ExtensionMethods {
	
	public static void SetAlpha (this Material material, float value) {
		Color color = material.color;
		color.a = value;
		material.color = color;
	}
	
}

public class ObjFade_OnInterval : MonoBehaviour {

	public float fireRate = 25.0f;
	public float timer;

	public float fadeRate = 0.5f;

	bool fading = false;
	bool faded_in = false;

	float alpha_val = 0.0f;

	void Start () 
	{
		GetComponent<Renderer>().material.SetAlpha(alpha_val);
	}
	
	void Update () {
		
		timer += Time.deltaTime;

		if(fading == true)
		{
			Debug.Log("Fading." + alpha_val);
			if(faded_in == false)
			{
				// fade in
				if(alpha_val >= 1.0f)
				{
					faded_in = true;
				}
				else
				{
					alpha_val = alpha_val + (fadeRate * Time.deltaTime);
					GetComponent<Renderer>().material.SetAlpha(alpha_val);
				}
			}
			else
			{
				// fade out
				if(alpha_val <= 0.0f)
				{
					faded_in = false;
					fading = false;

					alpha_val = 0.0f;

					GetComponent<Renderer>().material.SetAlpha(alpha_val);
				}
				else
				{
					alpha_val = alpha_val - (fadeRate * Time.deltaTime);
					GetComponent<Renderer>().material.SetAlpha(alpha_val);
				}
			}
		}
		else if(timer > fireRate)
		{
			fading = true;
			timer = 0; // reset timer for fire rate
		}
		
	}
}


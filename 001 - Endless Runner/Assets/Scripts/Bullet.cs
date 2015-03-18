using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float Speed = 16;
	public float Range = 16;

	float distance;
	float timeToDie;

	void Update () {

		transform.Translate (Speed*Time.deltaTime, 0, 0);	
		distance += Speed * Time.deltaTime;

		if ((distance > Range) || (timeToDie < Time.time))
						gameObject.Recycle ();

	}

	void OnEnable()
	{
		distance = 0;
		timeToDie =  float.PositiveInfinity;
	}


	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy") 
		{
			timeToDie = Time.time+0.1f;
		}
	}

}

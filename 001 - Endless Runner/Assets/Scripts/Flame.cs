using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {

	public float damageRate;

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") 
		{
			collider.gameObject.GetComponent<Health>().InflictDamage(damageRate*Time.deltaTime);
		}
	}
}

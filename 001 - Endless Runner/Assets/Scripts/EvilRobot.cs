using UnityEngine;
using System.Collections;

public class EvilRobot : MonoBehaviour {

	public GameObject smokePrefab;
	public GameObject firePrefab;
	public Transform muzzle;

	bool shouldBeDisposed;
	float timeToDie = float.PositiveInfinity;
	GameObject fire;


	void Start()
	{
		fire = Instantiate (firePrefab, muzzle.position, Quaternion.identity) as GameObject;
	}

	void Update () {

		if (Time.time > timeToDie) 
		{
			Destroy(gameObject);
			Destroy(fire);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PlayerBullet") 
		{
			timeToDie = Time.time+0.1f;
			Instantiate(smokePrefab,this.transform.position,Quaternion.identity);
			Balance.DepositMoney();
		}
	}	
}

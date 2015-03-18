using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public Transform player;
	public Vector2 offset;

	void FixedUpdate ()
	{
		TrackPlayer();
	}
	
	
	void TrackPlayer ()
	{
		transform.position = new Vector3(player.transform.position.x+offset.x, player.transform.position.y+offset.y, transform.position.z);
	}

}

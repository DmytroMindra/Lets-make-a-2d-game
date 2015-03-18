using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {

	public float maxY = 0.5415f;
	public float minY = -1;
	public float defaultY = -0.54518f;

	public GameObject aimIK;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float totalPositiveAxis = System.Math.Abs (maxY-defaultY);
		float totalNegativeAxis = System.Math.Abs (minY - defaultY);

		Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);
		
		var mouse_pos = Input.mousePosition;
		
		mouse_pos.x = mouse_pos.x - player_pos.x;
		mouse_pos.y = mouse_pos.y - player_pos.y;

		float angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		float angleNormal = angle / 90f;

		float y = 0;


		if (angle > 0) 
		{
			y = defaultY+(totalPositiveAxis * angleNormal);
			if (y>maxY) y=maxY;
		} 
			else 
		{
			y = defaultY-(totalNegativeAxis * angleNormal);
			if (y<minY) y = minY;
		}

		var position = aimIK.transform.localPosition;
		aimIK.transform.localPosition = new Vector3 (position.x, y, position.z);;
	}
}

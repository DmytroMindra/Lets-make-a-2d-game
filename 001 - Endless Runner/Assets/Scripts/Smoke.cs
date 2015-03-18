using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

	void OnAnimationEnd()
	{
		gameObject.SetActive (false);
	}
}

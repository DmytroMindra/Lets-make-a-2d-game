using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Balance : MonoBehaviour {
	
	public static int Current {get; set; }
	public static int Best {get; set;}
	public static void DepositMoney()
	{
		Current += 10;
	}
	
	public void DisplayBalance(){
		gameObject.GetComponent<Text>().text = Current + "$";
	}

	public void Update()
	{
		DisplayBalance();
		TrackBestBalance();
	}

	private void TrackBestBalance()
	{
		if (Current > Best)
			Best = Current;
	}
}

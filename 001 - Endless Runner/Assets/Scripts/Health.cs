using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public GameObject healthBar;

	float health = 100;

	public void InflictDamage(float damage) {
		health -= damage;
	}

	public void DisplayHealth(){
		healthBar.GetComponent<Slider>().value = health;
	}

	void Update() {
		DisplayHealth();
	}

	public void RestoreHealth(){
		health = 100;
	}

	public bool isDead() {
		if (health <= 0)
			return true;
		return false;
	}
}

using UnityEngine;
using System.Collections;

public class CharacterPicker : MonoBehaviour {
	
	public GameObject selectedCharacter;
	public GameObject hero;
	
	public Sprite character1;
	public Sprite character2;
	public Sprite character3;
	
	public void SelectCharacter(GameObject go) {
		Debug.Log(go.name);
		var spriteRenderer = hero.GetComponent<SpriteRenderer> ();
		if (go.name == "Character1")
			spriteRenderer.sprite = character1;
		if (go.name == "Character2")
			spriteRenderer.sprite = character2;
		if (go.name == "Character3")
			spriteRenderer.sprite = character3;
	}
}

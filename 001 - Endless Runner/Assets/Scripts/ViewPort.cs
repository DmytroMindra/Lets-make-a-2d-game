using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewPort : MonoBehaviour {

	public Sprite viewPort;
	public void SelectViewPort() {
		var image = gameObject.GetComponent<Image>();
		image.sprite = (image.sprite == null) ? viewPort : null;
	}
}

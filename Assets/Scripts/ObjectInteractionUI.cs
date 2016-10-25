/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectInteractionUI : MonoBehaviour {

	private bool UIShow = false;
	private string woodenSignText;

	GUIStyle style;
	GUIText.TextAnchor.MiddleCenter;
	style.alignment = TextAnchor.MiddleCenter;

	FIXME_VAR_TYPE w= 0.3f; // proportional width (0..1)
	FIXME_VAR_TYPE h= 0.2f; // proportional height (0..1)
	private Rect rect;
	rect.x = (Screen.width*(1-w))/2;
	rect.y = (Screen.height*(1-h))/2;
	rect.width = Screen.width*w;
	rect.height = Screen.height*h;

	// Use this for initialization
	void Start () {
		woodenSignText = "The world famous tree of life";
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Player entered the box");
		if (other.CompareTag ("Player")) {
			Debug.Log ("You're seeing a Wooden Sign");
			UIShow = true;
		}
	}
		
	/*void OnTriggerStay (Collider other) {
		if (other.CompareTag ("Player")) {
			UIShow = true;
		}

	}

	void OnTriggerExit (Collider other) {
		Debug.Log ("Player exited the box");
		if (other.CompareTag ("Player")) {
			UIShow = false;
		}
	}

	void OnGUI() {
		if (UIShow == true) {
			GUI.Label(rect, woodenSignText, style);
		}
	}
}*/


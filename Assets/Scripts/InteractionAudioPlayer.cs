/*using UnityEngine;
using System.Collections;

public class InteractionAudioPlayer : MonoBehaviour {
	AudioSource asrc;
	RaycastHit whatIHit;
	private float distanceToSee = 1.5f;

	void Start()
	{
		asrc = GetComponent(typeof(AudioSource)) as AudioSource;
	}

	void Update () {
		if (Physics.Raycast (this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {
			if (asrc != null && Input.GetKeyDown (KeyCode.E)) {
				asrc.Play();
			}
		}
	}

}*/
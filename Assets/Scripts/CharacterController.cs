using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float speed  = 10.0F;
	// Transform targetMesh;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		/* if(Input.GetButton("LeftShift"))
		{
			targetMesh.localScale = new Vector3(1,0.5f,1);
		}
		else
		{
			targetMesh.localScale = new Vector3(1,1,1);
		}*/
		
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;

		translation = translation * Time.deltaTime;
		straffe = straffe * Time.deltaTime;

		transform.Translate (straffe, 0, translation);

		//if (Input.GetKeyDown ("escape"))
		//	Cursor.lockState = CursorLockMode.None;
	}
}

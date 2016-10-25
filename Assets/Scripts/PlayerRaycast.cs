using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerRaycast : MonoBehaviour {

	// Raycast variables
	RaycastHit whatIHit;
	AudioSource locked;
	public float distanceToSee;

	// GUI variables
	private string UIText;
	private bool UIShow;

	private static Texture2D RectTexture;
	private static GUIStyle RectStyle;

	Rect hudRect;
	Texture hudTexture;
	// Rect tmpRect;
	// Texture tmpTexture;

	//Rigidbody rb;
	// Resource variables
	Font myFont;
	AudioSource myAudio;
	AudioClip audioClip;

	// Game variables
	private bool Paused = false;

	private static bool keyTaken;
	private static bool UIPic;
	GameObject keyObject;

	// Use this for initialization ----------------------------------------------------------------------------------------------
	void Start () {
		myFont = (Font)Resources.Load("Fonts/Nu", typeof(Font));
		myAudio = gameObject.AddComponent<AudioSource>();
		myAudio.playOnAwake = false;

		UIShow = false;

		// Key tmp
		//float tmpSize = Screen.width * 0.1f;
		// tmpRect = new Rect (Screen.width / 2 - tmpSize / 2, Screen.height * 0.7f, tmpSize, tmpSize);
		// tmpTexture = (Texture)Resources.Load("Key", typeof(Texture));

		//HUD
		float hudSize = Screen.width * 0.03f;
		hudRect = new Rect (Screen.width * 0.03f, Screen.height * 0.03f, hudSize, hudSize);
		hudTexture = (Texture)Resources.Load("Textures/Key", typeof(Texture));

		if (keyTaken == true) {
			Destroy (GameObject.Find ("Key"));
		}

		if (UIPic == true) {
			UIPic = true;
		}
	}

	// Update is called once per frame ----------------------------------------------------------------------------------------------
	void Update () {

		// Raycast ray
		Debug.DrawRay (this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		// What ray hits
		if (Physics.Raycast (this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {

			// Debug.Log ("I hit " + whatIHit.collider.gameObject.name);

			if (UIShow == false && Input.GetKeyDown (KeyCode.E)) {
				if (whatIHit.collider.gameObject.name == "Wooden Sign") {
					UIText = "Private Residence of Mr. Ape";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Monkey Man") {
					UIShow = true;
					UIText = "Hello, old chap, how are you today!";
				} else if (whatIHit.collider.gameObject.name == "1") {
					UIText = "That earthquake really rumbled my bed last night!";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "2") {
					UIText = "I thought I was having a nightmare.";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "3") {
					UIText = "I heard moaning ... I thought it was my wife";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "4") {
					UIText = "Work work work, that's all I'm good for here!\n" +
						"I wish I could go to that far away castle";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Corns") {
					UIText = ".Corn.";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Red Flowers") {
					UIText = "Red flowers";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Bone") {
					UIText = "Wow, seems like someone was really hungy";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Trap Door") {
					UIText = "Hmmm something seems suspicious.";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Tomb") {
					UIText = "RIP Dr. Gorilla";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Crate") {
					if (keyTaken == false) {
						UIText = "[Crate locked, key required]";
						UIShow = true;
						audioClip = (AudioClip)Resources.Load ("SFX/Locked", typeof(AudioClip));
						myAudio.clip = audioClip;
						if (myAudio != null) {
							myAudio.Play ();
						}
					} else {
						Destroy (GameObject.Find ("Crate"));
						audioClip = (AudioClip)Resources.Load ("SFX/Button", typeof(AudioClip));
						myAudio.clip = audioClip;
						if (myAudio != null) {
							myAudio.Play ();
						}
						UIPic = false;
					}
				} else if (whatIHit.collider.gameObject.name == "Boundary") {
					UIText = "Moo";
					UIShow = true;
					audioClip = (AudioClip)Resources.Load ("SFX/Cow", typeof(AudioClip));
					myAudio.clip = audioClip;
					if (myAudio != null) {
						myAudio.Play ();
					}
				} else if (whatIHit.collider.gameObject.name == "Key") {
					// keyDisplayTime = 2;
					UIPic = true;
					Destroy (GameObject.Find ("Key"));
					keyTaken = true;
					audioClip = (AudioClip)Resources.Load ("SFX/Chain", typeof(AudioClip));
					myAudio.clip = audioClip;
					if (myAudio != null) {
						myAudio.Play ();
					}
				} else if (whatIHit.collider.gameObject.name == "MiniMonkey") {
					UIText = "Daddy, let's play!";
					UIShow = true;
				} else if (whatIHit.collider.gameObject.name == "Door") {
					UIText = "Exiting";
					UIShow = true;
					SceneManager.LoadScene ("MainScene");
				} else if (whatIHit.collider.gameObject.name == "Wood House") {
					UIText = "Entering";
					UIShow = true;
					SceneManager.LoadScene ("House");
				} else if (whatIHit.collider.gameObject.name == "Ladder") {
					UIText = "Entering";
					UIShow = true;
					SceneManager.LoadScene ("Dungeon");
				}
			} else if (UIShow == true && Input.GetKeyDown (KeyCode.E)) {
				UIText = "";
				UIShow = false;
			}
		} else {
			UIText = "";
			UIShow = false;
		}

		// Pausing game
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Paused == true) {
				Time.timeScale = 1.0f;
				Cursor.lockState = CursorLockMode.Locked;
				Paused = false;
			} else {
				Time.timeScale = 0.0f;
				Cursor.lockState = CursorLockMode.None;
				Paused = true;
			}
		}

	}

	// GUI ---------------------------------------------------------------------------------------------------------------------
	void OnGUI() { 
		if (UIShow == true) {
			// Rect properties
			RectTexture = new Texture2D( 1, 1 );
			RectStyle = new GUIStyle ();
			RectTexture.SetPixel( 0, 0, Color.black );
			RectTexture.Apply();
			RectStyle.normal.background = RectTexture;

			// Font properties
			RectStyle.fontSize = Screen.width/50;
			RectStyle.font = myFont;
			RectStyle.normal.textColor = Color.red;
			RectStyle.alignment = TextAnchor.MiddleCenter;

			// Create Box
			GUI.Box(new Rect ((Screen.width/8),(5 * Screen.height/8),(3 * Screen.width/4), (Screen.height/4)), UIText, RectStyle );
			// GUI.Box(new Rect (100, 600, Screen.width-200, Screen.height-700), UIText, RectStyle );
		}

		if (UIPic == true) {
			//GUI.DrawTexture (tmpRect, tmpTexture);
			GUI.DrawTexture (hudRect, hudTexture);
		} else if (UIPic == false) {
			// No GUI
		}
	}
}
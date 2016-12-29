using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

	public float carSpeed;
	Vector3 position;
	public float maxPos = 2.54f;
	bool currentPlatformAndroid = false;
	public UIManager ui;
	Rigidbody2D rb; 
	void Awake(){

		rb = GetComponent<Rigidbody2D> ();

		#if UNITY_ANDROID
			currentPlatformAndroid = true;
		#else
			currentPlatformAndroid = false;
		#endif
	}

	// Use this for initialization
	void Start () {
		
		position = transform.position;
		if (currentPlatformAndroid == true) {
			Debug.Log ("Android");

		} else {
			Debug.Log ("Windows");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentPlatformAndroid == true) {
			//Android specific code...

			accMove ();

		} else {
			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
			position.x = Mathf.Clamp (position.x, -2.54f, 2.54f);
			transform.position = position;

		}


	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy Car") {
			Destroy (gameObject);

			ui.gameOverx ();

		}
	}

	void accMove(){

		float x = Input.acceleration.x;
		if (x < -0.1f) {
			MoveLeft ();
		} else if (x > 0.1f) {
			MoveRight ();
		} else {
			setVeltoZero ();
		}

	}

	public void MoveRight(){

		rb.velocity = new Vector2 (carSpeed , 0);
	}

	public void MoveLeft(){

		rb.velocity = new Vector2 (-carSpeed , 0);
	}

	public void setVeltoZero(){
		rb.velocity = Vector2.zero;

	}


}

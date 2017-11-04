using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public Rigidbody2D body;
	public SpriteRenderer renderer;
	public float jetpackForce;
	public float runningSpeed;
	public float initialPositionX;

	private static PlayerScript instance;

	private bool crashed = false;
	private int blinkCounter = 0;

	public static PlayerScript GetPlayer(){
		return instance;
	}

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		PlayerScript.instance = this;
		initialPositionX = this.transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		if (crashed) {
			this.renderer.enabled = !this.renderer.enabled;
			blinkCounter++;
			if (blinkCounter > 10) {
				this.renderer.enabled = true;
				crashed = false;
				blinkCounter = 0;
			}
		}
	}

	// FixedUpdate is called once per frame
	void FixedUpdate () {

		if (jetpackForce == 0) {
			jetpackForce = 25f;
		}

		if (runningSpeed == 0) {
			runningSpeed = 4f;
		}

		if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)){
			body.AddForce (new Vector2 (0, jetpackForce));
		}

		Vector2 velocity = this.body.velocity;
		velocity.x = runningSpeed;
		this.body.velocity = velocity;
	
	}

	public float GetDistanceRan(){
		return this.transform.position.x - initialPositionX;
	}

	public void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("bateu");
		crashed = true;
	}

}

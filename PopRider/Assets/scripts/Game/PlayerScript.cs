using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public Rigidbody2D body;
	public SpriteRenderer spriteRenderer;
	public float jetpackForce;
	public float runningSpeed;
	public float initialPositionX;

	[SerializeField]
	private ParticleSystem bulletParticleSystem;

	[SerializeField]
	private ParticleSystem fireParticleSystem;

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
		bulletParticleSystem.Stop ();
		fireParticleSystem.Stop ();
	}

	// Update is called once per frame
	void Update () {
		if (crashed) {
			this.spriteRenderer.enabled = !this.spriteRenderer.enabled;
			blinkCounter++;
			if (blinkCounter > 10) {
				this.spriteRenderer.enabled = true;
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

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
			if (bulletParticleSystem.isStopped) {
				bulletParticleSystem.Play ();
			}
			if (fireParticleSystem.isStopped) {
				fireParticleSystem.Play ();
			}
			body.AddForce (new Vector2 (0, jetpackForce));
		} else {
			if (bulletParticleSystem.isPlaying) {
				bulletParticleSystem.Stop ();
			}
			if (fireParticleSystem.isPlaying) {
				fireParticleSystem.Stop ();
			}
		}

		Vector2 velocity = this.body.velocity;
		velocity.x = runningSpeed;
		this.body.velocity = velocity;
	
	}

	public float GetDistanceRan(){
		return this.transform.position.x - initialPositionX;
	}

	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag ("coin")) {
			//ignore
			Debug.Log ("coin");
		} else if (collider.CompareTag ("zapper")) {
			crashed = true;
			int currentScore = Mathf.RoundToInt (GetDistanceRan ());
			int highScore = PlayerPrefs.GetInt ("highscore", 0);
			if (currentScore > highScore) {
				PlayerPrefs.SetInt ("highscore", currentScore);	
			}
			SceneManager.LoadScene ("GameOver");
		} else {
			Debug.Log ("oi?");
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "floor") {
			
		} else {
		
		}
	}

}

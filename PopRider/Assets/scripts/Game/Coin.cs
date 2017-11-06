using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag.Equals ("Player")) {
			AudioManager.GetInstance ().PlayCoinAudioSource ();
			Destroy (this.gameObject);
		}
	}

}

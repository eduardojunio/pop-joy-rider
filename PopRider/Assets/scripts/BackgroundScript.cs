using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	private bool insideCamera;

	private bool hasEnteredCamera = false;

	private List<Zapper> zappers;

	[SerializeField]
	private BackgroundManager backgroundManager;

	[SerializeField]
	private ZapperPlaceHolder[] zapperPlaceHolders;

	private void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	private void Start() {
		zappers = new List<Zapper>();
		updateIsInsideCamera ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		float halfWidth = GetWidth () / 2;
		position.x += halfWidth;
		if (this.insideCamera) {
			if (!hasEnteredCamera) {
				OnEnterCamera ();
			}
			hasEnteredCamera = true;
			if (!CameraController.GetInstance ().hasLeftCamera (position)) {
				this.backgroundManager.OnOutOfCamera (this);
				hasEnteredCamera = false;
				OnLeaveCamera ();
			}
		} else {
			updateIsInsideCamera ();
		}
	}

	public void updateIsInsideCamera(){
		Vector3 position = this.transform.position;
		insideCamera = CameraController.GetInstance ().hasLeftCamera (position);
	}

	public void OnEnterCamera() {
		int qt = Random.Range (0, zapperPlaceHolders.Length)+1;
		for (int i=0; i<qt; i++){
			ZapperPlaceHolder placeholder = zapperPlaceHolders [Random.Range (0, zapperPlaceHolders.Length)];
			if (!placeholder.used) {
				placeholder.used = true;
				Zapper newZapper = ZapperManager.GetInstance ().CreateZapperAt (placeholder.transform.position);
				this.zappers.Add (newZapper);
			}
		}
	}

	public void OnLeaveCamera() {
		if (this.zappers != null) {
			for (int i = 0; i < this.zappers.Count; i++) {
				Destroy (zappers[i].gameObject);
				this.zappers.Remove (this.zappers[i]);
			}
			for (int i = 0; i < this.zapperPlaceHolders.Length; i++) {
				ZapperPlaceHolder placeholder = zapperPlaceHolders [Random.Range (0, zapperPlaceHolders.Length)];
				placeholder.used = false;
			}
		}
	}

	public float GetWidth() {
		Bounds bounds = this.spriteRenderer.bounds;
		return bounds.size.x;
	}
}

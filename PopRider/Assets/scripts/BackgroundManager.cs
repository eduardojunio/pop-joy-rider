using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	private BackgroundScript[] backgrounds;

	public void Awake(){
		this.backgrounds = this.GetComponentsInChildren<BackgroundScript> ();
	}

	private BackgroundScript GetLastBackground() {
		BackgroundScript lastBackground = null;
		BackgroundScript currentBackground;
		for (int i = 0; i < this.backgrounds.Length; i++) {
			currentBackground = backgrounds [i];
			if (lastBackground==null || currentBackground.transform.position.x > lastBackground.transform.position.x) {
				lastBackground = currentBackground;
			}
		}
		return lastBackground;
	}

	public void OnOutOfCamera(BackgroundScript background){
		BackgroundScript lastBackground = GetLastBackground ();
		AlignToPrevious (lastBackground, background);
	}

	public void AlignToPrevious(BackgroundScript previous, BackgroundScript current) {
		Vector3 position = previous.transform.position;
		position.x = previous.transform.position.x + current.GetWidth()/2 + previous.GetWidth()/2;
		current.transform.position = position;
	}

	public void Start(){
		for (int i = 0; i < this.backgrounds.Length; i++) {
			if (i == 0) {
				Vector3 position = CameraController.GetInstance ().GetWorldPositionFromViePort (new Vector2(0,0));
				position.x += backgrounds [0].GetWidth () / 2;
				position.y = 0;
				position.z = 0;
				backgrounds [0].transform.position = position;
			} else {
				AlignToPrevious (this.backgrounds[i-1], this.backgrounds[i]);
			}
		}
	}

}

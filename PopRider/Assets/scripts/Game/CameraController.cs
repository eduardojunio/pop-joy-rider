using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private Camera gameCamera;

	private static CameraController instance;

	public static CameraController GetInstance(){
		return CameraController.instance;
	}

	private void Awake() {
		CameraController.instance = this;
	}

	public bool IsInsideCamera(Vector3 position){
		Vector2 viewPortPosition = this.gameCamera.WorldToViewportPoint(position);
		return !(viewPortPosition.x>1 || viewPortPosition.x<0 || viewPortPosition.y>1 || viewPortPosition.y<0);
	}

	public bool hasLeftCamera(Vector3 position){
		Vector2 viewPortPosition = this.gameCamera.WorldToViewportPoint(position);
		return viewPortPosition.x > 0;
	}

	public Vector4 GetWorldPositionFromViePort(Vector2 viewPortPosition){
		return this.gameCamera.ViewportToWorldPoint (viewPortPosition);
	}

}

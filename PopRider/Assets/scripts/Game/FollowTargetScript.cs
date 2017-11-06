using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetScript : MonoBehaviour {

	[SerializeField]
	private Transform target;

	[SerializeField]
	private float offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = this.transform.position;
		currentPosition.x = this.target.position.x + offset;
		this.transform.position = currentPosition;
	}
}

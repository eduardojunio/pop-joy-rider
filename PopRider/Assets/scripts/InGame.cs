using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour {

	[SerializeField]
	private Text distanceText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		int distance = (int) Mathf.Floor (PlayerScript.GetPlayer ().GetDistanceRan ());
		this.distanceText.text = distance+"M";
	}
}

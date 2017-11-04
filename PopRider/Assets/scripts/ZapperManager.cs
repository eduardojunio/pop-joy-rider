using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapperManager : MonoBehaviour {

	private static ZapperManager instance;

	[SerializeField]
	private Zapper zapperPrefab;

	public void Awake(){
		ZapperManager.instance = this;
	}

	public static ZapperManager GetInstance() {
		return instance;
	}

	public Zapper CreateZapperAt(Vector3 position) {
		Zapper zapper = Zapper.Instantiate (zapperPrefab);
		zapper.transform.position = position;
		zapper.gameObject.SetActive (true);	
		return zapper;
	}

}

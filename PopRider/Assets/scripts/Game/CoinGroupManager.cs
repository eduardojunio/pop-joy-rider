using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroupManager : MonoBehaviour {

	private static CoinGroupManager instance;

	[SerializeField]
	private CoinGroup coinGroupPop;

	[SerializeField]
	private CoinGroup coinGroupBig;

	public void Awake(){
		CoinGroupManager.instance = this;
	}

	public static CoinGroupManager GetInstance() {
		return instance;
	}

	public CoinGroup CreateCoinGroupAt(Vector3 position) {
		bool isPopGroup = Random.Range (0, 2)==0 ? true : false;
		CoinGroup group;
		if (isPopGroup) {
			group = CoinGroup.Instantiate (coinGroupPop);
		} else {
			group = CoinGroup.Instantiate (coinGroupBig);
		}
		group.transform.position = position;
		group.gameObject.SetActive (true);	
		return group;
	}

}

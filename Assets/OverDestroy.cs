using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible(){
	//オブジェクト画面外へ行くと消滅
	Destroy(this.gameObject);
	}
}
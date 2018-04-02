using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

	//unityちゃんのオブジェクト
	private GameObject unitychan;
	//unityちゃんとカメラの距離を入れる変数
	private float difference;

	void Start () {
		//unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");
		//unityちゃんとカメラの位置(z座標)の差を求める
		this.difference = unitychan.transform.position.z - this.transform.position.z;
	}
	

	void Update () {
		//unityちゃんの位置に合わせてカメラの位置を移動
		this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
	}
}

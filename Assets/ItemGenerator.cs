﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	//unityちゃんを入れる
	public GameObject unitychan;
	//アイテム動的生成距離
	private float ItemPopRange;
	//アイテムのセットタイミング
	private float ItemSet = 0.0f;
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;



	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {



		//unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");

		//オブジェクトが生成される範囲を指定
		//　　　　　　　　（　Unityちゃんの居る位置　＋　60　＝　奥側の視認限界範囲）
		this.ItemPopRange = unitychan.transform.position.z + 45;

		//オブジェクトが生成されるまでの時間を加算
		this.ItemSet += Time.deltaTime;



		//一定の距離ごとにアイテムを生成
		for (float f = ItemPopRange ; f <= ItemPopRange; f++){
			Debug.Log (ItemPopRange);
			//時間が一定に達するとオブジェクト生成
			if (ItemSet > 1.5) {
				//時間をリセット
				this.ItemSet = 0.0f;

				//どのアイテムを出すのかをランダムに設定
				int num = Random.Range (0, 10);
				if (num <= 1) {
					//コーンをx軸方向に一直線に生成
					for (float j = -1; j <= 1; j += 0.4f) {
						GameObject cone = Instantiate (conePrefab) as GameObject;
						cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, f);
					}
				} else {

					//レーンごとにアイテムを生成
					for (int j = -1; j < 2; j++) {
						//アイテムの種類を決める
						int item = Random.Range (1, 11);
						//アイテムを置くZ座標のオフセットをランダムに設定
						int offsetZ = Random.Range (-5, 6);
						//60%コイン配置:30%車配置:10%何もなし
						if (1 <= item && item <= 6) {
							//コインを生成
							GameObject coin = Instantiate (coinPrefab) as GameObject;
							coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, f + offsetZ);
						} else if (7 <= item && item <= 9) {
							//車を生成
							GameObject car = Instantiate (carPrefab) as GameObject;
							car.transform.position = new Vector3 (posRange * j, car.transform.position.y, f + offsetZ);
					}
					}
				}	
			}
		}
	}


}


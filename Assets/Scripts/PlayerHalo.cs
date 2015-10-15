using UnityEngine;
using System.Collections;

public class PlayerHalo : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.GetComponent<fog>()){
			//Debug.Log(other.gameObject.name);
			other.gameObject.GetComponent<fog>().diableFog();
		}
	}
}

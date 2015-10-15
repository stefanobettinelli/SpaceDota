using UnityEngine;
using System.Collections;

public class Renew : MonoBehaviour {

	private float lastSpawnTime = 0f;
	public float respawnTime = 5f;

	void Update () {
		float delta = Time.time - lastSpawnTime;
		if (!this.gameObject.GetComponent<Collider2D> ().enabled && delta >= respawnTime) {
			this.gameObject.GetComponent<Collider2D> ().enabled = true;
			this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
			lastSpawnTime = Time.time;
		}
	}
}

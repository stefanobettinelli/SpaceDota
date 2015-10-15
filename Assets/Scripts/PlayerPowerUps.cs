using UnityEngine;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour {

	private const int MAXSPEED = 5000;
	private const int MAXAMMO = 40;
	private int currentSpeed;

	void Awake(){
		//currentSpeed = 
	}

	public void gainSpeed(int speed){
		if(speed < MAXSPEED){
			this.gameObject.transform.parent.GetComponent<PlayerMovement>().speed += speed;
		}
	}

	public void gainAmmo(int ammo){
        int currentAmmos = this.gameObject.transform.parent.GetComponent<PlayerMovement>().getAmmo();
        if (currentAmmos < MAXAMMO){
            if (currentAmmos + ammo > MAXAMMO) {
                this.gameObject.transform.parent.GetComponent<PlayerMovement>().setAmmo(MAXAMMO);
            } else {
                this.gameObject.transform.parent.GetComponent<PlayerMovement>().setAmmo(currentAmmos + ammo);
            }
		}
	}

	public bool hasShield(){
		//Debug.Log("hasShield");
		return false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("boots")){
			gainSpeed(200);
			other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			other.gameObject.GetComponent<Collider2D>().enabled = false;
		}
		if(other.gameObject.CompareTag("ammos")){
			gainAmmo(5);
			other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			other.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}
}

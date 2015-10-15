using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb2d;
	public PlayerMovement playerMovement;
    public AudioSource[] aSources;
    public AudioSource explosion;

	void Awake(){
        aSources = GetComponents<AudioSource>();
        explosion = aSources[1];
		rb2d = GetComponent<Rigidbody2D>();

		if(this.gameObject.name == "player1Bullet(Clone)"){
			playerMovement = GameObject.Find("Player1").GetComponent<PlayerMovement>();
		} else if(this.gameObject.name == "player2Bullet(Clone)"){
			playerMovement = GameObject.Find("Player2").GetComponent<PlayerMovement>();
		}
		rb2d.velocity = playerMovement.GetComponent<Rigidbody2D>().velocity.normalized * speed;
		if(rb2d.velocity == Vector2.zero){
			rb2d.velocity = playerMovement.bulletDirWhenPlayerNotMoving * speed;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "Player2" && this.gameObject.name == "player1Bullet(Clone)"){
			other.gameObject.transform.position = GameObject.Find("Player2").GetComponent<PlayerMovement>().firstP2Position;
		}
		if(other.gameObject.name == "Player1" && this.gameObject.name == "player2Bullet(Clone)"){
			other.gameObject.transform.position = GameObject.Find("Player1").GetComponent<PlayerMovement>().firstP1Position;
		}
		if(other.gameObject.CompareTag("bulletCollidable")){
            AudioSource.PlayClipAtPoint(explosion.clip, this.gameObject.transform.position);
            Destroy(this.gameObject);
		}

		if(other.gameObject.name == "Tower1" && this.gameObject.name == "player2Bullet(Clone)"){
			GameObject.Find("GameManager").GetComponent<GameManager>().dmgTower1(10);
			if(GameObject.Find("GameManager").GetComponent<GameManager>().tower1Life <= 0){
				Destroy (other.gameObject);
				Destroy(GameObject.Find("Player1"));
				Destroy(GameObject.Find("Player2"));
				GameObject.Find("GameManager").GetComponent<GameManager>().winnerText.text = "Player 2 Wins";
			}
		}
		if(other.gameObject.name == "Tower2" && this.gameObject.name == "player1Bullet(Clone)"){
			GameObject.Find("GameManager").GetComponent<GameManager>().dmgTower2(10);
			if(GameObject.Find("GameManager").GetComponent<GameManager>().tower2Life <= 0){
				Destroy (other.gameObject);
				Destroy(GameObject.Find("Player1"));
				Destroy(GameObject.Find("Player2"));
				GameObject.Find("GameManager").GetComponent<GameManager>().winnerText.text = "Player 1 Wins";
			}
		}
	}
}

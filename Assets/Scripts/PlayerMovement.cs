using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public Transform firePoint;
	public GameObject player1Bullet;
	public GameObject player2Bullet;
	public float fireRate;
    public int playerAmmo1;
    public int playerAmmo2;
	public Vector3 tpPosition1;
	public Vector3 tpPosition2;
	public int teleportsP1;
	public int teleportsP2;
	public Text bulletsP1;
	public Text bulletsP2;
    public Text tpP1;
    public Text tpP2;
    public Vector3 playerDirection;
    public Vector3 bulletDirWhenPlayerNotMoving;

    public Vector2 firstP1Position;
	public Vector2 firstP2Position;
	
	private string playerName;
	private Rigidbody2D rb2d;
	private float lastShotTime1 = 0f;
	private float lastShotTime2 = 0f;

	void Awake(){
        bulletDirWhenPlayerNotMoving = Vector2.down;
        tpPosition1 = this.transform.position;
		tpPosition2 = this.transform.position;
		firstP1Position = tpPosition1;
		firstP2Position = tpPosition2;
		rb2d = GetComponent<Rigidbody2D>();
		playerName = this.gameObject.name;
	}


	public void setAmmo(int ammo){
		if(this.gameObject.name == "Player1"){
			playerAmmo1 = ammo;
            bulletsP1.text = "Ammo 1 = " + playerAmmo1;
        }
		if(this.gameObject.name == "Player2"){
			playerAmmo2 = ammo;
            bulletsP2.text = "Ammo 2 = " + playerAmmo2;
        }
	}

	public int getAmmo(){
		if(this.gameObject.name == "Player1"){
			return playerAmmo1;
		}
		if(this.gameObject.name == "Player2"){
			return playerAmmo2;
		}
		return 0;
	}


	void Update () {       
        if (Input.GetKeyDown("e") && playerName == "Player1"){
			tpPosition1 = this.transform.position;
		}
		if(Input.GetKeyDown("q") && playerName == "Player1" && teleportsP1>=1){
			teleportsP1--;
            tpP1.text = "TP = " + teleportsP1.ToString(); 
			this.transform.position = tpPosition1;
			this.gameObject.GetComponent<AudioSource>().Play();
		}
		if(Input.GetKeyDown(KeyCode.Mouse2) && playerName == "Player2"){
			tpPosition2 = this.transform.position;
		}
		if(Input.GetKeyDown(KeyCode.Mouse1) && playerName == "Player2" && teleportsP2>=1){
			teleportsP2--;
            tpP2.text = "TP = " + teleportsP2.ToString();
            this.transform.position = tpPosition2;
			this.gameObject.GetComponent<AudioSource>().Play();
		}
		Shoot();
        if (this.gameObject.name == "Player1") {
            bulletsP1.text = "Ammo 1 = " + playerAmmo1.ToString();
        }
        if (this.gameObject.name == "Player2") {
            bulletsP2.text = "Ammo 2 = " + playerAmmo2.ToString();
        }
        print(playerAmmo1);
    }

	void Shoot(){
		float delta1 = Time.time - lastShotTime1;
		if(playerName == "Player1" && delta1 >= fireRate && playerAmmo1 >= 1){
			if(Input.GetKey(KeyCode.Space)){
				lastShotTime1 = Time.time;
				Instantiate(player1Bullet, firePoint.position,firePoint.rotation);
				playerAmmo1--;				
			}
		}
		float delta2 = Time.time - lastShotTime2;
		if(playerName == "Player2" && delta2 >= fireRate && playerAmmo2 >= 1){
			if(Input.GetKey(KeyCode.Mouse0)){
				lastShotTime2 = Time.time;
				Instantiate(player2Bullet, firePoint.position,firePoint.rotation);
				playerAmmo2--;
			}
		}
	}

	void FixedUpdate(){
		playerDirection = new Vector3(0,0,0);
		if(playerName == "Player1"){
			if (Input.GetKey ("a")){
				playerDirection += Vector3.left;
			}
			if(Input.GetKey("d")){
				playerDirection += Vector3.right;
			}
			if (Input.GetKey ("w")){
				playerDirection += Vector3.up;     
			}
			if(Input.GetKey ("s")){
				playerDirection += Vector3.down;
			}
			if(playerDirection != Vector3.zero){
				rb2d.AddForce(playerDirection.normalized*speed*Time.deltaTime);
                this.bulletDirWhenPlayerNotMoving = this.playerDirection;
            }
        }
		if(playerName == "Player2"){
			if (Input.GetKey(KeyCode.LeftArrow)){
				playerDirection += Vector3.left;
			}
			if(Input.GetKey(KeyCode.RightArrow)){
				playerDirection += Vector3.right;
			}
			if (Input.GetKey (KeyCode.UpArrow)){
				playerDirection += Vector3.up;     
			}
			if(Input.GetKey (KeyCode.DownArrow)){
				playerDirection += Vector3.down;
			}
			if(playerDirection != Vector3.zero){
				rb2d.AddForce(playerDirection.normalized*speed*Time.deltaTime);
                this.bulletDirWhenPlayerNotMoving = this.playerDirection;
            }         
        }
	}

}
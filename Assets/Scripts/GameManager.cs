using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public  int tower1Life = 100;
	public  int tower2Life = 100;
	public  Text tower1LifeText;
	public  Text tower2LifeText;
	public  Text winnerText;

	void Awake(){
		tower1LifeText.text = "100";
		tower2LifeText.text = "100";
		winnerText.text = "";
	}

	public  void dmgTower1(int dmg){
		tower1Life -= dmg;
		tower1LifeText.text = tower1Life.ToString();
	}

	public  void dmgTower2(int dmg){
		tower2Life -= dmg;
		tower2LifeText.text = tower2Life.ToString();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

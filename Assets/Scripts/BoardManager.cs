using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int columns = 8;
	public int rows = 8;

	public GameObject[] floorTiles;
	public GameObject[] topWallTiles;
	public GameObject[] rightWallTiles;
	public GameObject[] bottomWallTiles;
	public GameObject[] leftWallTiles;

	public GameObject topLeftTile;
	public GameObject topRightTile;
	public GameObject bottomRightTile;
	public GameObject bottomLeftTile;

	private List <Vector3> gridPositions = new List <Vector3> ();

	void InitialiseList (){
		gridPositions.Clear ();

		for(int x = 1; x < columns; x++){

			for(int y = 1; y < rows; y++) {
				gridPositions.Add (new Vector3(x, y, 0f));
			}
		}
	}

	void BoardSetup (){

		int startX = -(columns / 2);
		int startY = -(rows / 2);
		int endX = (columns / 2);
		int endY = (rows / 2);

		for(int x = startX; x < endX; x++){

			for(int y = startY; y < endY; y++){

				GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
				Instantiate (toInstantiate, new Vector3 (x, y, 1), Quaternion.identity);
			}
		}

		//Angoli
		Instantiate (topLeftTile, new Vector3 (startX, endY-1, 0f), Quaternion.identity);
		Instantiate (topRightTile, new Vector3 (endX-1, endY-1, 0f), Quaternion.identity);
		Instantiate (bottomRightTile, new Vector3 (endX-1, startY, 0f), Quaternion.identity);
		Instantiate (bottomLeftTile, new Vector3 (startX, startY, 0f), Quaternion.identity);

		//Mura Top/Bottom
		for(int x = startX+1; x < endX-1; x++){
			GameObject topWallToInstantiate = topWallTiles[Random.Range (0,topWallTiles.Length)];
			GameObject bottomWallToInstantiate = bottomWallTiles[Random.Range (0,bottomWallTiles.Length)];

			Instantiate (topWallToInstantiate, new Vector3 (x, endY-1, 0f), Quaternion.identity);
			Instantiate (bottomWallToInstantiate, new Vector3 (x, startY, 0f), Quaternion.identity);
		}

		//Mura Right/Left
		for(int y = startY+1; y < endY-1; y++){
			GameObject rightWallToInstantiate = rightWallTiles[Random.Range (0,rightWallTiles.Length)];
			GameObject leftWallToInstantiate = leftWallTiles[Random.Range (0,leftWallTiles.Length)];

			Instantiate (rightWallToInstantiate, new Vector3 (endX-1, y, 0f), Quaternion.identity);
			Instantiate (leftWallToInstantiate, new Vector3 (startX, y, 0f), Quaternion.identity);
		}
	}

	Vector3 RandomPosition (){
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions[randomIndex];
		gridPositions.RemoveAt (randomIndex);

		return randomPosition;
	}

	public void SetupScene (){

		//InitialiseList ();
		BoardSetup ();

	}

	void Awake(){
		SetupScene ();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	[Header("Set Dynamically")]

	public Text scoreGT;

	// Use this for initialization
	void Start () {

		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text> ();
		scoreGT.text = "0";

	}
	
	// Update is called once per frame
	void Update () {

		//get current screen position forom mouse input
		Vector3 mousePos2D = Input.mousePosition;
		//camera's z position sets where mouse is into 3D space
		mousePos2D.z = -Camera.main.transform.position.z;
		//convert 2d screen to 3d world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint ( mousePos2D );

		//move the x position of this Basket to the x position of the Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;


	}

	void OnCollisionEnter( Collision coll )
	{
		//Find out what hit this basket

		GameObject collidedWith = coll.gameObject;

		if (collidedWith.tag == "Apple") {

			Destroy (collidedWith);

			int score = int.Parse (scoreGT.text);
			score += 100;
			scoreGT.text = score.ToString ();

			if (score > HighScore.score) 
			{

				HighScore.score = score;
			}

		}

	}
}

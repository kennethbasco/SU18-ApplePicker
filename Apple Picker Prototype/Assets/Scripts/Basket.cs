using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

		}

	}
}

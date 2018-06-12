using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour 
{

	[Header("Set in Inspector")]

	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirections = 0.1f;
	public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () 
	{

		//Dropping Apples every second
		Invoke("DropApple", 2f);

	}

	void DropApple()
	{
		GameObject apple = Instantiate<GameObject> (applePrefab);
		apple.transform.position = transform.position;
		Invoke ("DropApple", secondsBetweenAppleDrops);

	}

	// Update is called once per frame
	void Update () 
	{

		//Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//Changing Direction

		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); //Move Right

		} 
		else if (pos.x > leftAndRightEdge) 
		{
			speed = -Mathf.Abs (speed); //Move Left
		} 
		else if (Random.value < chanceToChangeDirections) 
		{
			speed *= -1; //Change Direction
		}
		
	}

	void FixedUpdate()
	{
		//change rando direction is time based
		if (Random.value < chanceToChangeDirections) 
		{
			speed *= -1; //Change Direction
		}
	}
}

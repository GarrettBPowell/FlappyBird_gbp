using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour 
{
	
	private BoxCollider2D groundCollider;		//This stores a reference to the collider attached to the Ground.
	private float groundHorizontalLength;		//A float to store the x-axis length of the collider2D attached to the Ground GameObject.

	//Awake is called before Start.
	private void Awake ()
	{
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
		Debug.Log(groundCollider.size.x);
	}

	private void Update()
	{
		if (transform.position.x < -groundHorizontalLength)
			//If true, this means this object is no longer visible and we can safely move it forward to be re-used.
			RepositionBackground ();
	}

	private void RepositionBackground()
	{
		Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

		transform.position = (Vector2) transform.position + groundOffSet;
	}
}
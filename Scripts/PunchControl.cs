using UnityEngine;
using System.Collections;

public class PunchControl : MonoBehaviour {

	public float movementSpeed = 10.0f;
	public string CUBE_TAG = "cube";
	public string PUNCH_BUTTON = "space";
	public float punchingForce = 35.0f;
	public string NEXT_SUCKER_TAG;
	public string PREVIOUS_SUCKER_TAG;
	private GameObject cube;
	private string PUNCH_AXIS = "Horizontal";
	public bool isActive;

	// Use this for initialization
	void Start () {
		cube = GameObject.Find(CUBE_TAG);
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
						renderer.enabled = true;
						if (Input.GetKey (PUNCH_BUTTON)) {
								Vector2 pos;
								

								pos.x = cube.transform.position.x;
								pos.y = transform.position.y;
								cube.transform.position = pos;
								cube.rigidbody2D.AddForce (new Vector2 (punchingForce / 2, 0), ForceMode2D.Impulse);
								cube.renderer.enabled = true;
								if (NEXT_SUCKER_TAG.Length != 0)
										GameObject.Find (NEXT_SUCKER_TAG).GetComponent<SuckerControl> ().isActive = true;
								if (PREVIOUS_SUCKER_TAG.Length != 0)
										GameObject.Find (PREVIOUS_SUCKER_TAG).GetComponent<SuckerControl> ().isActive = false;
								isActive = false;
						} else
								handleMovement ();		
				} else
						renderer.enabled = false;
	}

	void handleMovement(){

		//handle punch movement along vertical axis
		Vector3 move = new Vector3 (0, Input.GetAxis (PUNCH_AXIS), 0);
		transform.position += move * movementSpeed * Time.deltaTime;
	}
}

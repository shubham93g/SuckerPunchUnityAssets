using UnityEngine;
using System.Collections;

public class SuckerControl : MonoBehaviour {

	public bool isActive = true;

	public float movementSpeed = 10.0f;
	public float suckingForce = 35.0f;

	private GameObject cube;
	public string CUBE_TAG = "cube";

	private float cubeMinX;
	private float cubeMaxX;

	private float suckerMaxX;
	private float suckerMinX;

	//private bool spacePressed;
	private bool isSucking;
	public string SUCKER_BUTTON = "space";
	public string SUCKER_AXIS = "Horizontal";

	public string NEXT_PUNCH_TAG = "punch";

	// Use this for initialization
	void Start () {
		cube = GameObject.Find(CUBE_TAG);
		isSucking = false;

		renderer.enabled = false;
	}

	// Update is called once per frame
	void Update() {
				//get latest bounds.x of cube
				cubeMinX = cube.GetComponent<Renderer> ().renderer.bounds.min.x;
				cubeMaxX = cube.GetComponent<Renderer> ().renderer.bounds.max.x;

				//get latest bounds.x of sucker
				suckerMaxX = GetComponent<Renderer> ().renderer.bounds.max.x;
				suckerMinX = GetComponent<Renderer> ().renderer.bounds.min.x;

				if (isActive) {
			renderer.enabled = true;
			handleMovement ();
						//button pressed and cube directly under sucker
						if ((Input.GetKey (SUCKER_BUTTON) || isSucking) 
								&& cubeMinX >= suckerMinX 
								&& cubeMaxX <= suckerMaxX) {
				
								//stop all other cube movements before sucking
								if (!isSucking) {
										cube.rigidbody2D.velocity = Vector2.zero;
								}
				
								//start suck
								cube.rigidbody2D.AddForce (new Vector2 (0, suckingForce));
								isSucking = true;
						}
			
			//cube not under sucker or button released
			else {
								isSucking = false;
								
						}
				}
		else
			renderer.enabled = false;
		}

	void OnCollisionEnter2D (Collision2D col){
		print ("Collision with Sucker !");
		if (isSucking ){//&& col.gameObject.name == cube.name) {

			TeleportCube();

				} else {
						print ("Sucker: Object not a cube or sucking disabled");
				}
		//isSucking = false;
	}

	void handleMovement(){
		//handle sucker movement along horizontal axis
		Vector3 move = new Vector3 (Input.GetAxis (SUCKER_AXIS), 0, 0);
		transform.position += move * movementSpeed * Time.deltaTime;

		}

	void TeleportCube(){
		
		//cancel previous forces and add horizontal force
		cube.rigidbody2D.velocity = Vector2.zero;

		//teleport object
		Vector2 pos;
		pos.y = GameObject.Find(NEXT_PUNCH_TAG).transform.position.y;
		pos.x = GameObject.Find(NEXT_PUNCH_TAG).transform.position.x + cube.renderer.bounds.size.x/2 + GameObject.Find(NEXT_PUNCH_TAG).renderer.bounds.size.x/2;
		
		cube.transform.position = pos;

		//disable gravity for straight horizontal movement
		cube.rigidbody2D.gravityScale = 0.0f;
		//print ("Gravity scale set to " + cube.rigidbody2D.gravityScale);

		cube.renderer.enabled = false;

		GameObject.Find (NEXT_PUNCH_TAG).GetComponent<PunchControl>().isActive = true;
		isActive = false;
		}
}

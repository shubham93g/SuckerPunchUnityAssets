using UnityEngine;
using System.Collections;

public class SideWallCollider : MonoBehaviour {

	public string CUBE_TAG = "cube";
	public float GRAVITY_SCALE = 1.0f;
	public string DEFAULT_SUCKER_TAG;
	public string DISABLED_SUCKER;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == CUBE_TAG) {
						coll.gameObject.rigidbody2D.gravityScale = GRAVITY_SCALE;
						//print ("Gravity scale set to " + coll.gameObject.rigidbody2D.gravityScale);
			if(DEFAULT_SUCKER_TAG.Length!=0){
				GameObject.Find (DEFAULT_SUCKER_TAG).GetComponent<SuckerControl>().isActive = true;
				string punch = GameObject.Find (DEFAULT_SUCKER_TAG).GetComponent<SuckerControl>().NEXT_PUNCH_TAG;
				GameObject.Find (punch).renderer.enabled = false;
			}
			if(DISABLED_SUCKER.Length!=0)
				GameObject.Find (DISABLED_SUCKER).GetComponent<SuckerControl>().isActive = false;

				}
		//print ("Collision detected with between wall and " + coll.gameObject.name.ToString());
		
	}
}

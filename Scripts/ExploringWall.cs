using UnityEngine;
using System.Collections;

public class ExploringWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		renderer.enabled = true;
		}
		//print ("Collision detected with between wall and " + coll.gameObject.name.ToString());
		
	}

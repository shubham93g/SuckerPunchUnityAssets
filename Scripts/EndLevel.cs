using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	public string NEXT_LEVEL = "Level 2";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		print ("Entered end zone");
		Application.LoadLevel (NEXT_LEVEL);
		}
}

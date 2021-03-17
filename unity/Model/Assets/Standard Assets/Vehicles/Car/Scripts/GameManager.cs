using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	// public variables
	
	public Text mainSpeedDisplay;

	public float currentSpeed;

	public Rigidbody Car;

	// setup the game
	void Start () {
		if(Car==null) {
		Car = this.gameObject.GetComponent<Rigidbody>();
		}

		// get a reference to the GameManager component for use by other scripts
		if (gm == null) {
			gm = this.gameObject.GetComponent<GameManager>();
		}
	}

	// this is the main game event loop
	void Update () {
		currentSpeed = Car.velocity.magnitude * 3.6f;

		mainSpeedDisplay.text = currentSpeed.ToString()+" KMPH";
	}

}

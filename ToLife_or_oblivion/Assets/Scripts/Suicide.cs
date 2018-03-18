using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour {

    CharacterController _controller;
    bool buttonPressed = false;

	// Use this for initialization
	void Start () {
        _controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(buttonPressed) {
            Vector3 velocity = new Vector3(0, 0, 1);
            velocity.y -= 9.8f;
            _controller.Move(velocity * Time.deltaTime);
        }

	}
    public void turnOnMovement() {
        buttonPressed = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    CharacterController _controller;

    [SerializeField]
    private float speed;

    private const float gravity = 9.8f;

	// Use this for initialization
	void Start () {

        _controller = GetComponent<CharacterController>();

		
	}
	
	// Update is called once per frame
	void Update () {
        movePlayer();
	}

    private void movePlayer() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput,0,verticalInput).normalized;
        Vector3 velocity = direction * speed;

        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);

    }

}

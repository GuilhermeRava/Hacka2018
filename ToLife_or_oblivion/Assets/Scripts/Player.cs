﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    AudioClip[] footSteps;

    public int NumberOfObjectsPickedUp = 0;

    [SerializeField]
    AudioClip interectionSound;

    AudioSource _audioSource;

    CharacterController _controller;

    Gramophone gramofone;

    Camera viewCamera;
	[SerializeField]
	Animator teddy_animator;
    Animator teddy_animator_Idle;
    [SerializeField]
    private float speed;

    private bool isMoving = false;

    public bool isOnMenu;

    private const float gravity = 9.8f;

    GameManager _GameManager;
    UIManager_Message _MessageManager;

    [SerializeField]
    GameObject _backgroundMessageCanvas;

    [SerializeField]
    GameObject teddyPrefab;

    Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        
        _controller = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
        viewCamera = Camera.main;
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(_GameManager.isPlaying) {
			//Stop walking animation
			teddy_animator.SetBool ("isWalking",false);
            if (!isOnMenu) {
                movePlayer();

                lookToMousePosition();
            }
           
        }
        checkIfWantToPause();
	}

    private void movePlayer() {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if(horizontalInput != 0 || verticalInput != 0) {
            isMoving = true;
			//Start walking animation
			teddy_animator.SetBool ("isWalking",true);
        }
        else {
            isMoving = false;
        }

        Vector3 direction = new Vector3(horizontalInput,0,verticalInput).normalized;
        velocity = direction * speed;

        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);

        if(!_audioSource.isPlaying && isMoving) {
            StartCoroutine(waitToPlaySoundAgain());  
            //playWalkingSound();
        }


    }

    private void lookToMousePosition() {

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {

            Vector3 updatedMousePosition = new Vector3(hit.point.x,transform.position.y,hit.point.z);
            if (((updatedMousePosition.x - transform.position.x) * (updatedMousePosition.x - transform.position.x)) + ((updatedMousePosition.y - transform.position.y) * (updatedMousePosition.y - transform.position.y)) + ((updatedMousePosition.z - transform.position.z) * (updatedMousePosition.z - transform.position.z)) >= 1f) {
                transform.LookAt(updatedMousePosition);
            }
           
        }

    }

    void checkIfWantToPause() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(_GameManager.isPlaying){
                _GameManager.pauseGame();
            }else{
                _GameManager.continuePlaying();
            }
        }
    }

	private void OnTriggerStay(Collider other)
	{
        if (other.tag.Equals("Gramofone"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                gramofone = other.GetComponent<Gramophone>();

                AudioSource.PlayClipAtPoint(interectionSound, transform.position, 1);

                gramofone.playWhiteNoise();

            }

        }

        if (other.tag.Equals("Paper"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                Retrivable paper = other.GetComponent<Retrivable>();

                AudioSource.PlayClipAtPoint(interectionSound, transform.position, 1);
                _audioSource.Stop();

                paper.pickPaper();


            }

        }
        if (other.tag.Equals("Teddy"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(NumberOfObjectsPickedUp == 4) {
                    
                    Destroy(other.gameObject);
                    Instantiate(teddyPrefab, other.transform.position + new Vector3(0,0.90f,0), Quaternion.identity);
                }

            }
        }

	}

	private void OnTriggerEnter(Collider other)
	{
        _MessageManager = GameObject.Find("CanvasPlayer").GetComponent<UIManager_Message>();

        if(other.tag.Equals("Wall")) {
            
            if(_MessageManager != null) {
                _MessageManager.changeWaterText();
                _MessageManager.showText();
                _backgroundMessageCanvas.SetActive(true);
                StartCoroutine(waitToReset());
            }

        }
        if (other.tag.Equals("Rock"))
        {
            if (_MessageManager != null)
            {
                _MessageManager.changeRocksText();
                _MessageManager.showText();
                _backgroundMessageCanvas.SetActive(true);
                StartCoroutine(waitToReset());
            }

        }
        if (other.tag.Equals("Cliff"))
        {
            if (_MessageManager != null)
            {
                _MessageManager.changeCliffText();
                _MessageManager.showText();
                _backgroundMessageCanvas.SetActive(true);
                StartCoroutine(waitToReset());
            }

        }

  
	}

    IEnumerator waitToReset() {
        yield return new WaitForSeconds(3);
        _backgroundMessageCanvas.SetActive(false);
        _MessageManager.hideText();

    }

    void playWalkingSound() {
        if(footSteps.Length != 0) {
            int randomNumber = Random.Range(0, 4);

            AudioSource.PlayClipAtPoint(footSteps[randomNumber], transform.position, 0.3f);

        }

    }

    IEnumerator waitToPlaySoundAgain() {
        playWalkingSound();
        yield return new WaitForSeconds(0.01f);
        _audioSource.Stop();

    }

    public void pickedCollectable() {
        NumberOfObjectsPickedUp++;
    }



}

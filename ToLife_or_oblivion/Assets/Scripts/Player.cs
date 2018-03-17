using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    CharacterController _controller;

    Camera viewCamera;

    [SerializeField]
    private float speed;

    private const float gravity = 9.8f;

    GameManager _GameManager;
    UIManager_Message _MessageManager;

    [SerializeField]
    GameObject _backgroundMessageCanvas;

	// Use this for initialization
	void Start () {

        _controller = GetComponent<CharacterController>();
        viewCamera = Camera.main;
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(_GameManager.isPlaying) {
            movePlayer();
            lookToMousePosition();
        }
        checkIfWantToPause();
	}

    private void movePlayer() {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput,0,verticalInput).normalized;
        Vector3 velocity = direction * speed;

        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);

    }

    private void lookToMousePosition() {

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {

            Vector3 updatedMousePosition = new Vector3(hit.point.x,transform.position.y,hit.point.z);
            transform.LookAt(updatedMousePosition);
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
        yield return new WaitForSeconds(2);
        _backgroundMessageCanvas.SetActive(false);
        _MessageManager.hideText();

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retrivable : MonoBehaviour {

    [SerializeField]
    Camera viewCamera;
    [SerializeField]
    Camera mainCamera;

    Player player;

    bool isReading = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("TeddyBear4").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if(isReading) {
            if (Input.GetKeyDown(KeyCode.A))
            {
                viewCamera.enabled = false;
                mainCamera.enabled = true;
                isReading = false;
                player.pickedCollectable();
                Destroy(this.gameObject);
            }
        }

	}

    public void pickPaper() {
       
        viewCamera.enabled = true;
        isReading = true;
    }
}

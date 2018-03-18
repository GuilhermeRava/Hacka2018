using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;

    [SerializeField]
    private Vector3 cameraPosition = new Vector3(-5,6,-3);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = target.transform.position + cameraPosition;
        transform.LookAt(target.transform.position);

	}
}

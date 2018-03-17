using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;

    [SerializeField]
    private Vector3 cameraPosition = new Vector3(3,6,5);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = target.transform.position + cameraPosition;
        transform.LookAt(target.transform.position);

	}
}

﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Message : MonoBehaviour {

    [SerializeField]
    GameObject mText;

    TextMeshProUGUI message;

    private int counter = 0;

    string[] cliffMessages = {
        "The view would be better from up there"
    };
    string[] rocksMessages = {
        "It is a rock",
        "I told you it was a rock..."
    };
    string[] waterMessages = {
        "Smells fishy",
        "It seems there's something floating in the blue horizon"
    };
    string[] crabMessages = {
        "Holy crab!",
        "They kinda make me remeber Mr..."
    };

	// Use this for initialization
	void Start () {
        transform.LookAt(Camera.main.transform.position);
        message = mText.GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 updatedPosition = new Vector3(Camera.main.transform.position.x * -1,Camera.main.transform.position.y);
        transform.LookAt(Camera.main.transform.position + new Vector3(0,-45,-120));
	}

    public void changeWaterText() {

        if (counter == waterMessages.Length) {
            counter = 0;
        }
        message.text = waterMessages[counter++];

    }
    public void changeCliffText()
    {

        if (counter == cliffMessages.Length)
        {
            counter = 0;
        }
        message.text = cliffMessages[counter++];

    }
    public void changeCrabsText()
    {

        if (counter == crabMessages.Length)
        {
            counter = 0;
        }
        message.text = crabMessages[counter++];

    }
    public void changeRocksText()
    {

        if (counter == rocksMessages.Length)
        {
            counter = 0;
        }
        message.text = rocksMessages[counter++];

    }

    public void hideText() {
        mText.SetActive(false);
    }
    public void showText()
    {
        mText.SetActive(true);
    }


}
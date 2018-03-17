using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    UIManager _UIManager;

    public bool isPlaying = true;

	private void Start()
	{
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	public void continuePlaying() {
        isPlaying = true;
        _UIManager.turnPauseTextOff();
    }

    public void pauseGame() {
        isPlaying = false;
        _UIManager.turnPauseTextOn();
    }
}

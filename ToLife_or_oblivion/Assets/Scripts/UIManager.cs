using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject text;

    public void turnPauseTextOn() {
        text.SetActive(true);
    }
    public void turnPauseTextOff() {
        text.SetActive(false);
    }

}

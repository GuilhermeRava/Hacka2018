using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : MonoBehaviour {

    AudioSource _audioSource;
    public AudioClip currentAudioClip;

    public AudioClip[] musics;
    int counter = 0;

	// Use this for initialization
	void Start () {
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void playWhiteNoise() {
          
        if(_audioSource.isPlaying == false) {
            currentAudioClip = musics[counter % 4];
            _audioSource.clip = currentAudioClip;
            _audioSource.Play();
            counter++;
        }else{
            _audioSource.Stop();
        }

    }

}

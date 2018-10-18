using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MediaPlayer : MonoBehaviour {
    public VideoPlayer videoPlayer;
    public Button playButton;

	
    public void playClicked()
    {
        videoPlayer.Play();
    }

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

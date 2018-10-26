using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MediaPlayer : MonoBehaviour {
    public VideoPlayer videoPlayer;

    public Button playButton;
    public VideoClip[] clips;
    private int clipIndex;

	
    public void playClicked()
    {
        if (clipIndex >= clips.Length)
        {
            clipIndex = 0;
        }
        else
        {
            clipIndex++;
        }

        videoPlayer.clip = clips[clipIndex];
        videoPlayer.Play();
    }

	void Start () {
        clipIndex = -1;  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

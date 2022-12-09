using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Camera mainCamera;

    void Start()
    {
        // Get the VideoPlayer component from the game object
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                if(hit.transform.name == "1_59566"){
                    Debug.Log("Clic sur le logo");
                    OnMouseDown();
                }
            }
        }
    }

    void OnMouseDown()
    {
        // If the video is currently playing, pause it
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        // Otherwise, play the video
        else
        {
            videoPlayer.Play();
        }
    }
}
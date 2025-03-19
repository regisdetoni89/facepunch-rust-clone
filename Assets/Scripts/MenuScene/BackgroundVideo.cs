using UnityEngine;
using UnityEngine.Video;

public class BackgroundVideo : MonoBehaviour
{

    public VideoClip[] videoClips;
    
    void Start()
    {
        VideoPlayer videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.playOnAwake = true;
        videoPlayer.isLooping = true;
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCamera = Camera.main;
        videoPlayer.clip = videoClips[Random.Range(0, videoClips.Length)];
        videoPlayer.Play();
    }

}

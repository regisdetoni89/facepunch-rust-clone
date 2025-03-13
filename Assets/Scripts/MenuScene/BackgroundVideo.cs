using UnityEngine;
using UnityEngine.Video;

public class BackgroundVideo : MonoBehaviour
{

    public VideoClip[] videoClips;
    
    void Start()
    {
        VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = true;
        videoPlayer.isLooping = true;
        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCamera = Camera.main;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, gameObject.AddComponent<AudioSource>());
        videoPlayer.clip = videoClips[Random.Range(0, videoClips.Length)];
        videoPlayer.Play();
    }

}

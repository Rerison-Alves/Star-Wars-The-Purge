using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneGamelaunch : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public LevelLoader levelLoader;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        levelLoader.LoadNextLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            levelLoader.LoadNextLevel();
        }
    }
}

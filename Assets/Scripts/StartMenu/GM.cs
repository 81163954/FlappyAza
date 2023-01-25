using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GM : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject Canvas;

    public static int global = 0;
    // Start is called before the first frame update

    void Start()
    {
        if (global == 1)
        {
            Canvas.SetActive(true);
            videoPlayer.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit();
        }
        if (global == 0)
        {
            var video = videoPlayer.GetComponent<VideoPlayer>();
            if ((ulong)video.frame == video.frameCount-1)
            {
                    Canvas.SetActive(true);
                    videoPlayer.SetActive(false);
                    global = 1;
            }
        }
    }

    public void LoadingGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneScript : MonoBehaviour
{
    private VideoPlayer _videoPlayer => GetComponent<VideoPlayer>();
    void Start()
    {
        StartCoroutine("VideoEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator VideoEnd()
    {
        yield return new WaitForSeconds((float)(_videoPlayer.length) + 1);
        ChangeScene();
    }
}

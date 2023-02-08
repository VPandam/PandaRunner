using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject player;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }

    void Start()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public IEnumerator ResetAfterFalling()
    {
        yield return new WaitForSeconds(.5f);
        CameraController._instance.ResetCameraPosition();
        yield return new WaitForEndOfFrame();
        player.transform.position = new Vector3(0, 0, player.transform.position.z);
    }

    
}

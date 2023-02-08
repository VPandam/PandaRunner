using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController _instance;
    [SerializeField] float lerpDuration = 0.2f;
    Vector3 LookAt = Vector3.zero;
    Camera _camera;
    private Vector3 originalPosition;
    Vector3 offset = new Vector3(0, 0, -1);
    Vector3 positionToMove;
    float elapsedTime = 0;


    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }

    void Start()
    {
        _camera = Camera.main;
        if (_camera != null)
        {
            originalPosition = _camera.transform.position;
            LookAt = originalPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void LateUpdate()
    {
        LookAt = GameManager._instance.player.transform.position;
        
        if (transform.position != LookAt)
        {
            MoveCameraSmooth(LookAt);
        }
    }

    public void MoveCameraSmooth(Vector3 position)
    {
        
        elapsedTime = elapsedTime += Time.deltaTime;
        positionToMove = new Vector3(position.x, _camera.transform.position.y,_camera.transform.position.z);

        float percentageComplete = elapsedTime / lerpDuration;

        this.transform.position = Vector3.Lerp(this.transform.position, positionToMove, percentageComplete);
        ;
    }

    public void ResetCameraPosition()
    {
        transform.position = new Vector3(0, originalPosition.y, transform.position.z);
    }
}

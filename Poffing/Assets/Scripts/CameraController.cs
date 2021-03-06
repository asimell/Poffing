﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;

    private Camera cam;
    private readonly float xMin = 10f;
    private readonly float xMax = 55f;
    private readonly float cameraMin = 3f;
    private readonly float cameraMax = 8f;

    // For camera reset
    private float originalSize;
    private Vector3 camOriginalPos;
    private Quaternion camOriginalRot;
    private Vector3 originalPos;
    private Quaternion originalRot;
    

    // Use this for initialization
    void Start () {
        cam = GetComponentInChildren<Camera>();
        camOriginalPos = cam.transform.position;
        camOriginalRot = cam.transform.rotation;
        originalSize = cam.orthographicSize;
        originalPos = transform.position;
        originalRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right ctrl"))
        {
            ResetCameraRotation();
            return;
        }

        if (Input.GetKey(KeyCode.Comma))
        {
            ZoomIn();
        } else if (Input.GetKey(KeyCode.Period))
        {
            ZoomOut();
        }


        float x = Input.GetAxis("CameraVertical");
        float y = Input.GetAxis("CameraHorizontal");
        float currentRotationX = Mathf.RoundToInt(cam.transform.rotation.eulerAngles.x);
        if ((x > 0 && currentRotationX == xMax) || x < 0 && currentRotationX == xMin)
        {
            x = 0;
        }

        Vector3 movementX = new Vector3(x, 0f, 0f);
        Vector3 movementY = new Vector3(0f, -y, 0f);
        transform.Rotate(movementX);
        transform.RotateAround(Vector3.zero, movementY, Time.deltaTime * speed);
    }

    private void ZoomIn()
    {
        if (cam.orthographicSize > cameraMin)
        {
            cam.orthographicSize -= 0.05f;

        }
    }

    private void ZoomOut()
    {
        if (cam.orthographicSize < cameraMax)
        {
            cam.orthographicSize += 0.05f;

        }
    }

    private void ResetCameraRotation()
    {
        cam.transform.position = camOriginalPos;
        cam.transform.rotation = camOriginalRot;
        cam.orthographicSize = originalSize;
        transform.position = originalPos;
        transform.rotation = originalRot;
    }
}

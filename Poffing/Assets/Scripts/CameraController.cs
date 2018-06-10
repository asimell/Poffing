﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;

    private Camera cam;
    private float xMin = 10f;
    private float xMax = 55f;
    private Vector3 originalPos;
    private Quaternion originalRot;

    // Use this for initialization
    void Start () {
        cam = GetComponentInChildren<Camera>();
        originalPos = cam.transform.position;
        originalRot = cam.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right ctrl"))
        {
            ResetCameraRotation();
            return;
        }

        float x = Input.GetAxis("CameraVertical");
        float currentRotationX = Mathf.RoundToInt(cam.transform.rotation.eulerAngles.x);
        if ((x > 0 && currentRotationX == xMax) || x < 0 && currentRotationX == xMin)
        {
            return;
        }

        Vector3 movement = new Vector3(x, 0f, 0f);
        cam.transform.RotateAround(Vector3.zero, movement, 20f * Time.deltaTime * speed);
        cam.transform.rotation = Quaternion.Euler(Mathf.Clamp(cam.transform.rotation.eulerAngles.x, xMin, xMax), 0f, 0f);
    }

    private void ResetCameraRotation()
    {
        cam.transform.position = originalPos;
        cam.transform.rotation = originalRot;
    }
}

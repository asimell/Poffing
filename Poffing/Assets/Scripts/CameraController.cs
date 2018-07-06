using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;

    private Camera cam;
    private readonly float xMin = 10f;
    private readonly float xMax = 55f;
    private readonly float cameraMin = 3f;
    private readonly float cameraMax = 8f;
    private float originalSize;
    private Vector3 originalPos;
    private Quaternion originalRot;
    

    // Use this for initialization
    void Start () {
        cam = GetComponentInChildren<Camera>();
        originalPos = cam.transform.position;
        originalRot = cam.transform.rotation;
        originalSize = cam.orthographicSize;
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
        transform.RotateAround(Vector3.zero, movementY, 20f * Time.deltaTime * speed);
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
        cam.transform.position = originalPos;
        cam.transform.rotation = originalRot;
        cam.orthographicSize = originalSize;
    }
}

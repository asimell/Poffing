using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;


    private float x;
    private float y;
    private Vector3 movement;
    private Camera cam;
    private float xMin = 10f;
    private float xMax = 60f;

	// Use this for initialization
	void Awake() {
		cam = GetComponentInChildren<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right ctrl"))
        {
            ResetCamera();
            return;
        }

        y = Input.GetAxis("CameraHorizontal");
        x = Input.GetAxis("CameraVertical");
        movement = new Vector3(x, y, 0);

        cam.transform.RotateAround(Vector3.zero, movement, 30f * Time.deltaTime * speed);
        float xrot = Mathf.Clamp(cam.transform.rotation.eulerAngles.x, xMin, xMax);
        cam.transform.rotation = Quaternion.Euler(xrot, cam.transform.rotation.eulerAngles.y, 0f);
        cam.transform.LookAt(Vector3.zero);
	}

    private void ResetCamera()
    {
        cam.transform.position = new Vector3(0f, 15f, -15f);
        cam.transform.rotation = Quaternion.Euler(45f, 0f, 0f);
    }
}

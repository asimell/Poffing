using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;

    private Camera cam;
    private float x;
    private float y;
    private Vector3 movement;
    private float xMin = 10f;
    private float xMax = 60f;

    // Use this for initialization
    void Start () {
        cam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right ctrl"))
        {
            ResetWorldRotation();
            return;
        }

        float x = Input.GetAxis("CameraVertical");
        Vector3 movement = new Vector3(x, 0f, 0f);
        cam.transform.RotateAround(Vector3.zero, movement, 30f * Time.deltaTime * speed);
    }

    private void ResetWorldRotation()
    {
        cam.transform.position = new Vector3(0f, 8f, -15f);
        cam.transform.rotation = Quaternion.Euler(25f, 0f, 0f);
    }
}

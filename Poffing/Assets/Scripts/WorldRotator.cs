using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotator : MonoBehaviour {

    //private Vector3 gravity;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("right ctrl"))
        {
            ResetWorldRotation();
        }

        //AdjustGravity();

        float y = Input.GetAxis("CameraHorizontal");
        //float x = Input.GetAxis("CameraVertical");
        //Vector3 movement = new Vector3(x, 0f, 0f);
        Vector3 localMovement = new Vector3(0f, y, 0f);

        //transform.Rotate(movement, Space.World);
        transform.Rotate(localMovement);
    }

    private void ResetWorldRotation()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    /*
    private void AdjustGravity()
    {
        gravity = transform.up.normalized * -9.8f;
        Physics.gravity = gravity;
    }
    */
}

using UnityEngine;

public class WorldRotator : MonoBehaviour {


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("right ctrl"))
        {
            ResetWorldRotation();
        }

        float y = Input.GetAxis("CameraHorizontal");
        Vector3 localMovement = new Vector3(0f, y, 0f);

        transform.Rotate(localMovement);
    }

    private void ResetWorldRotation()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

}

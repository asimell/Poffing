using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("PlayerHorizontal");
        float moveVertical = Input.GetAxisRaw("PlayerVertical");
        Vector3 v = new Vector3(moveHorizontal, 0.0f, -moveVertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + v);
        transform.rotation = Quaternion.LookRotation(v);
    }
}

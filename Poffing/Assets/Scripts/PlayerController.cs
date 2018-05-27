using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;

    private Rigidbody rb;
    private Vector3 oldPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        oldPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("PlayerHorizontal");
        float moveVertical = Input.GetAxisRaw("PlayerVertical");

        Move(moveHorizontal, moveVertical);
        //Turn(moveHorizontal, moveVertical);
        PlayerAction();
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        Vector3 v = new Vector3(moveHorizontal, 0.0f, -moveVertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + v);
    }

    private void Turn(float moveHorizontal, float moveVertical)
    {
        Vector3 relativePos = transform.position - oldPos;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }

    private void PlayerAction()
    {
        if (Input.GetKey(KeyCode.Space) && transform.position.y == 1)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}

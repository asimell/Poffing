﻿using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;

    protected Rigidbody rb;
    protected bool isOnGround = true;

    private Vector3 oldPos;
    private Vector3 boundary;
    private readonly float padding = 0.5f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        oldPos = transform.position;
        boundary = GameObject.FindGameObjectWithTag("WorldBoundary").GetComponent<Collider>().bounds.size;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("PlayerHorizontal");
        float moveVertical = Input.GetAxisRaw("PlayerVertical");

        Move(moveHorizontal, moveVertical);
        Turn(moveHorizontal, moveVertical);
    }

    void Update()
    {
        Vector3 groundLevel = new Vector3(rb.position.x, 1f, rb.position.z);
        isOnGround = Vector3.Distance(rb.position, groundLevel) <= 0.1f;
        PlayerAction();
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        float xBoundary = boundary.x / 2 - padding;    // World is a square, so no z-axis separation needed

        // Check where the player would move and move only if it will move the player outside the boundaries
        Vector3 newPositionZ = transform.position + Vector3.forward * moveVertical * speed * Time.deltaTime;
        Vector3 newPositionX = transform.position + Vector3.right * moveHorizontal * speed * Time.deltaTime;

        if (newPositionZ.z >= -xBoundary && newPositionZ.z <= xBoundary)
        {
            transform.Translate(Vector3.forward * moveVertical * speed * Time.deltaTime, Space.World);
        }
        if (newPositionX.x >= -xBoundary && newPositionX.x <= xBoundary)
        {
            transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime, Space.World);
        }
    }

    private void Turn(float moveHorizontal, float moveVertical)
    {
        Vector3 relativePos = new Vector3(transform.position.x + moveHorizontal, transform.position.y, transform.position.z + moveVertical);
        transform.LookAt(relativePos);
        oldPos = new Vector3(transform.position.x, oldPos.y, transform.position.z);
    }

    public virtual void PlayerAction()
    {

    }
}

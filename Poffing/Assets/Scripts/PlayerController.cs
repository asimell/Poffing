using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;

    protected Rigidbody rb;
    protected bool isOnGround = true;

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
    }

    void Update()
    {
        isOnGround = rb.position.y == 1;
        PlayerAction();
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        Vector3 v = new Vector3(moveHorizontal, 0.0f, -moveVertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + v);
    }

    private void Turn(float moveHorizontal, float moveVertical)
    {
        if (Mathf.Abs(moveHorizontal) > 0 || Mathf.Abs(moveVertical) > 0)
        {
            Vector3 relativePos = transform.position - oldPos;
            transform.rotation = Quaternion.LookRotation(relativePos);
            oldPos = transform.position;
        }
        
    }

    public virtual void PlayerAction()
    {

    }
}

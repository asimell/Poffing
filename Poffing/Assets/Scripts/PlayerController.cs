using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;
    public float height = 0.5f;
    public float heightPadding = 0.05f;
    
    protected Rigidbody rb;
    protected bool isOnGround = true;

    private GameObject cameraRig;
    private LayerMask ground;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        ground = LayerMask.GetMask("Ground");
        cameraRig = GameObject.Find("CameraRig");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("PlayerHorizontal");
        float moveVertical = Input.GetAxisRaw("PlayerVertical");

        // Jitter prevention
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, height + heightPadding, ground))
        {
            if (Vector3.Distance(transform.position, hit.point) < height)
            {
                Debug.Log("jeejee");
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * height, 5 * Time.deltaTime);
            }
        }*/

        Move(moveHorizontal, moveVertical);
        //MoveRigidBody(moveHorizontal, moveVertical);
        Turn(moveHorizontal, moveVertical);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapCharacter();
        }

        //Vector3 groundLevel = new Vector3(rb.position.x, 1f, rb.position.z);
        //isOnGround = Vector3.Distance(rb.position, groundLevel) <= 0.1f;
        PlayerAction();
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        //transform.Translate(Camera.main.transform.forward * moveVertical * speed * Time.deltaTime, Space.World);
        transform.Translate(cameraRig.transform.forward * moveVertical * speed * Time.deltaTime, Space.World);
        //transform.Translate(Camera.main.transform.right * moveHorizontal * speed * Time.deltaTime, Space.World);
        transform.Translate(cameraRig.transform.right * moveHorizontal * speed * Time.deltaTime, Space.World);
    }

    private void MoveRigidBody(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = (Camera.main.transform.forward * moveVertical + Camera.main.transform.right * moveHorizontal) * speed * Time.deltaTime;
        rb.MovePosition(movement);
    }

    private void Turn(float moveHorizontal, float moveVertical)
    {
        Vector3 relativePos = new Vector3(transform.position.x + moveHorizontal, transform.position.y, transform.position.z + moveVertical);
        transform.LookAt(relativePos);
    }
    
    private void SwapCharacter()
    {
        GameObject[] characters = GameController.controller.getGameCharacters();
        GameController.controller.currentCharacterIndex = (GameController.controller.currentCharacterIndex + 1) % characters.Length;
        Vector3 position = transform.position;
        Quaternion facing = transform.rotation;
        gameObject.SetActive(false);
        GameObject currentCharacter = characters[GameController.controller.currentCharacterIndex];
        currentCharacter.SetActive(true);
        currentCharacter.transform.position = position;
        currentCharacter.transform.rotation = facing;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    public virtual void PlayerAction()
    {

    }
}

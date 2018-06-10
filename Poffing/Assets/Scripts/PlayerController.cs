using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;

    protected Rigidbody rb;
    protected bool isOnGround = true;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapCharacter();
        }

        Vector3 groundLevel = new Vector3(rb.position.x, 1f, rb.position.z);
        isOnGround = Vector3.Distance(rb.position, groundLevel) <= 0.1f;
        PlayerAction();
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        transform.Translate(Vector3.forward * moveVertical * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime, Space.World);
    }

    private void Turn(float moveHorizontal, float moveVertical)
    {
        Vector3 relativePos = new Vector3(transform.position.x + moveHorizontal, transform.position.y, transform.position.z + moveVertical);
        transform.LookAt(relativePos);
    }
    
    private void SwapCharacter()
    {
        GameObject[] characters = GameController.controller.characters;
        GameController.controller.currentCharacterIndex = (GameController.controller.currentCharacterIndex + 1) % characters.Length;
        Vector3 position = transform.position;
        Quaternion facing = transform.rotation;
        gameObject.SetActive(false);
        GameObject currentCharacter = characters[GameController.controller.currentCharacterIndex];
        currentCharacter.SetActive(true);
        currentCharacter.transform.position = position;
        currentCharacter.transform.rotation = facing;
    }

    public virtual void PlayerAction()
    {

    }
}

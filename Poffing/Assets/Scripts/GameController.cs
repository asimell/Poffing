using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController controller;
    public GameObject world;
    public GameObject[] characters;

    private GameObject currentCharacter;
    private int currentCharacterIndex = 0;

	// Use this for initialization
	void Awake () {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
	}

    private void Start()
    {
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        currentCharacter = characters[0];
        currentCharacter.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapCharacter();
        }
	}

    public void SwapCharacter()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        Vector3 position = currentCharacter.transform.position;
        currentCharacter.SetActive(false);
        currentCharacter = characters[currentCharacterIndex];
        currentCharacter.SetActive(true);
        currentCharacter.transform.position = position;
    }
}

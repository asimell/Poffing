using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController controller;
    public GameObject[] characters;
    public int currentCharacterIndex = 0;

    private GameObject currentCharacter;

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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController controller;
    public GameObject[] characters; // Storing prefabs
    public int currentCharacterIndex = 0;

    private GameObject[] gameCharacters;    // Storing the actual gameobjects in the scene
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
        GameObject world = GameObject.FindGameObjectWithTag("World");
        gameCharacters = new GameObject[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            GameObject clone = (GameObject)Instantiate(characters[i], world.transform);
            gameCharacters[i] = clone;
            clone.SetActive(false);
        }

        currentCharacter = gameCharacters[0];
        currentCharacter.SetActive(true);
    }

    public GameObject[] getGameCharacters()
    {
        return gameCharacters;
    }

}

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
        Transform location = GameObject.FindGameObjectWithTag("SpawnLocation").transform;
        gameCharacters = new GameObject[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            GameObject clone = Instantiate(characters[i], location.position, location.rotation, world.transform);
            gameCharacters[i] = clone;
            clone.SetActive(false);
        }

        currentCharacter = gameCharacters[currentCharacterIndex];
        currentCharacter.SetActive(true);
    }

    public GameObject[] getGameCharacters()
    {
        return gameCharacters;
    }

}

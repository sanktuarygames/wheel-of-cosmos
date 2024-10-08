using System;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { set; get; }
    public List<Character> characters;
    public List<Adventure> adventures;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddCharacter(CharacterSO character)
    {
        // Instantiate new character
        Character newCharacter = new Character(character);
        characters.Add(newCharacter);
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);

    }


    public void SetupGame()
    {
        foreach (Character character in characters)
        {
            character.Initialize();
        }
        foreach (Adventure adventure in adventures)
        {
            // adventure.Initialize();
        }
    }

}

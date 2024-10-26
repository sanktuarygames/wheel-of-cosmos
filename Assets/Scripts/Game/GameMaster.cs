using System;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { set; get; }
    // Used in adventure view
    public List<Character> characters { get; private set; }
    public List<Adventure> adventures { get; private set; }
    // Used in character view
    public Character currentCharacter { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        characters = new List<Character>();
        adventures = new List<Adventure>();
        // DontDestroyOnLoad(gameObject);
    }

    public void AddCharacter(CharacterSO character)
    {
        // Instantiate new character
        GameObject newCharacterObject = new GameObject();
        newCharacterObject.name = "CHAR: " + character.name;
        Character newCharacter = newCharacterObject.AddComponent<Character>();
        newCharacter.Initialize(character);
        
        characters.Add(newCharacter);
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);
    }

    public void StartGame()
    {
        // Start game
        NavigationMaster.Instance.ShowView(View.Adventure);
    }

    public void SelectCharacter(string code)
    {
        currentCharacter = characters.Find(c => c.code == code);
        if (currentCharacter == null) return;
        NavigationMaster.Instance.ShowView(View.Character);
    }
}

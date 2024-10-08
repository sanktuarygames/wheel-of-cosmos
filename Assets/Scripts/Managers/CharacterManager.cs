using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Character[] characters;
    public Character currentCharacter = null;

    void Start()
    {
        if (characters.Length == 0) return;
        foreach (Character character in characters)
        {
            character.gameObject.SetActive(false);
        }
        ChangeCharacter(characters[0]);
    }
    
    public void ChangeCharacter(Character newCharacter) {
        currentCharacter = newCharacter;
        currentCharacter.Initialize();
    }

}

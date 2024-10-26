using System;
using System.Collections.Generic;
using UnityEngine;

// maybe it is a singleton, time will tell
public class GameSetupView : MonoBehaviour
{
    public List<CharacterSO> characters;
    public List<CharacterSO> selectedCharacters;
    public List<Adventure> adventures;

    public void StartGame()
    {
        foreach (CharacterSO character in selectedCharacters)
        {
            GameMaster.Instance.AddCharacter(character);
        }
        GameMaster.Instance.StartGame();
    }

    public void AddCharacter(string code)
    {
        CharacterSO character = characters.Find(c => c.code == code);
        selectedCharacters.Add(character);        
    }

    public void RemoveCharacter(string code)
    {
        CharacterSO character = characters.Find(c => c.code == code);
        selectedCharacters.Remove(character);
    }

}

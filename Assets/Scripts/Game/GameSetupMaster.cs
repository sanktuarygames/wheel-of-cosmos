using System;
using UnityEngine;

public class GameSetupMaster : MonoBehaviour
{
    public CharacterSO[] characters;
    public Adventure[] adventures;

    public void StartGame()
    {
        foreach (CharacterSO character in characters)
        {
            GameMaster.Instance.AddCharacter(character);
        }
    }

}

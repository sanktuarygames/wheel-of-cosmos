using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterEnum {
    Mony,
    BoobLeGun,
    Handam,
    Halfy
}
public class PlayerController : MonoBehaviour
{
    Dictionary<CharacterEnum, int> _characters = new Dictionary<CharacterEnum, int>(){
        {CharacterEnum.Mony, 0},
        {CharacterEnum.BoobLeGun, 1},
        {CharacterEnum.Handam, 2},
        {CharacterEnum.Halfy, 3},
    };
    private int characterIndex = 0;
    public GameObject[] characterWheels;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject wheel in characterWheels)
        {
            wheel.SetActive(false);
        }
        SelectCharacter(characterIndex);
    }

    public void SelectCharacter(int index)
    {
        Debug.Log("Selected character: " + index);
        foreach (GameObject wheel in characterWheels)
        {
            wheel.SetActive(false);
        }
        characterWheels[index].SetActive(true);
    }
}

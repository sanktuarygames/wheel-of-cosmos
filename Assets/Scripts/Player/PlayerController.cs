using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character {
    Mony,
    BoobLeGun,
    Handam,
    Halfy
}
public class PlayerController : MonoBehaviour
{
    Dictionary<Character, int> _characters = new Dictionary<Character, int>(){
        {Character.Mony, 0},
        {Character.BoobLeGun, 1},
        {Character.Handam, 2},
        {Character.Halfy, 3},
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

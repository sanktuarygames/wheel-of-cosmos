using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureView : MonoBehaviour
{

    public List<Adventure> adventures;
    public List<Adventure> revealedAdventures;


    void Start() {

    }
    
    public void ShowCharacterView(string code) {
        GameMaster.Instance.SelectCharacter(code);
    }

    public void SelectAdventure(Adventure adventure = null) {
        Debug.Log("Adventure selected" );
    }

}

using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string code;
    public string characterName;
    [SerializeField]
    public CharacterSO characterSO;
    public Wheel wheel;
    public Inventory inventory;
    public Arsenal arsenal;

    public int currentHealth = 15;
    public int currentMaxHealth = 15;
    public int currentArmor = 0;
    public int currentMaxArmor = 0;
    public Effect[] currentEffects;

    public void Initialize(CharacterSO characterSO)
    {
        this.characterSO = characterSO;
        LoadData();
    }

    private void LoadData()
    {
        code = characterSO.code;
        characterName = characterSO.displayName;
        currentHealth = characterSO.initialHealth;
        currentMaxHealth = characterSO.initialMaxHealth;
        currentArmor = characterSO.initialArmor;
        currentMaxArmor = characterSO.initialMaxArmor;
        currentEffects = characterSO.effects;

        wheel = new GameObject("Wheel").AddComponent<Wheel>();
        inventory = new GameObject("Inventory").AddComponent<Inventory>();
        arsenal = new GameObject("Arsenal").AddComponent<Arsenal>();
        wheel.Initialize(characterSO.initialWheel);
        inventory.Initialize(characterSO.initialInventory);
        arsenal.Initialize(characterSO.initialArsenal);
        wheel.transform.SetParent(transform);
        inventory.transform.SetParent(transform);
        arsenal.transform.SetParent(transform);
    }
}

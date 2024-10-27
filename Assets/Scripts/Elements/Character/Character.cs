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

    public int currentHealth = 15;
    public int currentMaxHealth = 15;
    public int currentArmor = 0;
    public int currentMaxArmor = 0;
    public Effect[] currentEffects;

    public void Initialize(CharacterSO characterSO)
    {
        this.characterSO = characterSO;
        LoadData();
        wheel = new GameObject("Wheel").AddComponent<Wheel>();
        inventory = new GameObject("Inventory").AddComponent<Inventory>();
        wheel.Initialize(characterSO.initialWheel);
        inventory.Initialize(characterSO.initialInventory);
        wheel.transform.SetParent(transform);
        inventory.transform.SetParent(transform);
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

        // Load the data into the wheel and inventory

        // wheel = new Wheel(characterSO.initialWheel);
        // inventory = new Inventory(characterSO.initialInventory);
        // wheel.Initialize(characterSO.initialWheel);
        // inventory.Initialize(characterSO.initialInventory);
    }
}

using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    [SerializeField]
    private CharacterSO characterSO;
    public Wheel wheel;
    public Inventory inventory;

    public int currentHealth = 15;
    public int currentMaxHealth = 15;
    public int currentArmor = 0;
    public int currentMaxArmor = 0;
    public Effect[] currentEffects;

    public Character(CharacterSO characterSO)
    {
        this.characterSO = characterSO;
        characterName = characterSO.name;
        currentHealth = characterSO.initialHealth;
        currentMaxHealth = characterSO.initialMaxHealth;
        currentArmor = characterSO.initialArmor;
        currentMaxArmor = characterSO.initialMaxArmor;
        currentEffects = characterSO.effects;

        Initialize();
    }

    public void Initialize()
    {
        // wheel = new Wheel(characterSO.initialWheel);
        // inventory = new Inventory(characterSO.initialInventory);
        wheel.Initialize(characterSO.initialWheel);
        inventory.Initialize(characterSO.initialInventory);
    }
}

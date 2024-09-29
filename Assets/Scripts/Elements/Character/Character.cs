using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public CharacterSO characterSO;
    public Wheel wheel;
    public Inventory inventory;

    private int currentHealth = 15;
    private int currentMaxHealth = 15;
    private int currentArmor = 0;
    private int currentMaxArmor = 0;
    private Effect[] currentEffects;

    public void Initialize()
    {
        wheel.Initialize(characterSO.initialWheelPrefab);
        Initialize(characterSO);
    }
    public void Initialize(CharacterSO characterSO)
    {
        inventory = Instantiate(characterSO.initialInventoryPrefab);
        currentHealth = characterSO.initialHealth;
        currentMaxHealth = characterSO.initialMaxHealth;
        currentArmor = characterSO.initialArmor;
        currentMaxArmor = characterSO.initialMaxArmor;
        currentEffects = characterSO.effects;
    }
}

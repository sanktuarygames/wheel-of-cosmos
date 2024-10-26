using System;
using UnityEngine;

public class WheelView : MonoBehaviour
{
    public Inventory inventory;
    public Wheel wheel;
    public int currentHealth = 0;
    public int currentMaxHealth = 0;
    public int currentArmor = 0;
    public int currentMaxArmor = 0;



    public void SetupView(Character character)
    {
        inventory = character.inventory;
        wheel = character.wheel;
        currentHealth = character.currentHealth;
        currentMaxHealth = character.currentMaxHealth;
        currentArmor = character.currentArmor;
        currentMaxArmor = character.currentMaxArmor;

        wheel.Initialize();
        inventory.Initialize();
    }


    public void SetupWheelView()
    {

    }

}

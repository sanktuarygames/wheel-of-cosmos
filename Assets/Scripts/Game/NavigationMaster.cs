using System;
using UnityEngine;

[Serializable]
public enum View
{
    MainMenu,
    GameSetup,
    Adventure,
    Character,
    SliceEdit,
    InventoryEdit
}

public class NavigationMaster : MonoBehaviour
{
    public static NavigationMaster Instance { set; get; }

    public GameObject mainMenuView;
    public GameObject gameSetupView;
    public GameObject adventureView;
    public GameObject characterView;
    public GameObject sliceEditView;
    public GameObject inventoryEditView;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ShowView(View.MainMenu);
    }

    public void ShowView(View view)
    {
        switch (view)
        {
            case View.MainMenu:
                ShowMainMenuView();
                break;
            case View.GameSetup:
                ShowGameSetupView();
                break;
            case View.Adventure:
                ShowAdventureView();
                break;
            case View.Character:
                ShowCharacterView();
                break;
            case View.SliceEdit:
                ShowSliceEditView();
                break;
            case View.InventoryEdit:
                ShowInventoryEditView();
                break;
        }
    }
    public void ShowMainMenuView()
    {
        mainMenuView.SetActive(true);
        gameSetupView.SetActive(false);
        adventureView.SetActive(false);
        characterView.SetActive(false);
        sliceEditView.SetActive(false);
        inventoryEditView.SetActive(false);
    }

    public void ShowGameSetupView()
    {
        mainMenuView.SetActive(false);
        gameSetupView.SetActive(true);
        adventureView.SetActive(false);
        characterView.SetActive(false);
        sliceEditView.SetActive(false);
        inventoryEditView.SetActive(false);
    }

    public void ShowAdventureView()
    {
        mainMenuView.SetActive(false);
        gameSetupView.SetActive(false);
        adventureView.SetActive(true);
        characterView.SetActive(false);
        sliceEditView.SetActive(false);
        inventoryEditView.SetActive(false);
    }

    public void ShowCharacterView()
    {
        mainMenuView.SetActive(false);
        gameSetupView.SetActive(false);
        adventureView.SetActive(false);
        characterView.SetActive(true);
        sliceEditView.SetActive(false);
        inventoryEditView.SetActive(false);
    }

    public void ShowSliceEditView()
    {
        mainMenuView.SetActive(false);
        gameSetupView.SetActive(false);
        adventureView.SetActive(false);
        characterView.SetActive(false);
        sliceEditView.SetActive(true);
        inventoryEditView.SetActive(false);
    }

    public void ShowInventoryEditView()
    {
        mainMenuView.SetActive(false);
        gameSetupView.SetActive(false);
        adventureView.SetActive(false);
        characterView.SetActive(false);
        sliceEditView.SetActive(false);
        inventoryEditView.SetActive(true);
    }
}

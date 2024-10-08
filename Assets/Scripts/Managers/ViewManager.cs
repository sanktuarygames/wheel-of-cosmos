using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewEnum { WheelEditView, SliceEditView, ArrowEditView, CharacterSelectView };
public class ViewManager : MonoBehaviour
{
    public ViewEnum currentView;

    [Header("Views")]
    [SerializeField] private GameObject wheelEditView;
    [SerializeField] private GameObject sliceEditView;
    [SerializeField] private GameObject arrowEditView;
    [SerializeField] private GameObject characterSelectView;

    void Start()
    {
        ShowCharacterSelectView();
    }

    public void ShowWheelEditView() {
        wheelEditView.SetActive(true);
        sliceEditView.SetActive(false);
        arrowEditView.SetActive(false);
        characterSelectView.SetActive(false);
        currentView = ViewEnum.WheelEditView;
    }

    public void ShowSliceEditView() {
        sliceEditView.SetActive(true);
        arrowEditView.SetActive(false);
        characterSelectView.SetActive(false);
        currentView = ViewEnum.SliceEditView;
    }

    public void ShowArrowEditView() {
        wheelEditView.SetActive(false);
        sliceEditView.SetActive(false);
        arrowEditView.SetActive(true);
        characterSelectView.SetActive(false);
        currentView = ViewEnum.ArrowEditView;
    }

    public void ShowCharacterSelectView() {
        wheelEditView.SetActive(false);
        sliceEditView.SetActive(false);
        arrowEditView.SetActive(false);
        characterSelectView.SetActive(true);
        currentView = ViewEnum.CharacterSelectView;
    }
}

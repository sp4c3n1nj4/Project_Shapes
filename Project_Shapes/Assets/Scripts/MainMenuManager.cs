using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject modeUI, loadUI;
    [SerializeField]
    private DontDestroyOnLoad dontDestroy;

    public bool editingMode;

    private void Start()
    {
        ModeUI();
    }

    public void SetMode(bool mode)
    {
        editingMode = mode;
    }

    public void ModeUI()
    {
        modeUI.SetActive(true);
        loadUI.SetActive(false);
    }

    public void LoadUI()
    {
        modeUI.SetActive(false);
        loadUI.SetActive(true);
    }

    public void TouchToggle(bool state)
    {
        dontDestroy.touchMode = state;
    }

}

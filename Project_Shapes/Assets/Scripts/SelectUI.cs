using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    [SerializeField]
    private GameObject createButton;

    private void OnEnable()
    {
        createButton.SetActive(GetComponentInParent<MainMenuManager>().editingMode);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileSelectButton : MonoBehaviour
{
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        string name = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;

        GameObject.FindObjectOfType<LoadFightManager>().SelectFile(name);
    }

}

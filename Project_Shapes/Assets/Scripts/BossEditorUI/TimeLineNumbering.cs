using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeLineNumbering : MonoBehaviour
{
    public TextMeshProUGUI FullText;
    public TextMeshProUGUI HalfText;

    public int index = 0;

    void Start()
    {
        FullText.text = index.ToString();
        HalfText.text = (index + 0.5f).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimelineElement : MonoBehaviour
{
    public int index;

    private void OnEnable()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnCLick);
    }

    private void OnCLick()
    {
        gameObject.GetComponentInParent<VisualizeBossTimeline>().SelectEntry(this.gameObject, index);
    }
}

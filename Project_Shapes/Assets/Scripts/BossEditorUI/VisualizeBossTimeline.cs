using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisualizeBossTimeline : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab, selectArrow, gridContent;
    [SerializeField]
    private BossFightManager manager;
    [SerializeField]
    private AbilityUI abilityEditor;

    private void Start()
    {
        PopulateTimeline();
    }

    public void PopulateTimeline()
    {
        foreach (Transform child in gridContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < manager.bossTimeline.Count; i++)
        {
            GameObject g = Instantiate(prefab, gridContent.transform);
            g.GetComponent<TimelineElement>().index = i;
            g.GetComponent<TimelineElement>().GetComponentInChildren<TextMeshProUGUI>().text = manager.bossTimeline[i].GetType().ToString().Remove(0, 4) + "   " + manager.bossTimeline[i].time.ToString("N2");
            
        }
    }

    public void SelectEntry(GameObject self, int index)
    {
        selectArrow.transform.SetParent(self.transform, false);
        selectArrow.SetActive(true);
        abilityEditor.gameObject.SetActive(true);
        abilityEditor.index = index;
        abilityEditor.UpdateEntry();
    }
}

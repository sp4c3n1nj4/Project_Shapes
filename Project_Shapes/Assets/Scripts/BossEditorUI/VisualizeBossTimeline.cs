using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private int indexSelected;

    private void Start()
    {
        PopulateTimeline();
    }

    public void PopulateTimeline()
    {
        manager.SortBossTimeline();

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
        indexSelected = index;
        selectArrow.transform.position = self.transform.position;
        selectArrow.SetActive(true);
        abilityEditor.gameObject.SetActive(true);
        abilityEditor.UpdateEntry(index);
    }

    public void DeleteEntry()
    {
        manager.bossTimeline.RemoveAt(indexSelected);
        abilityEditor.gameObject.SetActive(false);
        selectArrow.transform.position = Vector3.zero;
        selectArrow.SetActive(false);
        PopulateTimeline();
    }

    public void AddAttack() 
    {
        BossAttack b = new BossAttack();
        b.time = manager.bossTimeline.Last().time + 1f;
        manager.bossTimeline.Add(b);
        PopulateTimeline();
    }

    public void AddMove()
    {
        BossMove b = new BossMove();
        b.time = manager.bossTimeline.Last().time + 1f;
        manager.bossTimeline.Add(b);
        PopulateTimeline();
    }
}

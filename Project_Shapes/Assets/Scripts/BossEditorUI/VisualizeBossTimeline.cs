using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeBossTimeline : MonoBehaviour
{
    //get boss timeline
    //get max duration
    //make scroller

    //place items at spots
    //add infomtaion about items

    //update items shown with scroller
    [SerializeField]
    private GameObject ScrollContainer;
    [SerializeField]
    private GameObject GridPrefab;

    private void Start()
    {
        InstatiateTimeLineGrid(30f);
    }

    private void InstatiateTimeLineGrid(float fightDuration)
    {
        for (int i = 0; i < fightDuration; i++)
        {
            GameObject cell = Instantiate(GridPrefab);
            cell.transform.SetParent(ScrollContainer.transform, false);
            cell.GetComponent<TimeLineNumbering>().index = i + 1;
        }
    }
}

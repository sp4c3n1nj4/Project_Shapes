using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab, scrollList;
    [SerializeField]
    private TextMeshProUGUI text;

    public string fight = "";

    private void Start()
    {
        //load all fight files into the scrollable list
        PopulateList();
    }

    public void ConfirmLoadFight()
    {
        //load scene based on selected mode and pass on the selected fight to load

        //stuff

        if (gameObject.GetComponentInParent<MainMenuManager>().editingMode)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }        
    }

    public void CreateFight()
    {

    }

    public void SelectFile(string name)
    {
        fight = name;
        text.text = fight;
    }

    private void PopulateList()
    {
        //for each file found create a object for the player to select
        foreach (string name in FightFiles())
        {
            GameObject item = Instantiate(prefab, scrollList.transform);

            item.GetComponentInChildren<TextMeshProUGUI>().text = name;
        }
    }

    private string[] FightFiles()
    {
        //find all files local .bin files
        List<string> names = new List<string>();

        string path = Application.dataPath;
        path = path.Remove(path.Length - 7, 7);
        path += "/Fights";
        print("loading from file path: \n" + path);

        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo f in files)
        {
            names.Add(f.Name);
        }

        return names.ToArray();
    }
}

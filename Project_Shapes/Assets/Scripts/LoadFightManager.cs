using System.Collections;
using System.Collections.Generic;
//system.io needed to access the locally stored fight files
using System.IO;
//tmpro for UI elements
using TMPro;
//scenem management to change scenes
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab, scrollList;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private DontDestroyOnLoad dontDestroy;

    public string fight = "";

    private void Start()
    {
        //load all fight files into the scrollable list
        PopulateList();
    }

    public void ConfirmLoadFight()
    {
        //load scene based on selected mode and pass on the selected fight to load

        dontDestroy.fight = fight;

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
        SceneManager.LoadScene(1);
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

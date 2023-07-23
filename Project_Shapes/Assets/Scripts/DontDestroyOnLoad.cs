using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string fight;

    public bool touchMode = false;

    public bool editMode = true;

    private Scene scene;

    void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        scene = SceneManager.GetActiveScene();

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {
            case 0:
                break;
            case 1:
                FindObjectOfType<BossFightManager>().LoadBossTimeline(fight);
                FindObjectOfType<JoystickManager>().gameObject.SetActive(touchMode);
                break;
            case 2:
                FindObjectOfType<BossFightManager>().LoadBossTimeline(fight);
                FindObjectOfType<BossFightManager>().fightOver = true;
                FindObjectOfType<JoystickManager>().gameObject.SetActive(touchMode);
                
                break;
        }
    }
}

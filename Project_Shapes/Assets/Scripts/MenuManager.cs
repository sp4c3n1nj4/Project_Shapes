using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject VictoryS, DefeatS, RetryS;
    [SerializeField]
    private Image BossBar, PlayerBar;

    public void RetryButton()
    {
        if (FindObjectOfType<DontDestroyOnLoad>().editMode)
        {
            gameObject.SetActive(false);
        }
        else
            SceneManager.LoadScene(0);
    }

    public void VictoryScreen()
    {
        VictoryS.SetActive(true);
        RetryS.SetActive(true);
    }

    public void DefeatScreen()
    {
        DefeatS.SetActive(true);
        RetryS.SetActive(true);
    }

    public void SetPlayerHealthBar(float f)
    {
        f = Mathf.Clamp(f, 0, 1);
        PlayerBar.fillAmount = f;
    }

    public void SetBossHealthBar(float f)
    {
        f = Mathf.Clamp(f, 0, 1);
        BossBar.fillAmount = f;
    }
}

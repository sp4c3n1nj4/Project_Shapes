using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(FindObjectOfType<DontDestroyOnLoad>().touchMode);
    }
}

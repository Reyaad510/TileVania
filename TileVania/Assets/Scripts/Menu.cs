﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{


    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}

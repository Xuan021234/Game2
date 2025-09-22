using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene1 : MonoBehaviour
{
    //Starts

    private void Starts()
    {
        DontDestroyOnLoad(this);
    }

    //SceneChange
    public void SceneChange1(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}

 
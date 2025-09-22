using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}



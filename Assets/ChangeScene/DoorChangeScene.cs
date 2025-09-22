using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class DoorChangeScene : MonoBehaviour
{
    public string NextSceneName = "";
    public CinemachineVirtualCamera vcam;
    private void Start()
    {
        vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GoToNextScene());
        }
    }

    IEnumerator GoToNextScene()
    {
        while (vcam.m_Lens.OrthographicSize > 0f)
        {
            vcam.m_Lens.OrthographicSize -= 0.5f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene($"{NextSceneName}");
    }
}

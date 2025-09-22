using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

// The file name MUST be "Portal.cs"
public class Portal : MonoBehaviour
{
    [Tooltip("The exact name of the scene to load")]
    public string NextSceneName = "";

    [Tooltip("Drag the Cinemachine Virtual Camera you want to control here")]
    [SerializeField] private CinemachineVirtualCamera vcam;

    // This caches the wait time for better performance
    private WaitForSeconds transitionWait = new WaitForSeconds(0.1f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered is the player AND the camera has been assigned
        if (collision.gameObject.CompareTag("Player") && vcam != null)
        {
            StartCoroutine(GoToNextScene());
        }
        else if (vcam == null)
        {
            // This error helps you debug if you forget to assign the camera
            Debug.LogError("The Virtual Camera (vcam) has not been assigned on the Portal script!", this);
        }
    }

    private IEnumerator GoToNextScene()
    {
        // Loop until the camera has zoomed all the way in
        while (vcam.m_Lens.OrthographicSize > 0.1f)
        {
            // Decrease the size over time. Time.deltaTime makes it frame-rate independent.
            vcam.m_Lens.OrthographicSize -= 2f * Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure size is exactly 0 at the end
        vcam.m_Lens.OrthographicSize = 0f;

        yield return new WaitForSeconds(0.5f); // A brief pause after zooming

        SceneManager.LoadScene(NextSceneName);
    }
}



using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyScore : MonoBehaviour
{
    public int myPoints = 0;
    public TMP_Text uiPoints;
    public AudioClip coinSound;

    private void Start()
    {
        uiPoints.text = myPoints.ToString();
    }
    public void IncreasePoints()
    {
        myPoints++;
        uiPoints.text = myPoints.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().clip = coinSound;
            GetComponent<AudioSource>().Play();
            IncreasePoints();
            Destroy(collision.gameObject);
        }
    }
}

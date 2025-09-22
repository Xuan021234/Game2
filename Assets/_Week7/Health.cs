using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int FullHP = 3;
    public int CurrentHP = 3;
    [HideInInspector]
    public bool CanITakeDamage = true;
    public List<SpriteRenderer> HPHearts;
    public Color DamageColor;
    public AudioClip heartSound;
    public GameObject gameOverMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            CurrentHP = 0;
        }
        else if(collision.gameObject.CompareTag("Trap") && CanITakeDamage)
        {
            StartCoroutine(TakeDamage());
        }
        else if(collision.gameObject.CompareTag("Monster") && CanITakeDamage)
        {
            StartCoroutine(TakeDamage());
        }
        else if(collision.gameObject.CompareTag("Heal"))
        {
            GetComponent<AudioSource>().clip = heartSound;
            GetComponent<AudioSource>().Play();
            HealHP();
            Destroy(collision.gameObject);
        }
    }

    public void HealHP()
    {
        if (CurrentHP >= FullHP) return;

        CurrentHP++;
        HPHearts[CurrentHP - 1].color = Color.white;
    }

    private void Update()
    {
        if(CurrentHP <= 0)
        {
            this.gameObject.SetActive(false);
            gameOverMenu.SetActive(true);
        }
    }
    public void RefillHP()
    {
        CanITakeDamage = true;
        CurrentHP = FullHP;
        foreach (var heart in HPHearts)
        {
            heart.color = Color.white;
        }
    }

    IEnumerator TakeDamage()
    {
        CanITakeDamage = false;
        HPHearts[CurrentHP - 1].color = Color.black;
        CurrentHP--;
        GetComponent<SpriteRenderer>().color = DamageColor;
        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        CanITakeDamage = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {
        gameOverMenu.SetActive(false);
        GetComponent<Spawnpoint>().Reborn();
        this.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int MonsterHP = 1;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    public void MonsterTakeDamage(GameObject bullet)
    {
        StartCoroutine(TakeDamageVisual(bullet));
    }

    IEnumerator TakeDamageVisual(GameObject bullet)
    {
        MonsterHP--;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.red;
        Destroy(bullet);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        if (MonsterHP <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}

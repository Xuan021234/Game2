using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float Direction = 1f;
    /// <summary>
    /// 0 is nothing equipped,1 is gun,2 is sword, 3 is vacuum
    /// </summary>
    public int CurrentlyEquipped;
    void Start()
    {
        transform.localScale = new(Direction, transform.localScale.y, transform.localScale.z);
        if (CurrentlyEquipped == 2)
        {
            transform.position = new(transform.position.x + Direction, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        //Move the transform ( x , y , z)
        if(CurrentlyEquipped == 1)
        {
            transform.Translate(5f * Time.deltaTime * Direction,0,0 );
        }
        else if (CurrentlyEquipped == 2)
        {
            StartCoroutine(SlashAndDie());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            // if hit the monster then kill the monster and the bullet
            collision.gameObject.GetComponent<MonsterHealth>().MonsterTakeDamage(this.gameObject);
        }
    }

    IEnumerator SlashAndDie()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}

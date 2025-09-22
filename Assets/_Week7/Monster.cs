using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int MovingRange = 3;
    public SpriteRenderer sprite;
    Vector3 originalPosition;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalPosition = transform.position;
        StartCoroutine(MoveLeftRight());
    }

    IEnumerator MoveLeftRight()
    {
        while (true)
        {
            float leftPos = originalPosition.x - MovingRange;
            float rightPos = originalPosition.x + MovingRange;
            int num;
            if (transform.position.x == originalPosition.x) num = Random.Range(0, 2);
            else if (transform.position.x >= rightPos) num = 0;
            else if (transform.position.x <= leftPos) num = 1;
            else num = Random.Range(0, 2);
            if (num == 0)
            {
                //move left
                var pos = transform.position.x - 1;
                while (transform.position.x >= pos)
                {
                    sprite.flipX = false;
                    transform.position = new(transform.position.x + (Time.deltaTime * -1), transform.position.y);
                    yield return null;
                }
            }
            else
            {
                //move right
                var pos = transform.position.x + 1;
                while (transform.position.x <= pos)
                {
                    sprite.flipX = true;
                    transform.position = new(transform.position.x + (Time.deltaTime * 1), transform.position.y);
                    yield return null;
                }
            }
            yield return null;
        }
    }
}

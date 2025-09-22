using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    [SerializeField] GameObject AskToTalk;
    [SerializeField] GameObject TalkingBox;
    GameObject CreatedObject;
    bool canTalkHere = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CreatedObject = Instantiate(AskToTalk,new Vector3(transform.position.x,transform.position.y+1,0),Quaternion.identity);
            canTalkHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(CreatedObject);
        TalkingBox.SetActive(false);
        canTalkHere = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canTalkHere == true)
        {
            if(TalkingBox.activeInHierarchy)
            {
                TalkingBox.SetActive(false);
            }
            else
            {
                TalkingBox.SetActive(true);
            }
        }
    }
}

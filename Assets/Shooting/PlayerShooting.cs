using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerShooting : MonoBehaviour
{
    public bool CanChangeWeapon = false;
    /// <summary>
    /// 0 is nothing equipped,1 is gun,2 is sword, 3 is vacuum
    /// </summary>
    public int CurrentlyEquipped;
    //add and remove equipment picked up to use
    List<int> equipmentList;
    //GUN SHOOTING
    public int MaximumBullet;
    [SerializeField] GameObject BulletPrefab;
    [HideInInspector]
    public List<GameObject> currentBullet;

    //SWORD SLASH
    [SerializeField] GameObject SlashPrefab;


    void Start()
    {
        equipmentList = new();
        equipmentList.Add(0);
    }
    // Update is called once per frame
    void Update()
    {
        //IF you press Q check inventory
        if(Input.GetKeyDown(KeyCode.Q) && CanChangeWeapon)
        {
            var currentIndex = equipmentList.IndexOf(CurrentlyEquipped);
            if(equipmentList[currentIndex] == equipmentList.Last())
            {
                CurrentlyEquipped = 0;
            }
            else
            {
                CurrentlyEquipped = equipmentList[currentIndex + 1];
            }

            Debug.LogError($"{CurrentlyEquipped}");
        }
        //If you press C
        if(Input.GetKeyDown(KeyCode.C))
        {
            //where is my player
            var myPosition = transform.position;
            switch (CurrentlyEquipped)
            {
                case 1:
                    //if you have more than 2 bullet
                    if (currentBullet.Count >= MaximumBullet)
                    {
                        //destroy the first bullet
                        Destroy(currentBullet[0]);
                        currentBullet.Remove(currentBullet[0]);
                    }

                    //make a bullet at my player position
                    var newBullet = Instantiate(BulletPrefab, myPosition, Quaternion.identity);
                    newBullet.GetComponent<Bullet>().Direction = transform.localScale.x;
                    currentBullet.Add(newBullet);
                    break;
                case 2:
                    //if you have more than 2 bullet
                    if (currentBullet.Count >= MaximumBullet)
                    {
                        //destroy the first bullet
                        Destroy(currentBullet[0]);
                        currentBullet.Remove(currentBullet[0]);
                    }

                    //make a bullet at my player position
                    var newSlash = Instantiate(SlashPrefab, myPosition, Quaternion.identity);
                    newSlash.GetComponent<Bullet>().Direction = transform.localScale.x;
                    currentBullet.Add(newSlash);
                    break;
                case 3:
                    //MAKE Vacuum here
                    break;
                default:
                    Debug.LogError("Unequiped");
                    break;
            }
            
        }
    }
}

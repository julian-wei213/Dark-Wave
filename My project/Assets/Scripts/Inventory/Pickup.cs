using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itembutton;


    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            /* for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false) {
                    inventory.isFull[i] = true;
                    
                    Instantiate(itembutton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                } 
            } */

            if (itembutton.CompareTag("Main Weapon")) {
                for (int i = 0; i < inventory.Main.Length; i++)
                {
                    if (inventory.MainIsFull[i] == false) {
                        inventory.MainIsFull[i] = true;
                        Instantiate(itembutton, inventory.Main[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            } else if (itembutton.CompareTag("Side Arm")) {
                for (int i = 0; i < inventory.Side.Length; i++)
                {
                    if (inventory.SideIsFull[i] == false) {
                        inventory.SideIsFull[i] = true;
                        Instantiate(itembutton, inventory.Side[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            } else {
                for (int i = 0; i < inventory.Consumable.Length; i++)
                {
                    if (inventory.ConsumableIsFull[i] == false) {
                        inventory.ConsumableIsFull[i] = true;
                        Instantiate(itembutton, inventory.Consumable[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }
    
}

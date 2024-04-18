using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConSlot : MonoBehaviour
{

    private Inventory inventory;
    public int i = 0;
    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update() {
        if (transform.childCount <= 0) {
            inventory.ConsumableIsFull[i] = false;
        }
    }
    public void Drop_Item() {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}

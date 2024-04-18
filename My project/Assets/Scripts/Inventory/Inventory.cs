using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public bool[] MainIsFull;
    public bool[] SideIsFull;
    public bool[] ConsumableIsFull;
    public GameObject[] Main;
    public GameObject[] Side;
    public GameObject[] Consumable;
    public int inv_size;

    private void Start() {
        inv_size = Main.Length + Side.Length + Consumable.Length;
    }

    private void Update() {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private Player player;
    private Inventory inventory;
    private Store store;
    private Canvas canvas;
    private bool isON = false;
    public bool InStore = false;

    private void Start() {
        store = GetComponent<Store>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        inventory = player.GetComponent<Inventory>();
        canvas = GameObject.Find("Canvasstore").GetComponent<Canvas>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isON) {
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            PauseGame();
        }

        if (Time.timeScale == 0) {
            InStore = true;
        } else {
            InStore = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            store.transform.GetChild(0).gameObject.SetActive(false);
        }

        isON = false;
    }

    public void Turnoff() {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        Unpause();
    }

    private void OnTriggerStay2D(Collider2D other) {
        isON = true;

        if (other.CompareTag("Player")) {
            store.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    private void PauseGame() {
        Time.timeScale = 0;
    }

    private void Unpause() {
        Time.timeScale = 1;
    }
} 

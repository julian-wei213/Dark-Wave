using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpdisplay : MonoBehaviour
{
    private Player player;
    private int maxhp;
    private int currhp;
    public Text HP;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currhp = player.Health;
        maxhp = player.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currhp = player.Health;
        maxhp = player.MaxHealth;

        string str = currhp + "/" + maxhp;
        HP.text = str;
    }
}

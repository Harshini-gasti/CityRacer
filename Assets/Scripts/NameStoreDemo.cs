using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static AgeRestrictionDemo;
public class NameStoreDemo : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Text nameText;

    void Start()
    {
        Player p = RetrieveData();
        DisplayData(p);
    }

    // Update is called once per frame
    private Player RetrieveData()
    {
        Player p = new Player();
        p.name = PlayerPrefs.GetString("PlayerName", "");
        p.age = PlayerPrefs.GetInt("PlayerAge", 0);
        return p;
    }

    private void DisplayData(Player p)
    {
        nameText.text = "WELCOME "+ p.name+ "!";
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using static UnityEditor.FilePathAttribute;
using UnityEditor;
public class AgeRestrictionDemo : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_InputField ageInput;

    // Start is called before the first frame update
    public void SubmitBtn()
    {
        string Name = nameInput.text;
        int age = int.Parse(ageInput.text);
        SavePlayerData(new Player(Name, age));
        if (age < 18)
        {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;

#endif
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("ClassTask1");
        }
    }
    private void SavePlayerData(Player e)
    {
        PlayerPrefs.SetString("PlayerName", e.name);
        PlayerPrefs.SetInt("PlayerAge", e.age);
        PlayerPrefs.Save();
    }

 [Serializable]
  public class Player
    {
        public string name;
        public int age;

        public Player(string name, int age)
        {
            this.name = name;
            this.age = age;

        }
        public Player()
        {
            this.name = null;
            this.age = 0;


        }
    }
}

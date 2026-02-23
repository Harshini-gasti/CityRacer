using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ClassTask1UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text GoldCoin;
    public Text SilverCoin;
    public Slider sld_fuel;
    public Slider sld_damage;
    private int fuelValue, damage_value;
    //StoreDataClassTask1 storeDataClassTask;
    public static ClassTask1UIManager instance;


    void Awake()
    {
        instance = this;
        LoadData();
    }
    //public Button btn;
    void Start()
    {
        // StartCoroutine(FuelUpdate());
        //storeDataClassTask = GetComponent<StoreDataClassTask1>();
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        GoldCoin.text = CarManager.goldCoinCounter.ToString();
        SilverCoin.text = CarManager.silverCoinCounter.ToString();
        fuelValue = CarManager.fuel_value;
        damage_value = CarManager.damageIndicator;
        FuelSliderValueChange(fuelValue);
        DamageSliderValueChange(damage_value);
    }

    void FuelSliderValueChange(int value)
    {
        sld_fuel.value = value;
    }


    void DamageSliderValueChange(int damage)
    {
        sld_damage.value = damage;
    }

     public void QuitAndSave()
     {
         //storeDataClassTask.saveData();
         //StoreDataClassTask1.saveData();
 #if UNITY_EDITOR
         EditorApplication.isPlaying = false;
 #endif
         Application.Quit();
     }

    

    [Serializable]
    public class CarData
    {
        public int GoldCoin;
        public int SilverCoin;
        public int fuelValue;
        public int damage_value;
    }


    public void SaveData()
    {
        CarData carData = new CarData();
        carData.GoldCoin = CarManager.goldCoinCounter;
        carData.SilverCoin = CarManager.silverCoinCounter;
        carData.fuelValue = CarManager.fuel_value;
        carData.damage_value = CarManager.damageIndicator;

        string jsonData = JsonUtility.ToJson(carData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            CarData carData = JsonUtility.FromJson<CarData>(json);

            CarManager.goldCoinCounter = carData.GoldCoin;
            CarManager.silverCoinCounter = carData.SilverCoin;
            CarManager.fuel_value = carData.fuelValue;
            CarManager.damageIndicator = carData.damage_value;

        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}

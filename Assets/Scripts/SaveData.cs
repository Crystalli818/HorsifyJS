using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public static Horse tester = new Horse();
    public static SaveHorse savedata = new SaveHorse();
    public static void SaveToJson()
    {
        string dataToStore = JsonUtility.ToJson(savedata);
        string filePath = Application.persistentDataPath +"/TestData.json";
    Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, dataToStore);
    }
    public static void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/TestData.json";
        string readData = System.IO.File.ReadAllText(filePath);
        savedata = JsonUtility.FromJson<SaveHorse>(readData);
    }
    public static void SavedNewHorseToJson(Horse horse){

        savedata.horses.Add(horse);
        SaveToJson();
    }

    void Start(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        { 
            SaveToJson();
        }
if(Input.GetKeyDown(KeyCode.L))
        { 
            LoadFromJson();
        }
        
    }
}
[System.Serializable]
public class Horse{
    public string horseName;
    public int age;
    public string gender;
    public string life;
    public string medication;
    public string features;

    public Horse(string newHorseName, int newAge,
     string newGender, string newLife, string newMeds, string newFeatures){
        this.horseName = newHorseName;
        this.age = newAge;
        this.gender = newGender;
        this.life = newLife;
        this.medication = newMeds;
        this.features = newFeatures;
     }

    public Horse()
    {
        this.horseName = "New Horse";
        this.age = 84910;
        this.gender = "baby";
        this.life = "great";
        this.medication = "anti hyper pills";
        this.features = "pretty boy";   
    }

}
[System.Serializable]
public class SaveHorse{

public List<Horse> horses = new List<Horse>();
}
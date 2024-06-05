using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StableManager : MonoBehaviour
{

    public string savePath = "savedata";
    public GameObject horse;
    public RuntimeAnimatorController animationController;

    public TMP_Text nameText;

    public GameObject stableUI;
    public GameObject emptyStableUI;



    private int CurrentHorseIndex = -1;
    public List<string> HorseNames;


    public void NextHorse()
    {
        CurrentHorseIndex = (CurrentHorseIndex + 1) % HorseNames.Count;
        print(HorseNames[CurrentHorseIndex]);
        Load(HorseNames[CurrentHorseIndex]);
        print(HorseNames[CurrentHorseIndex]);
    }

    public void PrevHorse()
    {
        CurrentHorseIndex--;
        if(CurrentHorseIndex < 0)
        {
            CurrentHorseIndex = HorseNames.Count - 1;
        }
        //CurrentHorseIndex = (CurrentHorseIndex - 1) % HorseNames.Count;
        print(HorseNames[CurrentHorseIndex]);
        Load(HorseNames[CurrentHorseIndex]);
        print(HorseNames[CurrentHorseIndex]);
    }


    public void SelectHorse()
    {
        PlayerPrefs.SetString("current_horse", HorseNames[CurrentHorseIndex]);
        PlayerPrefs.Save();
        SceneManager.LoadScene("DressUp");
    }


    public void Load(string horsename)
    {

        string jsonData = PlayerPrefs.GetString(horsename + ".horse");
        print(jsonData);
        nameText.text = horsename;


        if (!string.IsNullOrEmpty(jsonData))
        {
            print("Delete Horse");
            HorseSceneController horseController = horse.GetComponent<HorseSceneController>();
            horseController.DeleteHorse();

            print("Load from json Commented");
            //HorseSceneController horseSceneController = JsonUtility.FromJson<HorseSceneController>(jsonData);
            JsonUtility.FromJsonOverwrite(jsonData, horseController);
            print("Reset Commented");
            horseController.Reset();
            print("set animationController commented");
            horseController.horseObject.GetComponent<Animator>().runtimeAnimatorController = animationController;
        }
    }


    public void NewHorse()
    {
        HorseSceneController horseController = horse.GetComponent<HorseSceneController>();
        horseController.Reset();
    }


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("Mickey.horse");
        //PlayerPrefs.DeleteKey("Goofy.horse");
        //PlayerPrefs.DeleteKey(".horse");
        //PlayerPrefs.SetString("horse_names", "ABC");
        //PlayerPrefs.DeleteAll();

        string horse_names_string = PlayerPrefs.GetString("horse_names");
        if (horse_names_string.Length > 0) {
            //NewHorse();
            CurrentHorseIndex = 0;
            HorseNames = new List<string>(horse_names_string.Split(','));

            Load(HorseNames[0]);

            stableUI.SetActive(true);
            emptyStableUI.SetActive(false);

        }
        else
        {
            stableUI.SetActive(false);
            emptyStableUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

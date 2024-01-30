using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SavingScript : MonoBehaviour
{

    public string savePath = "savedata";
    public string horsename = "Minie";
    public bool newHorse = false;
    public GameObject horse;

    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_InputField genderInput;
    public TMP_InputField medicationInput;
    public TMP_InputField featuresInput;


    public GameObject messageCanvas;
    public TMP_Text messageText;



    IEnumerator showandhideMessage(string message, float secondsToWait)
    {
        if (!messageCanvas.activeSelf)
        {
            messageText.text = message;
            messageCanvas.SetActive(true);
            yield return new WaitForSeconds(secondsToWait);
            messageCanvas.SetActive(false);

        }
    }


    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (newHorse)
        {
            NewHorse();
            messageCanvas.SetActive(false);
        }
        else {
            horsename = PlayerPrefs.GetString("current_horse");
            PlayerPrefs.DeleteKey("current_horse");
            Load();
        }
    }

    public void Save()
    {

        HorseSceneController horseSceneController = horse.GetComponent<HorseSceneController>();

        if (newHorse)
        {
            print("New");
            if (string.IsNullOrEmpty(nameInput.text) ||
                string.IsNullOrEmpty(ageInput.text) ||
                string.IsNullOrEmpty(genderInput.text)
                )
            {
                print("Missing Input");
                StartCoroutine(showandhideMessage("Check the Form", 2));
                return;
            }

            if (PlayerPrefs.HasKey(nameInput.text + ".horse"))
            {
                print("Name is Taken");
                StartCoroutine(showandhideMessage("Check the Form", 2));
                return;
            }

            print(nameInput.text);
            print(ageInput.text);
            print(genderInput.text);

            // Add Horse to Prefs
            horseSceneController.horseData["name"] = nameInput.text;
            horseSceneController.horseData["age"] = ageInput.text;
            horseSceneController.horseData["gender"] = genderInput.text;
            horseSceneController.horseData["medication"] = medicationInput.text;
            horseSceneController.horseData["features"] = featuresInput.text;

            horseSceneController.horseName = nameInput.text;
            horseSceneController.age = ageInput.text;
            horseSceneController.gender = genderInput.text;
            horseSceneController.medication = medicationInput.text;
            horseSceneController.features = featuresInput.text;

        }

        string jsonData = JsonUtility.ToJson(horseSceneController);
        PlayerPrefs.SetString(nameInput.text + ".horse", jsonData);

        // Update Prefs with horse's name
        string horse_names_string = PlayerPrefs.GetString("horse_names");
        print(horse_names_string);
        if (horse_names_string.Length == 0)
        {
            PlayerPrefs.SetString("horse_names", nameInput.text);
        }
        else
        {
            List<string> horseNames = new List<string>(horse_names_string.Split(','));
            if (horseNames.Contains(nameInput.text))
            {
                // Will not add horse
            }
            else
            {
                horse_names_string = horse_names_string + "," + nameInput.text;
                PlayerPrefs.SetString("horse_names", horse_names_string);
            }

        }


        PlayerPrefs.Save();
        SceneManager.LoadScene("menu");

    }

    public void NewHorse()
    {
        HorseSceneController horseController = horse.GetComponent<HorseSceneController>();
        horseController.Reset();
    }

    public void Load()
    {
        string jsonData = PlayerPrefs.GetString(horsename + ".horse");
        print(jsonData);

        if (!string.IsNullOrEmpty(jsonData))
        {
            HorseSceneController horseController = horse.GetComponent<HorseSceneController>();
            horseController.DeleteHorse();

            //HorseSceneController horseSceneController = JsonUtility.FromJson<HorseSceneController>(jsonData);
            JsonUtility.FromJsonOverwrite(jsonData, horseController);

            horseController.Reset();
        }
    }
}

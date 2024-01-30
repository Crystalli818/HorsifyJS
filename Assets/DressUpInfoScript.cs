using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DressUpInfoScript : MonoBehaviour
{
    public HorseSceneController horse;
    public TMP_Text infoText;
    public GameObject infoPanel;
    public TMP_Text nameText;

    public void Start()
    {
        string info = "";
        info += "Name: " + horse.horseName + "\n";
        info += "Age: " + horse.age + "\n";
        info += "Gender: " + horse.gender + "\n";
        info += "Medication: " + horse.medication + "\n";
        info += "Features: " + horse.features + "\n";

        infoText.text = info;
        nameText.text = horse.horseName;
        HidePanel();
    }

    public void ShowPanel() { infoPanel.SetActive(true); }
    public void HidePanel() { infoPanel.SetActive(false); }

}

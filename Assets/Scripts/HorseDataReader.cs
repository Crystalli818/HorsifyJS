using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HorseDataReader : MonoBehaviour
{
    public HorseStats currentHorse;

    public TMP_Text HorseName;
    public TMP_Text HorseAge;
    public TMP_Text HorseGender;
    public TMP_Text HorseLife;
    public TMP_Text HorseMedication;
    public TMP_Text HorseFeatures;
    public Image HorseImage;

    void Start(){
        LoadHorseData(currentHorse);
    }

    public void LoadHorseData(HorseStats CurrentStats){
        HorseName.text = "Name " + CurrentStats.HorseName;
        HorseAge.text = "Age " + CurrentStats.HorseAge.ToString();
        HorseGender.text = "Gender " + CurrentStats.HorseGender;
        HorseLife.text = "Life " + CurrentStats.HorseLife;
        HorseMedication.text = "Medication " + CurrentStats.HorseMedication;
        HorseFeatures.text = "Features " + CurrentStats.HorseFeatures;
    }
}

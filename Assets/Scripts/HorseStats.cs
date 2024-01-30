using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/HorseData")]
public class HorseStats : ScriptableObject
{
   public string HorseName;
   public int HorseAge;
   public string HorseGender;
   [TextAreaAttribute]
   public string HorseFeatures;
   public string HorseMedication;
   public string HorseLife;
   public string HorsePic;
}
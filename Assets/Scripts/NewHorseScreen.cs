using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewHorseScreen : MonoBehaviour
{
    public Horse ourNewHorse;
    // Start is called before the first frame update
    void Start()
    {
    ourNewHorse = new Horse();    
    }
    
    public void ChangeName(string input){
        ourNewHorse.horseName = input;
    }
    public void ChangeAge(string input){
        int.TryParse(input, out ourNewHorse.age);
    }
    public void ChangeGender(string input){
        ourNewHorse.gender = input;
    }
    public void ChangeMedication(string input){
        ourNewHorse.medication = input;
    }
    public void ChangeFeatures(string input){
        ourNewHorse.features = input;
    }
    public void ChangeLife(string input){
        ourNewHorse.life = input;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReturnToScreen(bool willsave)
    {
        if(willsave){
    // save our new horse 
            SaveData.SavedNewHorseToJson(ourNewHorse); 
        }
        SceneManager.LoadScene(1);

    }

}

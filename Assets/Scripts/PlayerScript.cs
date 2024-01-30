using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    int[] numbers = {5,6,7,8,9,10};
    string[] names = {"Ollie", "Squiggles", "Amber", "Lucia"};
    // Start is called before the first frame update
    void Start()
    {
    // for loop example
        for(int i = 0; i< names.Length; i++){
            print(names [i]);
        }
    //  for each loop example
        foreach(string horse in names){

            print(horse);
        }
         int[] numbers = {5,6,7,8,9,10};
    float[] weight = {1.3f, 1.5f, 1.7f, 1.9f};

    // for loop example
        for(int i = 0; i< weight.Length; i++){
            print(weight [i]);
        }
    //  for each loop example
        foreach(float horse in weight){

            print(horse);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

            print("Key down");
        }
         else if(Input.GetKeyUp(KeyCode.Space)){

            print("Key Up");
        }
    }

    public void OllieIsChonky(string f){
        print("Hi its me, "+f);    
        return ;
    }

}

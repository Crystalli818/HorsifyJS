using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DressUp : MonoBehaviour
{
    public GameObject[] clothe; //= new GameObject[];
    GameObject currentClothes;
       // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
  
  }

    public void BackButton()
    {
        //save horse clothe onto horse

        SceneManager.LoadScene(1);
        
    }
    public void ClotheLeftButton()
    {
        int index = System.Array.IndexOf(clothe, currentClothes);
        index--;
        if(index < 0)
        {
            index = clothe.Length - 1;
        }
        currentClothes = clothe[index];
    // put clothe on horse here
        
    }
    public void ClotheRightButton()
    {
        
        int index = System.Array.IndexOf(clothe, currentClothes);
        index++;
        if(index >= clothe.Length)
        {
            index = 0;
        }
        currentClothes = clothe[index];
    // put clothe on horse here

        
    }
}



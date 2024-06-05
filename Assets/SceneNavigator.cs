using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("menu");
    }

    public void GoToStableScene()
    {
        SceneManager.LoadScene("StableScene");
    }

    public void GoToNewHorseScene()
    {
        //SceneManager.LoadScene("New Horse Scene");
        SceneManager.LoadScene("NewHorse");
    }

    public void GoToDressUpScene()
    {
        SceneManager.LoadScene("DressUp");
    }


    public void GoToVetOfficeScene()
    {
        SceneManager.LoadScene("VetOffice");
    }


}

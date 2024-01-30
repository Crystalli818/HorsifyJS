using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSceneController : MonoBehaviour
{

    public GameObject horseObject;
    public GameObject[] horseList;
    public int currentPrefabIndex = 0;


    void Start()
    {
        InstantiatePrefab(currentPrefabIndex);
    }

    public void NextHorse() {
        Destroy(transform.GetChild(0).gameObject);

        // Switch to the next prefab
        currentPrefabIndex = (currentPrefabIndex + 1) % horseList.Length;

        // Instantiate the new prefab
        InstantiatePrefab(currentPrefabIndex);
    }


    public void PrevHorse()
    {
        Destroy(transform.GetChild(0).gameObject);

        // Switch to the next prefab
        currentPrefabIndex--;
        if(currentPrefabIndex < 0)
        {
            currentPrefabIndex = horseList.Length - 1;
        }

        // Instantiate the new prefab
        InstantiatePrefab(currentPrefabIndex);
    }




    private void InstantiatePrefab(int prefabIndex)
    {
        // Create and parent the new prefab
        GameObject newPrefab = Instantiate(horseList[prefabIndex], transform.position, Quaternion.identity);
        newPrefab.transform.SetParent(transform);
        newPrefab.transform.Translate(Vector3.down);
    }

}

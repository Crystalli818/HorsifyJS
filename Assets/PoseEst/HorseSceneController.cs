using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorseSceneController : MonoBehaviour
{



    public Transform headPosition;
    public RuntimeAnimatorController animatorController;

    public GameObject horseObject;

    public GameObject[] horseList;
    public List<string> hatList = new List<string>(){
        "",
        "VikingHelmet",
        "Sombrero",
        "PoliceCap",
        "PajamaHat",
        "MinerHat",
        "MagicianHat",
        "Crown",
        "CowboyHat",
        };

    public Dictionary<string, string> horseData = new Dictionary<string, string>();
    public string horseName;
    public string age;
    public string gender;
    public string medication;
    public string features;



    public int currentPrefabIndex = 0;
    public int currentHatPrefabIndex = 1;


    public GameObject selectedJoint;
    public float rotationSpeed = 5f;
    public Vector3 lastMousePosition;

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        //string current_horse = PlayerPrefs.GetString("goofy");
        ////PlayerPrefs.DeleteKey("current_horse");
        //InstantiatePrefab(currentPrefabIndex);
        //if (current_horse.Length > 0)
        //{
        //    Load(current_horse);
        //}
    }


    public void Load(string horsename)
    {
        string jsonData = PlayerPrefs.GetString(horsename + ".horse");
        print(jsonData);

        if (!string.IsNullOrEmpty(jsonData))
        {
            DeleteHorse();

            //HorseSceneController horseSceneController = JsonUtility.FromJson<HorseSceneController>(jsonData);
            JsonUtility.FromJsonOverwrite(jsonData, this);

            Reset();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Joint"))
                {
                    print(hit.collider.name);
                    selectedJoint = hit.collider.gameObject;
                    lastMousePosition = Input.mousePosition;
                    //isDragging = true;
                    //selectedBone = hit.transform;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedJoint = null;
        }

        if (selectedJoint != null)
        {
            RotateJoint();
        }
    }

    public void RotateJoint()
    {
        // Calculate the rotation based on mouse movement
        Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
        float rotationX = -mouseDelta.y * rotationSpeed;
        float rotationY = mouseDelta.x * rotationSpeed;

        // Apply the rotation to the object
        selectedJoint.transform.Rotate(Vector3.up, rotationY, Space.World);
        selectedJoint.transform.Rotate(Vector3.right, rotationX, Space.World);

        // Update the last mouse position
        lastMousePosition = Input.mousePosition;


    }

    public void NextHat()
    {

        // Hide current hat 
        if (currentHatPrefabIndex != 0)
        {
            headPosition.Find(hatList[currentHatPrefabIndex]).gameObject.SetActive(false);
        }


        // Switch to the next hat
        currentHatPrefabIndex = (currentHatPrefabIndex + 1) % hatList.Count;

        // Show next hat 
        ShowHat(currentHatPrefabIndex);

    }

    public void PrevHat()
    {
        // Hide current hat 
        if (currentHatPrefabIndex != 0)
        {
            headPosition.Find(hatList[currentHatPrefabIndex]).gameObject.SetActive(false);
        }


        // Switch to the next prefab
        currentHatPrefabIndex--;
        if (currentHatPrefabIndex < 0)
        {
            currentHatPrefabIndex = hatList.Count - 1;
        }

        // Show next hat 
        ShowHat(currentHatPrefabIndex);
    }

    public void NextHorse()
    {
        //Destroy(transform.GetChild(0).gameObject);
        Destroy(horseObject);

        // Switch to the next prefab
        currentPrefabIndex = (currentPrefabIndex + 1) % horseList.Length;

        // Instantiate the new prefab
        InstantiatePrefab(currentPrefabIndex);
    }


    public void PrevHorse()
    {
        //Destroy(transform.GetChild(0).gameObject);
        Destroy(horseObject);

        // Switch to the next prefab
        currentPrefabIndex--;
        if (currentPrefabIndex < 0)
        {
            currentPrefabIndex = horseList.Length - 1;
        }

        // Instantiate the new prefab
        InstantiatePrefab(currentPrefabIndex);
    }




    private void InstantiatePrefab(int prefabIndex)
    {
        // Create and parent the new prefab
        //GameObject newPrefab = Instantiate(horseList[prefabIndex], transform.position, Quaternion.identity);
        //newPrefab.transform.SetParent(transform);
        //newPrefab.transform.Translate(Vector3.down);


        horseObject = Instantiate(horseList[prefabIndex], transform.position, Quaternion.identity);
        horseObject.transform.SetParent(transform);
        horseObject.transform.Rotate(0, 180, 0);
        horseObject.transform.Translate(Vector3.down);
        //horseObject.GetComponent<Animator>().runtimeAnimatorController = animatorController;

        headPosition = horseObject.transform.Find("Arm_Horse/root_bone/Spine_base/Spine_03/Spine_02/neck_01/neck_02/head");
        ShowHat(currentHatPrefabIndex);
    }


    private void ShowHat(int prefabIndex)
    {

        // Show next hat 
        if (prefabIndex != 0)
        {
            headPosition.Find(hatList[prefabIndex]).gameObject.SetActive(true);
        }

        //// (0, 0.3, 0)
        //// (-45, 0, 0)

        //if (prefabIndex != 0)
        //{
        //    // Create and parent the new prefab
        //    hatObject = Instantiate(hatList[prefabIndex]);
        //    hatObject.transform.SetParent(head);
        //    //hatObject.transform.Translate(Vector3.down);
        //    hatObject.transform.localPosition = Vector3.zero;
        //    hatObject.transform.Rotate(0, 180, 0);

        //    //hatObject.transform.rotation = hatPosition.rotation;
        //}
    }

    public void DeleteHorse()
    {
        Destroy(horseObject);
    }

    public void Reset()
    {
        InstantiatePrefab(currentPrefabIndex);
    }

}

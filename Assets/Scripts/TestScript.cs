
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
  //  Console.WriteLine("Hello World");
        int x;
        private int y;
        public float percentage = 28.0f;
        public bool jumping = true;
        public string horsename = "Ollie";
        public char grade = 'o';
        public GameObject player;
        public Vector2 location;
        public PlayerScript Pscript;
    // Start is called before the first frame update
    void Start()
    {
        x = 8;
        y = 88;
        print("hello \n world");
        print(x + "" + y); 
        /*
        hdkbeaifdiha
        aduhHIgfiwayudiDUHdhOAh
        */
       GetComponent<SpriteRenderer>().material.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f)); 
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = location;
//      GetComponent<SpriteRenderer>().material.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));  
    }
}

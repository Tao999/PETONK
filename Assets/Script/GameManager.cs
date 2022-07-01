using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    GameObject[] Boules;

    private void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Boules = GameObject.FindGameObjectsWithTag("Boule");
        if (GameObject.Find("Cochonet") != null)
        {
            var cochonet = GameObject.Find("Cochonet");
            foreach (GameObject boule in Boules)
            {
                var position = boule.transform.position;
                Debug.Log(position);
            }
        }


    }
}

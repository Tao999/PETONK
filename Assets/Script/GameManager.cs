using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    GameObject[] Boules;
    float minDist = Mathf.Infinity;

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
            var cochonnet = GameObject.Find("Cochonet");
            var positionCochonnet = cochonnet.transform.position;
            GameObject boulePlusProche;
            foreach (GameObject boule in Boules)
            {
                float dist = Vector3.Distance(boule.transform.position, positionCochonnet);
                if (dist < minDist)
                {
                    boulePlusProche = boule;
                    boulePlusProche.GetComponent<Renderer>().material.color = new Color(545, 124, 54);
                    minDist = dist;
                }
            }
            
        }
    }
}

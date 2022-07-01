using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lumiereC : MonoBehaviour
{
    public GameObject cochonet;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Cochonnet").transform);
    }
}

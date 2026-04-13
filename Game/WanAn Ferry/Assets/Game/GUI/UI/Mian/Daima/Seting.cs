using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Exiting()
    {
        gameObject.SetActive(false);
        GameObject Main = GameObject.FindGameObjectWithTag("Main").transform.gameObject;

        Main.transform.GetChild(0).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

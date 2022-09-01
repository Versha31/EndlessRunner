using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gg;
    public GameObject gameoverpanel;
    void Start()
    {
        gg = false;
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gg)
        {
            Time.timeScale = 0;
            gameoverpanel.SetActive(true);
        }
        
    }
}

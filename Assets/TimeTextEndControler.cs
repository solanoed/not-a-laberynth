using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextEndControler : MonoBehaviour
{
    public Text Time;
    // Start is called before the first frame update
    void Start()
    {
        Time.text = PlayerPrefs.GetString("Time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


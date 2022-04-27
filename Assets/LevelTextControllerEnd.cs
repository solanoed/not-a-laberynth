using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextControllerEnd : MonoBehaviour
{
    public Text Level;
    // Start is called before the first frame update
    void Start()
    {
        Level.text = PlayerPrefs.GetString("Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

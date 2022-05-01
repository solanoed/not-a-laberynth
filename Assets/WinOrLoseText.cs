using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinOrLoseText : MonoBehaviour
{
    public Text WinOrLose;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Status") == "Win")
        {
            WinOrLose.text = "Congrats!, you won!";

        }
        else if (PlayerPrefs.GetString("Status") == "Lose")
        {
            WinOrLose.text = "Too Bad, You Losed";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

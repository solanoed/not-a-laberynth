using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider n ;
    public Slider m ;
    public Text nT;
    public Text mT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nT.text = n.value.ToString();
        PlayerPrefs.SetInt("n", (int)n.value);
        mT.text = m.value.ToString();
        PlayerPrefs.SetInt("m", (int)m.value);

    }
}
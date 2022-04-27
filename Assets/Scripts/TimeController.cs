using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    [SerializeField]Text tiempo;

    private float total;
    private bool enmarcha;


    void Awake(){
        total = 0;
        enmarcha=true;
    }
    public string tempTotal;

    // Update is called once per frame
    void Update()
    {
        if(enmarcha){
            total+= Time.deltaTime;

        }
        int tempMin = Mathf.FloorToInt(total/60);
        int tempSeg = Mathf.FloorToInt(total% 60);
        tempTotal = string.Format("{00:00}:{01:00}",tempMin,tempSeg);
        tiempo.text =tempTotal;
    }
    }


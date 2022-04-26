using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("From Level 1 to Level2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickPlay(){
        SceneManager.LoadScene(1);
    }
}

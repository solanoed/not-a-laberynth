using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int iLevelToLoad;
    public string sLevelToLoad;

    public bool useIntegerToLoadLevel = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void LoadScene() {
        if(useIntegerToLoadLevel){
            SceneManager.LoadScene(iLevelToLoad);
        }else{
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}

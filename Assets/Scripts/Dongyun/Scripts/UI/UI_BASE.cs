using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_BASE : MonoBehaviour
{
    public GameObject Setting ; 
     static int SettingCount  = 1 ; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void ButtonSetting()
    {   
         if(SettingCount == 0) return ; 
          Instantiate(Setting) ;
          SettingCount =0;
    }

    public void ButtonClose()
    {

          Destroy(gameObject) ; 
          SettingCount = 1 ;
    }
      
    public void MenuSceneChange()
    {
        SceneManager.LoadScene("StartScene") ; 
    }
    public void GameSceneChange()
    {
        SceneManager.LoadScene(  "InGame"    ) ;
    }

    public void GameQuit()
    {
        Application.Quit() ; 
    }

}
 
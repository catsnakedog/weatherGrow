using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class save : MonoBehaviour
{
    // Start is called before the first frame update

    List<GameObject>_imagelist = new List<GameObject>() ; 

   public GameObject  Image1 ; 
     public GameObject Image2 ;
     public GameObject  Image3 ;  

     public float time = 0;
    
void Start()
  {    
     
     _imagelist.Add(Image1);
        _imagelist.Add(Image2);
        _imagelist.Add(Image3);
      Button b1 = _imagelist[0].GetComponent<Button>() ; 
        Button b2 = _imagelist[1].GetComponent<Button>() ; 
        Button b3= _imagelist[2].GetComponent<Button>() ; 
        StartCoroutine("Timecheck") ; 
 }  

 IEnumerable Timecheck()
 {
     for(int i=0 ; i <3 ; i++ )
     {
         yield return new WaitForSeconds(2.0f);
       Time.timeScale = 0 ;
     }
  
 }
 int i = 0 ;
 void NextImage()
 {
   if(Input.GetMouseButtonDown(0))
   {
      _imagelist[i].SetActive(false) ;
      i ++ ; 
      Time.timeScale =1 ; 
   }
 }

 private void Update ()
{        time += Time.deltaTime ; 
           NextImage() ; 
      
}
    
 
}
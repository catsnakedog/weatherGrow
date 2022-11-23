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

     
void Start()
  {
        _imagelist.Add(Image1);
        _imagelist.Add(Image2);
        _imagelist.Add(Image3);

        StartCoroutine(FirstLoading()) ; 
 
 }


   IEnumerator FirstLoading()
  {
    for(int i = 0 ; i < 3 ; i++ )
    {

      if(Input.GetMouseButtonDown(0)) 
        {
       
            _imagelist[i].SetActive(false);
            
            continue ; 
          }
      
      yield return new WaitForSeconds(5.0f) ; 
        if(_imagelist[i].activeSelf !=false) 
        {
             _imagelist[i].SetActive(false);
            
        }


    }
     
     
}  





    // Update is called once per frame
    void Update()
    {
       
      
    }
    
 
}
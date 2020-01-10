using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testscript : MonoBehaviour
{
//public GameObject panelPrefab;
 //   public GameObject panelObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void testOpen() {
       //GameObject g = Instantiate(panelPrefab, panelObj.transform);
       //Transform test2 = g.transform.Find("Panel");
       // g.GetComponent<Popup>().Open();
       
       GameObject obj = (GameObject)Resources.Load ("Canvas");
        GameObject test = Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
        
        //Transform test2 = test.transform.Find("Panel");
        //test2.gameObject.GetComponent<Popup>().Open2();
        
    }
    
    public void testClose(){
        
    }
}
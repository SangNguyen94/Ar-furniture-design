namespace GoogleARCore.Examples.ObjectManipulation{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

using UnityEngine.UI;
  
public class ChangePrefab : MonoBehaviour
{
 
    public PawnManipulator objectWithScript1;
    
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;
         public GameObject myFurniture;
         public GameObject myFurniture1;
         public GameObject myFurniture2;
         public GameObject myFurniture3;
         public GameObject myFurniture4;
         public GameObject myFurniture5;
         public GameObject myFurniture6;
         public GameObject myFurniture7;
    // Start is called before the first frame update
    void Start()
    {
         Button1.onClick.AddListener(onButton1Press);
         Button2.onClick.AddListener(onButton2Press);
         Button3.onClick.AddListener(onButton3Press);
         Button4.onClick.AddListener(onButton4Press);
         Button5.onClick.AddListener(onButton5Press);
         Button6.onClick.AddListener(onButton6Press);
         Button7.onClick.AddListener(onButton7Press);
         Button8.onClick.AddListener(onButton8Press);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onButton1Press(){
        objectWithScript1.PawnPrefab = myFurniture;
    }
     public void onButton2Press(){
        objectWithScript1.PawnPrefab = myFurniture1;
    }
     public void onButton3Press(){
        objectWithScript1.PawnPrefab = myFurniture2;
    }
     public void onButton4Press(){
        objectWithScript1.PawnPrefab = myFurniture3;
    }
     public void onButton5Press(){
        objectWithScript1.PawnPrefab = myFurniture4;
    }
     public void onButton6Press(){
        objectWithScript1.PawnPrefab = myFurniture5;
    }
     public void onButton7Press(){
        objectWithScript1.PawnPrefab = myFurniture6;
    }
     public void onButton8Press(){
        objectWithScript1.PawnPrefab = myFurniture7;
    }
}
}

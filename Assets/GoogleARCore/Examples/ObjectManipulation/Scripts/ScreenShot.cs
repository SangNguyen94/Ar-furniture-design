namespace GoogleARCore.Examples.ObjectManipulation{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;
public class ScreenShot : MonoBehaviour
{
    CaptureAndSave snapShot ;
    public Button screenshotButton;
    void Awake()
    {
         snapShot = GameObject.FindObjectOfType<CaptureAndSave>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void onScreenshotPress()
    {
        snapShot.CaptureAndSaveAtPath(Screen.width,Screen.height,Camera.main,"/Pictures",ImageType.JPG);
    }

}
}

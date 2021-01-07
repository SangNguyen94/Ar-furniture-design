namespace GoogleARCore.Examples.ObjectManipulation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GoogleARCore;


    public class ToggleManipulator : MonoBehaviour
    {
        public bool isOn1;

        public GameObject handle;
        private RectTransform handleTransform;
        private float handleSize;
        public RectTransform toggle;
        private float onPosX;
        private float offPosX;
        public float handleOffset;

        public GameObject onIcon;
        private Manipulator[] Manipulator;
        public GameObject offIcon;

        private TranslationManipulator translation;
        private RotationManipulator rotation;
        private ElevationManipulator elevation;
        public float moveSpeed;
        public float t = 0.0f;
        private bool switching = false;
        public string assetPath;
        private GameObject myPrefab;
        void Awake()
        {
            handleTransform = handle.GetComponent<RectTransform>();
            Manipulator = GameObject.FindObjectsOfType<Manipulator>();



            handleSize = handleTransform.sizeDelta.x;
            float toggleSizeX = toggle.sizeDelta.x;
            onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
            offPosX = onPosX * -1;

        }


        // Start is called before the first frame update
        void Start()
        {
            //  myPrefab = PrefabUtility.LoadPrefabContents(assetPath);
            if (isOn1)
            {
                handleTransform.localPosition = new Vector3(onPosX, 0f, 0f);
                onIcon.gameObject.SetActive(true);
                // translation.enabled = false;
                //  Debug.Log(Manipulator.ManipulatorPrefab.GetComponent<TranslationManipulator>().enabled);
                // elevation.enabled = false;
                // rotation.enabled = true;
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Manipulator"))
                {
                    go.GetComponent<TranslationManipulator>().enabled = false;
                    go.GetComponent<ElevationManipulator>().enabled = false;
                    go.GetComponent<RotationManipulator>().enabled = true;
                }
                // Debug.Log(Manipulator.ManipulatorPrefab.GetComponent<TranslationManipulator>().enabled);

                // myPrefab.GetComponent<TranslationManipulator>().enabled = false;
                // myPrefab.GetComponent<ElevationManipulator>().enabled = false;
                // myPrefab.GetComponent<RotationManipulator>().enabled = true;

                // PrefabUtility.SaveAsPrefabAsset(myPrefab, assetPath);
                // PrefabUtility.UnloadPrefabContents(myPrefab);
                offIcon.gameObject.SetActive(false);
            }
            else
            {
                handleTransform.localPosition = new Vector3(offPosX, 0f, 0f);
                onIcon.gameObject.SetActive(false);
                offIcon.gameObject.SetActive(true);
                // translation.enabled = true;
                // elevation.enabled = true;
                // rotation.enabled = false;
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Manipulator"))
                {
                    go.GetComponent<TranslationManipulator>().enabled = true;
                    go.GetComponent<ElevationManipulator>().enabled = true;
                    go.GetComponent<RotationManipulator>().enabled = false;
                }
                // myPrefab.GetComponent<TranslationManipulator>().enabled = true;
                // myPrefab.GetComponent<ElevationManipulator>().enabled = true;
                // myPrefab.GetComponent<RotationManipulator>().enabled = false;
                // PrefabUtility.SaveAsPrefabAsset(myPrefab, assetPath);
                // PrefabUtility.UnloadPrefabContents(myPrefab);
            }
        }
        public void Update()
        {
            if (switching)
            {
                Toggle(isOn1);
            }

        }
        public void Switch()
        {
            switching = true;
        }
        public static void DumpToConsole(object obj)
        {
            var output = JsonUtility.ToJson(obj, true);
            Debug.Log(output);
        }
        public void Toggle(bool toggleStatus)
        {
            //  myPrefab = PrefabUtility.LoadPrefabContents(assetPath);
            if (!onIcon.activeSelf || !offIcon.activeSelf)
            {
                onIcon.SetActive(true);
                offIcon.SetActive(true);
            }
            DumpToConsole(Manipulator);
            if (toggleStatus)
            {
                handleTransform.localPosition = SmoothMove(handle, onPosX, offPosX);
                onIcon.gameObject.SetActive(false);
                offIcon.gameObject.SetActive(true);
                // translation.enabled = true;
                // elevation.enabled = true;
                // rotation.enabled = false;
                // Debug.Log("Translation status" + Manipulator.ManipulatorPrefab.GetComponent<TranslationManipulator>().enabled);
                // myPrefab.GetComponent<TranslationManipulator>().enabled = false;
                // myPrefab.GetComponent<ElevationManipulator>().enabled = false;
                // myPrefab.GetComponent<RotationManipulator>().enabled = true;

                // PrefabUtility.SaveAsPrefabAsset(myPrefab, assetPath);
                // PrefabUtility.UnloadPrefabContents(myPrefab);
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Manipulator"))
                {
                    go.GetComponent<TranslationManipulator>().enabled = true;
                    go.GetComponent<ElevationManipulator>().enabled = true;
                    go.GetComponent<RotationManipulator>().enabled = false;
                }
            }
            else
            {

                handleTransform.localPosition = SmoothMove(handle, offPosX, onPosX);
                onIcon.gameObject.SetActive(true);
                offIcon.gameObject.SetActive(false);
                //Debug.Log("Manipulation: " +Manipulator );
                // translation.enabled = false;
                // elevation.enabled = false;
                // rotation.enabled = true;
                // Debug.Log("Translation status" + Manipulator.ManipulatorPrefab.GetComponent<TranslationManipulator>().enabled);
                // myPrefab.GetComponent<TranslationManipulator>().enabled = true;
                // myPrefab.GetComponent<ElevationManipulator>().enabled = true;
                // myPrefab.GetComponent<RotationManipulator>().enabled = false;
                // PrefabUtility.SaveAsPrefabAsset(myPrefab, assetPath);
                // PrefabUtility.UnloadPrefabContents(myPrefab);
                 foreach (GameObject go in GameObject.FindGameObjectsWithTag("Manipulator"))
                {
                    go.GetComponent<TranslationManipulator>().enabled = false;
                    go.GetComponent<ElevationManipulator>().enabled = false;
                    go.GetComponent<RotationManipulator>().enabled = true;
                }

            }

        }
        Vector3 SmoothMove(GameObject toggleHandle, float startPosX, float endPosX)
        {

            Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, t += moveSpeed * Time.deltaTime), 0f, 0f);
            StopSwitching();
            return position;
        }
        void StopSwitching()
        {
            if (t > 1.0f)
            {
                switching = false;

                t = 0.0f;
                switch (isOn1)
                {
                    case true:
                        isOn1 = false;

                        break;

                    case false:
                        isOn1 = true;

                        break;
                }

            }
        }
    }
}
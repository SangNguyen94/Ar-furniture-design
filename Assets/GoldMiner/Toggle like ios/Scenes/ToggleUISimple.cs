namespace GoogleARCore
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ToggleUISimple : MonoBehaviour
    {
        public bool isOn;

        public GameObject handle;
        private RectTransform handleTransform;
        private float handleSize;
        public RectTransform toggle;
        private float onPosX;
        private float offPosX;
        public float handleOffset;

        public GameObject onIcon;
        public GameObject Floor;
        public GameObject offIcon;

        public GameObject Wall;
        public float moveSpeed;
        public float t = 0.0f;
        private bool switching = false;

        void Awake()
        {
            handleTransform = handle.GetComponent<RectTransform>();

            handleSize = handleTransform.sizeDelta.x;
            float toggleSizeX = toggle.sizeDelta.x;
            onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
            offPosX = onPosX * -1;

        }

        // Start is called before the first frame update
        void Start()
        {
            if (isOn)
            {
                handleTransform.localPosition = new Vector3(onPosX, 0f, 0f);
                onIcon.gameObject.SetActive(true);
                Floor.gameObject.SetActive(true);
                offIcon.gameObject.SetActive(false);
                Wall.gameObject.SetActive(false);
            }
            else
            {
                handleTransform.localPosition = new Vector3(offPosX, 0f, 0f);
                onIcon.gameObject.SetActive(false);
                offIcon.gameObject.SetActive(true);
                Floor.gameObject.SetActive(false);
                Wall.gameObject.SetActive(true);
            }
        }
        public void Update()
        {
            if (switching)
            {
                Toggle(isOn);
            }
        }
        public void Switch()
        {
            switching = true;
        }
        public void Toggle(bool toggleStatus)
        {
            if (!onIcon.activeSelf || !offIcon.activeSelf)
            {
                onIcon.SetActive(true);
                offIcon.SetActive(true);
            }

            if (toggleStatus)
            {
                handleTransform.localPosition = SmoothMove(handle, onPosX, offPosX);
                onIcon.gameObject.SetActive(false);
                offIcon.gameObject.SetActive(true);
                Floor.gameObject.SetActive(false);
                Wall.gameObject.SetActive(true);
                // var session = GameObject.Find("ARCore Device").GetComponent<ARCoreSession>();
                // session.SessionConfig.PlaneFindingMode = DetectedPlaneFindingMode.Vertical;
                // // session.OnDisable();
                // session.OnEnable();
            }
            else
            {

                handleTransform.localPosition = SmoothMove(handle, offPosX, onPosX);
                onIcon.gameObject.SetActive(true);
                offIcon.gameObject.SetActive(false);
                Floor.gameObject.SetActive(true);
                Wall.gameObject.SetActive(false);
                //  var session = GameObject.Find("ARCore Device").GetComponent<ARCoreSession>();
                // session.SessionConfig.PlaneFindingMode = DetectedPlaneFindingMode.Horizontal;
                // // session.OnDisable();
                // session.OnEnable();

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
                switch (isOn)
                {
                    case true:
                        isOn = false;

                        break;

                    case false:
                        isOn = true;

                        break;
                }

            }
        }
    }
}

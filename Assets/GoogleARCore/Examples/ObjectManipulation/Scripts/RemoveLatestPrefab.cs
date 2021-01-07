namespace GoogleARCore.Examples.ObjectManipulation
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GoogleARCore;
    using System.Linq;
    public class RemoveLatestPrefab : MonoBehaviour
    {
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void onRemoveLatest()
        {
            List<GameObject> spawnedPrefab = new List<GameObject>();
            spawnedPrefab.AddRange(GameObject.FindGameObjectsWithTag("spawned"));
            Destroy(spawnedPrefab.Last());
        
        }
}
}

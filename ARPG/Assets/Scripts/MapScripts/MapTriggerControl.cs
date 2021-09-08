using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTriggerControl : MonoBehaviour
{
    public bool isDelete;
    public GameObject[] hideObjects;
    public GameObject[] showObjects;
    public string triggerTag;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == triggerTag)
        {
            for (int i = 0; i < hideObjects.Length; i++)
            {
                hideObjects[i].SetActive(false);
            }
            for (int i = 0; i < showObjects.Length; i++)
            {
                showObjects[i].SetActive(true);
            }
            if (isDelete)
            {
                Destroy(this);
            }
            
        }
    }

}

using UnityEngine;

namespace MauriceBaller;

public class DontSplattermaurice : MonoBehaviour
{
    void Update()
    {
        if(gameObject.transform.parent.parent != null)
        {
            if(gameObject.transform.parent.parent.name.Contains("Spider"))
            {
                if(gameObject != null)
                {
                    Destroy(gameObject);   
                }
            }
        this.enabled = false;   
        }
    }
}
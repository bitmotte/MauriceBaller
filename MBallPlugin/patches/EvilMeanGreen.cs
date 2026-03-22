using UnityEngine;

namespace MauriceBaller;
public class EvilMeanGreen : MonoBehaviour
{
    public GameObject green;
    private GameObject greenFlash;

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Player"))
        {
            GameObject canvas = GameObject.Find("Canvas");

            greenFlash = Instantiate(green);
            greenFlash.transform.parent = canvas.transform;
    
            Invoke("Destroy",2.99f);
        }
    }

    void Destroy()
    {
        Destroy(greenFlash);
    }
} 
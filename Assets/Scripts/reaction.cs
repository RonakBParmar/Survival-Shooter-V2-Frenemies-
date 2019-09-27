using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaction : MonoBehaviour
{
    public bool doreport;

    // Start is called before the first frame update
    void Start()
    {
        if (doreport)
            Debug.Log(gameObject.name + "has started");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name +  " was hit by " + other.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

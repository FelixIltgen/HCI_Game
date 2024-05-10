using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {

       if (other.gameObject.CompareTag("Cloud")|| other.gameObject.CompareTag("Cloud")) // <== Hier verschiedene Wolkentypen 
       {
        // Anzeige muss erhöht oder gesenkt werden
       } 
    }
}

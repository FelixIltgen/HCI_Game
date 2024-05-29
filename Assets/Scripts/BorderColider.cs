using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZBorder : MonoBehaviour
{
    CloudSpawner2 SpawnerScript;
    // Start is called before the first frame update
    
    void Awake() {
        SpawnerScript = FindObjectOfType<CloudSpawner2>(); 
    }
    
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Cloud"))
        {
            SpawnerScript.lifeTimer = 0;
            SpawnerScript.isCloudActive = false;
            Destroy(other.gameObject);
        }
    }
}

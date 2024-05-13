using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColider : MonoBehaviour{

    public TreeHealthBar healthBar;
    public int startHealth = 0;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        healthBar.SetMaxHealth(startHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {

       if (other.gameObject.CompareTag("Cloud")){
            
            currentHealth += 1;
            healthBar.SetHealth(currentHealth);
       } 
    }
}

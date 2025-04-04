
using UnityEngine;

public class TreeColider : MonoBehaviour{

    public TreeHealthBar healthBar;
    public float startHealth =0;
    static public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        healthBar.SetMaxHealth(startHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GetHealth();
    }
    public void OnTriggerStay(Collider other) {

       if (other.gameObject.CompareTag("Cloud")){
            
            currentHealth += 3 * Time.deltaTime;
            healthBar.SetHealth(currentHealth);
       } 
    }
    public float GetHealth(){
        return currentHealth;
    
    }
}

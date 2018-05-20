using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

    
	void OnTriggerEnter2D (Collider2D other) // Metoda ktora zabezpecuje interakciu 2 objektov ktore maju obidva Collider2D a IsTriggered ma hodnotu true (ak by bol iba Collider, ktory maju iba 3D objekty, tak sa metoda nevykona) tak sa zacinaju vykonavat prikazy  
    {
        if (other.tag == "Player1")
        {
            Application.LoadLevel(2); // Ak ma objekt s ktorym interaguje tag "Player1" tak sa nacita 
            Debug.Log(other.tag + "destroyed");
        } else {
            Destroy(other.gameObject); // Zniči sa kazdy objekt ktory sa "zrazi" s tymto objektom a nebude mat tag "Player1"

        }
        
    }

    void OnTriggerEnter (Collider other)
    {
        Destroy(other.gameObject);
    }
}

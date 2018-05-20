using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private int hodnotaPriZbere;
    

    // Use this for initialization
    void Start () {
        this.hodnotaPriZbere = 10; // Inicializujem hodnotu pri zbere na hodnotu 10
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getHodnotaPriZbere() // Getter na ziskanie atributu hodnotaPriZbere
    {
        return this.hodnotaPriZbere;
    }

    
}

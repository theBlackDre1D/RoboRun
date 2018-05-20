using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float scrollingVelocity = 0.1f; // rychlost posunu pozadia
	
	// Metoda sa vola raz za frame
	void Update () {
        
        Vector2 offset = new Vector2(Time.time * scrollingVelocity, 0); // Vector s 2 hodnotami X = cas v sekundach * rychlost posunu pozadia, Y = 0 lebo chceme scrollovat len po X suradnici

        GetComponent<Renderer>().material.mainTextureOffset = offset; // Aktualizuje sa hodnota mainTextureOffset na novy vektor offset. Tu sa priamo zabezpecuje scrollovanie pozadia

	}
}

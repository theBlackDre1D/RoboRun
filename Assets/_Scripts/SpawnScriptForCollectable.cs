using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScriptForCollectable : MonoBehaviour {

    public GameObject[] obj; // Pole prvkov z ktoyche budeme vytvarat instancie
    //public float spawnMin = 1f; 
    //public float spawnMax = 2f;

    // Start je volana raz na zaciatku
    void Start () {
        Spawn(); //Volanie metody Spawn()
	}
	
	
    void Spawn() // Metoda zabezpecuje vytvaranie instancii v urcitom casovom odostupe
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity); // Vytvori sa instancia 1 nahodne vybraneho prvku z pola "obj" a umiestni sa na miesto kde sa prave nachadza prvok s tymto komponentom respektive scriptom
        //Invoke("Spawn", Random.Range(spawnMin, spawnMax)); // Funkcia Inwoke 
    }
}

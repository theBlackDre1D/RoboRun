using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSoundScript : MonoBehaviour {

    private AudioSource zvuk; // Musi to byt public, aby som vedel v engine pomocou drag&drop priradit zvuk z disku

    // Use this for initialization
    void Start () {
        zvuk = GetComponent<AudioSource>(); // Ziskam z premennej zvuk komponent AudioSource
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player1")
        {
            zvuk.Play(); // Prehra sa zvuk priradeny v komponente AudioSource
        }
        

    }

}

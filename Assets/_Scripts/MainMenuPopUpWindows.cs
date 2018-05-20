using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPopUpWindows : MonoBehaviour {

    public Image howToPlayImage; // Pomocou drag&drop priradim obrazok v editore z disku
    public Image infoImage; // Pomocou drag&drop priradim obrazok v editore z disku


    // Start je volana raz na zaciatku
    void Start () {
        howToPlayImage.gameObject.GetComponent<SpriteRenderer>().enabled = false; // Na zaciatku bude existovat obrazok ale nebude sa vykreslovat
        infoImage.gameObject.GetComponent<SpriteRenderer>().enabled = false; // Na zaciatku bude existovat obrazok ale nebude sa vykreslovat


    }

    // Update je volana raz za frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) // Ked uzivatel stalci ESC tak sa vykona podmienka v ktorej je volanie funkcie Start()
        {
            Start();
        }
	}

    public void zobrazHowToPlayImage() // Metoda ktora zabezpecuje zobrazenie obrazka howToPlayImage
    {
        howToPlayImage.gameObject.GetComponent<SpriteRenderer>().enabled = true; // Zobrazi sa obrazok howToPlayImage

    }

    public void zobrazInfoImage() // Metoda ktora zabezpecuje zobrazenie obrazka howToPlayImage
    {
        infoImage.gameObject.GetComponent<SpriteRenderer>().enabled = true; // Zobrazi sa obrazok infoImage

    }
}

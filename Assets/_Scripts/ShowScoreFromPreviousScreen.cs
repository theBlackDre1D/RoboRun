using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreFromPreviousScreen : MonoBehaviour {

    public Text skoreNaVypis; // Pomocou funkcie drag&drop v editore enginu priradim konkretne textove pole

    // Start je volana raz na zaciatku
    void Start () {

        GameObject player = GameObject.FindGameObjectWithTag("Player1"); // Premenej player priradim objekt s tagom "Player1"
        PlayerScript playerFromPreviousSceene = player.GetComponent<PlayerScript>(); // Premennej playerFromPreviousSceene priradim komponent PlayerScript ktory patri este neznicenemu objektu hraca
        int docasneSkore = playerFromPreviousSceene.getSkore(); // Premennej docasneSkore priradim skore z PlayerScript-u
        this.skoreNaVypis.text = docasneSkore.ToString(); // Vypisujem skore do textoveho pola s nazvom skoreNaVypis a prevadzham ho na string
        Destroy(player); // Nicim objekt player

	}
	
}

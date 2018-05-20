using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaughtScript : MonoBehaviour {

    private ArrayList vysmesky = new ArrayList(); // Vytvorim ArrayList pre rozne vysmesky
    
    public Text textVysmechu; // V editore enginu priradim pomocou drag&drop konkr0tne textove pole do ktoreho budem vypisovat vysmesky

	// Use this for initialization

	void Start () {
        // Na zaciatku do ArrayListu vysmesky priradim 4 stringove hodnoty z ktorych kazda reprezentuje 1 vysmesku
        vysmesky.Add("So low?");
        vysmesky.Add("Better uninstall this game...");
        vysmesky.Add("Even my grandpa would do it better...");
        vysmesky.Add("Realy?! This?!");

        textVysmechu.text = vysmesky[Random.Range(0, 4)].ToString(); // Nahodne generujem 1 vysmesku z ArrayList-u "vysmesky" a vypisujem do daneho textoveho pola
	}
	
}


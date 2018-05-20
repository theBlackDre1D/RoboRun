using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	
    public void LoadLevel(int screenNumber) //Metoda nacita herne obrazovku podla ciselneho parametra. Ake ma celociselne poradie dana obrazovka sa nastavuje v editore enginu Build Settings
    {
        Application.LoadLevel(screenNumber);
    }

    public void zavriAplikaciu() // Metoda ktora zabezpeci ukoncenie celeho programu - hry.
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistanceFromTarget : MonoBehaviour {

    public Transform targetToFollow; // V editore enginu priradim pomocou drag&drop target ktory ma nasledovat

    private float distance;
    
    // Start je volana raz na zaciatku
    void Start()
    {

        distance = this.transform.position.x - targetToFollow.transform.position.x; // Na zaciatku si vypocitam rozdiel X - novych hodnot aby som vedel aka vzdialenost sa ma stale udrziavat
    }

    // Update je volana raz za frame
    void Update()
    {
        if (this.transform.position.x - targetToFollow.transform.position.x != distance) // Ak vzdialenost objektu, ktoremu je prideleny tento script, od objektu ktory ma sledovat sa nerovna vstupim do podmienky
        {
            // Nastavujem X - ovu suradnicu tak, aby vzdy bola mensia presne o hodnotu premennej distance. Nakolko distane bude zapornej hodnoty musim pouzit matematicky operator pre scitanie a nie odcitanie,
            // aby sa objekt neobjavil na opacnej strane nakolko - a - nam dava + :)
            transform.position = new Vector3((targetToFollow.position.x + distance), transform.position.y, transform.position.z);
        }
        
    }
}

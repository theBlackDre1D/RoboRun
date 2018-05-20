using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //musim importovat ak chcem vypisovat skore tak ako to chcem spravit

public class PlayerScript : MonoBehaviour {

    private int skore;
    private int pocetZivotov = 1;
    private Coin colliderObject;
    private Heart colliderObject2;

    public Text pauseText;
    public Text vypisSkore;
    public Image pauseImage;

    public GameObject srdco1;
    public GameObject srdco2;
    public GameObject srdco3;


    


	// Funkcia sa pouziva na inicializovanie. Je volaná len raz na zaciatku hry ale da sa v pripade potreby volat aj v inej metode ak to kod vyzaduje.
	void Start () {
        this.skore = 0; //Inicializujem skore na zaciatku na 0
        DontDestroyOnLoad(this.gameObject); // Funkcia DontDestroyOnLoad zabezpecuje, aby sa pri prejdeni na inu hernu scenu neznicil tento script a mohol som vypisat skore na LooseScreen obrazovke
        Time.timeScale = 0;

        srdco1.GetComponent<SpriteRenderer>().enabled = false;
        srdco2.GetComponent<SpriteRenderer>().enabled = false;
        srdco3.GetComponent<SpriteRenderer>().enabled = false;


    }
	
	// Update() je volana raz ja 1 frame. Metodu pouzivam na zabezpecenie interakcie.
	void Update () {
        // Ked uzivatel stlaci ENTER: 1. pauseImage sa prestane vykreslovat ale zostane stale existovat
        //                            2. a pauseText sa nastavi na prazdny string
        //                            3. Time.timeScale sa nastavi na 1 co znamena, ze hra bude plynut podla nastaveni
        if (Input.GetKeyDown(KeyCode.Return)) // Ked uzivatel stlaci ENTER vstupi sa do podmienky
        {
            pauseImage.gameObject.GetComponent<SpriteRenderer>().enabled = false; // Obrazok pauseImage sa prestane vykreslovat na hraciu plochu ale ostava stale existovat
            Time.timeScale = 1; // Hra sa odpauzne a bude fungovat normalnou rychlostou
            pauseText.text = ""; // pauseText sa nastavy na prazdny string
        }

        // Ked uzivatel stlaci ESC hra sa stopne.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0; // Ked je tato hodnota rovna 0 znamena to, ze sa vestko na hracej ploche stopne
            pauseText.text = "PAUSED                    Press ENTER to continue"; // pauseText sa bude rovnat danemu stringu
            pauseImage.gameObject.GetComponent<SpriteRenderer>().enabled = true;  // pauseImage sa znova zacne vykreslovat na hracej ploche
        }
        

        setVypisSkore(); // Vlastna metoda opisana nizsie
        Debug.Log(this.pocetZivotov); // Pouzival som len ako vypis na konzolu. V hre sa tento prikaz nijako neprejavuje vidno to len priamo v engine.

        if (this.pocetZivotov == 0) // Ak pocet zivotov bude rovny 0 hra konci a nacita sa Screen s cislom 2 - LoseScreen
        {
            Application.LoadLevel(2);
        }

        if (this.pocetZivotov == 2)
        {
            srdco1.GetComponent<SpriteRenderer>().enabled = true;
            srdco2.GetComponent<SpriteRenderer>().enabled = false;
            srdco3.GetComponent<SpriteRenderer>().enabled = false;
        } 

        if (this.pocetZivotov == 3)
        {
            srdco1.GetComponent<SpriteRenderer>().enabled = true;
            srdco2.GetComponent<SpriteRenderer>().enabled = true;
            srdco3.GetComponent<SpriteRenderer>().enabled = false;
        } 

        if (this.pocetZivotov == 4)
        {
            srdco1.GetComponent<SpriteRenderer>().enabled = true;
            srdco2.GetComponent<SpriteRenderer>().enabled = true;
            srdco3.GetComponent<SpriteRenderer>().enabled = true;
        } 
    }

    void OnTriggerEnter2D(Collider2D other) // Metoda ktora zabezpecuje interakciu 2 objektov ktore maju obidva Collider2D a IsTriggered ma hodnotu true (ak by bol iba Collider, ktory maju iba 3D objekty, tak sa metoda nevykona) tak sa zacinaju vykonavat prikazy  
    {
        if (other.tag == "Heart") // Ak ma objekt tag "Heart" vstupy sa do tohto if-u. Tag som priradil v engine nie v ziadnom skripte.
        {

            colliderObject2 = other.gameObject.GetComponent<Heart>(); // Ziskam pristup ku komponentu Heart. Jedna sa o pripnuty skript "Heart" k danemu objektu.
            Renderer rend = other.gameObject.GetComponent<Renderer>(); // Premennej rend typu Renderer priradim renderer daneho objektu - dam mu pristup k atributom renderer-u daneho prvku
            rend.enabled = false; // Nastavujem premennu rend na false - objekt sa prestane vykreslovat ale stale bude existovat
            
            if (this.pocetZivotov == 1) // Ak hrac ma 1 az 3 zivoty vratane, zvacsi sa pocetZivotov o 1
            {
                this.pocetZivotov++;
            }
            else if (this.pocetZivotov == 2)
            {
                this.pocetZivotov++;
            }
            else if (this.pocetZivotov == 3)
            {
                this.pocetZivotov++;
            }

            Destroy(other.gameObject, 3); // Objekt sa uplne cely znici po 3 sekundach od interakcie. Musi sa az po 3 sekundach, aby sa stihol vykonat prikaz na prehratie zvuku pri interakcii.

        }


        if (other.tag == "BadHeart") // Ak ma objekt tag "BadHeart" vykonaju sa nasledovne prikazy
        {
            this.pocetZivotov--; // pocetZivotov sa znizi o 1
            Renderer rend = other.gameObject.GetComponent<Renderer>(); // Premennej rend typu Renderer priradim renderer daneho objektu - dam mu pristup k atributom renderer-u daneho prvku
            rend.enabled = false; // Nastavujem premennu rend na false - objekt sa prestane vykreslovat ale stale bude existovat
            
            Destroy(other.gameObject, 1); // Objekt sa uplne znici

        }


        if (other.tag == "Collectable")
        {
            colliderObject = other.gameObject.GetComponent<Coin>(); // Ziskam pristup ku komponentu Coin. Jedna sa o pripnuty skript "Coin" k danemu objektu.
            zvysitSkore(colliderObject.getHodnotaPriZbere()); // Volanie metódy zvysitSkore s parametrom ktorym je atribut objektu hodnotaPriZbere
            Renderer rend = other.gameObject.GetComponent<Renderer>(); // Premennej rend typu Renderer priradim renderer daneho objektu - dam mu pristup k atributom renderer-u daneho prvku
            rend.enabled = false; // Nastavujem premennu rend na false - objekt sa prestane vykreslovat ale stale bude existovat


            Destroy(other.gameObject, 1); //funguje uz spravne
            
        }

    }

    public void setVypisSkore() // Metoda zabezpecuje priradenie ciselnej hodnoty a nasledneho pretypovania na string
    {
        vypisSkore.text = skore.ToString();
    }

    public int getPocetZivotov() // Metoda na pristup k atributu pocetZivotov
    {
        return this.pocetZivotov;
    }

    public int getSkore() // Metoda na pristup k atributu skore
    {
        return this.skore;
    }

    public void zvysitPocetZivotov(int pocet) // Metoda zvysi hodnotu pocetZivotov o hodnotu parametra
    {
        this.pocetZivotov += pocet;
    }

    public void zvysitSkore(int novaHodnota) // Metoda zvysi skore o hodnotu parametra
    {
        this.skore += novaHodnota;
    }
}

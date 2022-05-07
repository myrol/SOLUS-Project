using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour      //Abstrakt damit man es f�r verschiedene R�tsel benutzen kann
{
    public string message;

    //Methode wird vom Spieler aufgerufen
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //Ist leer, da es �berschrieben wird bei Unterklassen
    }
}

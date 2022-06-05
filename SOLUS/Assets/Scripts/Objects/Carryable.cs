using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Carryable : MonoBehaviour      //Abstrakt damit man es f�r verschiedene R�tsel benutzen kann
{
    public bool pickedUp = false;
    public virtual void PickUp()
    {
        //Ist leer, da es �berschrieben wird bei Unterklassen
    }
    public virtual void Drop()
    {
        //Ist leer, da es �berschrieben wird bei Unterklassen
    }
}

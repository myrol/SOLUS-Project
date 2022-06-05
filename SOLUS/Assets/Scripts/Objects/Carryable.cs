using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Carryable : MonoBehaviour      //Abstrakt damit man es für verschiedene Rätsel benutzen kann
{
    public bool pickedUp = false;
    public virtual void PickUp()
    {
        //Ist leer, da es überschrieben wird bei Unterklassen
    }
    public virtual void Drop()
    {
        //Ist leer, da es überschrieben wird bei Unterklassen
    }
}

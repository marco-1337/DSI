using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basedatos
{
    public static List<Individuo> getData() 
    {
        List<Individuo> datos = new();

        Individuo first = new Individuo("A", "Pedra");
        Individuo second = new Individuo("Dwayne", "Johnson");
        Individuo third = new Individuo("Rock", "& Stone");
        Individuo fourth = new Individuo("La", "Roca");

        datos.Add(first);
        datos.Add(second);
        datos.Add(third);
        datos.Add(fourth);

        return datos;
    }
}

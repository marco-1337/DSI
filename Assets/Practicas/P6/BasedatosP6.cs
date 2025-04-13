using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BasedatosP6
{
    public static List<IndividuoP6> getData() 
    {
        List<IndividuoP6> datos = new List<IndividuoP6>();

        if (File.Exists("Assets/Resources/guardadoP6"))
        {
            StreamReader sr = new StreamReader("Assets/Resources/guardadoP6");
            datos = JsonHelperIndividuo.FromJson<IndividuoP6>(sr.ReadToEnd());
        }

        return datos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class JsonHelperIndividuo
{
    public static List<IndividuoP6> FromJson<IndividuoP6> (string json)
    {
        ListaIndividuo<IndividuoP6> listaIndividuo = JsonUtility.FromJson<ListaIndividuo<IndividuoP6>>(json);
        return listaIndividuo.individuos;
    }

    public static string ToJson<IndividuoP6>(List<IndividuoP6> lista) 
    {
        ListaIndividuo<IndividuoP6> listaIndividuo = new ListaIndividuo<IndividuoP6>();
        listaIndividuo.individuos = lista;
        return JsonUtility.ToJson(listaIndividuo);
    }

    public static string ToJson<IndividuoP6>(List<IndividuoP6> lista, bool prettyPrint) 
    {
        ListaIndividuo<IndividuoP6> listaIndividuo = new ListaIndividuo<IndividuoP6>();
        listaIndividuo.individuos = lista;
        return JsonUtility.ToJson(listaIndividuo, prettyPrint);
    }

    [Serializable]
    private class ListaIndividuo<IndividuoP6> 
    {
        public List<IndividuoP6> individuos;
    }
}

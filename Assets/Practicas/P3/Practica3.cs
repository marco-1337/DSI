using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Practica3 : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement izq = root.Q("Izq");
        VisualElement der = root.Q("Der");

        List<VisualElement> columnasIzq = izq.Children().ToList();
        List<VisualElement> columnasDer = der.Children().ToList();

        List<VisualElement> elemsIzq = new List<VisualElement>();
        foreach(VisualElement e in columnasIzq)
        {
            elemsIzq.AddRange(e.Children().ToList());
        }

        List<VisualElement> elemsDer = new List<VisualElement>();
        foreach(VisualElement e in columnasDer)
        {
            elemsDer.AddRange(e.Children().ToList());
        }

        elemsIzq.ForEach( elem => elem.AddManipulator(new Practica3Manipulator()));
        elemsDer.ForEach( elem => elem.AddManipulator(new Practica3Manipulator()));
    }   
}

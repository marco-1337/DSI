using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Practica3 : MonoBehaviour
{

    [SerializeField]
    private Color _leftHightlight = Color.white, _rightHighlight = Color.white;

    private StyleColor _leftBaseColor, _rightBaseColor;

    [SerializeField]
    private float _resizeFactor = 0.01f, _resizeMin = 0.5f, _resizeMax = 2f;

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

        _leftBaseColor = elemsIzq[0].style.backgroundColor;
        _rightBaseColor = elemsDer[0].style.backgroundColor;

        elemsIzq.ForEach( elem => elem.AddManipulator(new Practica3GridHoverManipulator()));
        elemsIzq.ForEach( elem => elem.AddManipulator(new Practica3GridClickManipulator(_leftBaseColor, _leftHightlight)));

        elemsDer.ForEach( elem => elem.AddManipulator(new Practica3GridHoverManipulator()));
        elemsDer.ForEach( elem => elem.AddManipulator(new Practica3GridClickManipulator(_rightBaseColor, _rightHighlight)));

        VisualElement imgRes = root.Q("ImageResize");
        imgRes.AddManipulator(new Practica3ResizerManipulator(_resizeFactor, _resizeMin, _resizeMax));
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Practica2 : MonoBehaviour
{
    VisualElement tabs;
    VisualElement contenido;

    VisualElement tab_L;
    VisualElement tab_M;
    VisualElement tab_X;
    VisualElement tab_J;
    VisualElement tab_V;

    VisualElement contenido_L;
    VisualElement contenido_M;
    VisualElement contenido_X;
    VisualElement contenido_J;
    VisualElement contenido_V;

    private void OcultarContenido()
    {
        foreach (var item in contenido.Children())
            item.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        UIDocument document = GetComponent<UIDocument>();
        VisualElement rootve = document.rootVisualElement;

        tabs = rootve.Q("Tabs");
        contenido = rootve.Q("Contenido");

        tab_L = tabs.Q("Lunes");
        tab_M = tabs.Q("Martes");
        tab_X = tabs.Q("Miercoles");
        tab_J = tabs.Q("Jueves");
        tab_V = tabs.Q("Viernes");

        contenido_L = contenido.Q("Lunes");
        contenido_M = contenido.Q("Martes");
        contenido_X = contenido.Q("Miercoles");
        contenido_J = contenido.Q("Jueves");
        contenido_V = contenido.Q("Viernes");


        // CALLBACKS
        tab_L.RegisterCallback<MouseDownEvent>(ev =>
        {
            OcultarContenido();
            contenido_L.style.display = DisplayStyle.Flex;
        });

        tab_M.RegisterCallback<MouseDownEvent>(ev =>
        {
            OcultarContenido();
            contenido_M.style.display = DisplayStyle.Flex;
        });

        tab_X.RegisterCallback<MouseDownEvent>(ev =>
        {
            OcultarContenido();
            contenido_X.style.display = DisplayStyle.Flex;
        });

        tab_J.RegisterCallback<MouseDownEvent>(ev =>
        {
            OcultarContenido();
            contenido_J.style.display = DisplayStyle.Flex;
        });

        tab_V.RegisterCallback<MouseDownEvent>(ev =>
        {
            OcultarContenido();
            contenido_V.style.display = DisplayStyle.Flex;
        });

        //UQueryBuilder<VisualElement> builder = new(rootve);
        //List<VisualElement> listve = builder.ToList();

        //List<VisualElement> listve = rootve.Query(className: "azul").ToList();

        //VisualElement midContainer = builder.Name("mid");
        //List<VisualElement> listve = midContainer.Children().ToList();

        //listve.ForEach(element =>
        //    {   Debug.Log(element.name);
        //        element.AddToClassList("amarillo");
        //    });

        //VisualElement button = rootve.Query<Button>().Last();
        //button.AddToClassList("amarillo");
    }
}

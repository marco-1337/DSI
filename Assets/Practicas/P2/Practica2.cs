using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Practica2 : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument document = GetComponent<UIDocument>();
        VisualElement rootve = document.rootVisualElement;

        //UQueryBuilder<VisualElement> builder = new(rootve);
        //List<VisualElement> listve = builder.ToList();

        //List<VisualElement> listve = rootve.Query(className: "azul").ToList();

        //VisualElement midContainer = builder.Name("mid");
        //List<VisualElement> listve = midContainer.Children().ToList();

        //listve.ForEach(element =>
        //    {   Debug.Log(element.name);
        //        element.AddToClassList("amarillo");
        //    });

        VisualElement button = rootve.Query<Button>().Last();
        button.AddToClassList("amarillo");
    }
}

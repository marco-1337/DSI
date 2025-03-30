using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Practica5 : MonoBehaviour
{
    List<Individuo> individuos; 
    Individuo selecIndividuo;

    [SerializeField]
    Texture2D tex1;
    [SerializeField]
    Texture2D tex2;
    [SerializeField]
    Texture2D tex3;
    [SerializeField]
    Texture2D tex4;

    VisualElement tarjeta1;
    VisualElement tarjeta2;
    VisualElement tarjeta3;
    VisualElement tarjeta4;

    TextField inputNombre;
    TextField inputApellido;

    private void OnEnable() 
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q("MenuImage1").style.backgroundImage = tex1;
        root.Q("MenuImage2").style.backgroundImage = tex2;
        root.Q("MenuImage3").style.backgroundImage = tex3;
        root.Q("MenuImage4").style.backgroundImage = tex4;

        tarjeta1 = root.Q("Card1");
        tarjeta2 = root.Q("Card2");
        tarjeta3 = root.Q("Card3");
        tarjeta4 = root.Q("Card4");

        inputNombre = root.Q<TextField>("TextFieldNombre");
        inputApellido = root.Q<TextField>("TextFieldApellido");

        individuos = Basedatos.getData();

        VisualElement panelDcha = root.Q("CardsSection");
        panelDcha.RegisterCallback<ClickEvent>(SeleccionTarjeta);

        root.Query("MenuImages")
            .Descendents<VisualElement>()
            .ForEach(elem => elem.RegisterCallback<ClickEvent>(CambioImagen));

        inputNombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        inputApellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

        InitalizeUI();
    }

    void CambioNombre(ChangeEvent<string> e) 
    {
        selecIndividuo.Nombre = e.newValue;
    }

    void CambioApellido(ChangeEvent<string> e) 
    {
        selecIndividuo.Apellido = e.newValue;
    }

    void CambioImagen(ClickEvent e)
    {
        Debug.Log("Click detectado en " + (e.target as VisualElement).name);
        Texture2D imagen = (e.target as VisualElement).style.backgroundImage.value.texture;
        if (selecIndividuo != null)
        {
            selecIndividuo.BackgroundTexture = imagen;    
            Debug.Log(imagen.name);
            Debug.Log("eNTRA");
        }
    }


    void SeleccionTarjeta(ClickEvent e)
    {
        VisualElement tarjeta = e.target as VisualElement;
        selecIndividuo = tarjeta.userData as Individuo;

        inputNombre.SetValueWithoutNotify(selecIndividuo.Nombre);
        inputApellido.SetValueWithoutNotify(selecIndividuo.Apellido);
    }

    void InitalizeUI() 
    {
        Tarjeta tar1 = new Tarjeta(tarjeta1, individuos[0]);
        Tarjeta tar2 = new Tarjeta(tarjeta2, individuos[1]);
        Tarjeta tar3 = new Tarjeta(tarjeta3, individuos[2]);
        Tarjeta tar4 = new Tarjeta(tarjeta4, individuos[3]);
    }
}

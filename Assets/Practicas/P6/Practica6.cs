using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;
using System;
using System.IO;

public class Practica6 : MonoBehaviour
{
    List<IndividuoP6> listaIndividuos;
    IndividuoP6 selecIndividuo;

    [SerializeField]
    Texture2D tex1;
    [SerializeField]
    Texture2D tex2;
    [SerializeField]
    Texture2D tex3;
    [SerializeField]
    Texture2D tex4;

    [SerializeField]
    VisualTreeAsset assetTarjeta = null;

    VisualElement contenerdorDerecha;

    VisualElement botonCrear;
    VisualElement botonGuardar;
    Toggle toggleModificar;

    TextField inputNombre;
    TextField inputApellido;

    private void OnEnable() 
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q("MenuImage1").style.backgroundImage = tex1;
        root.Q("MenuImage2").style.backgroundImage = tex2;
        root.Q("MenuImage3").style.backgroundImage = tex3;
        root.Q("MenuImage4").style.backgroundImage = tex4;

        contenerdorDerecha = root.Q<VisualElement>("CardsSection");
        botonCrear = root.Q<VisualElement>("BotonCrear");
        botonGuardar = root.Q<VisualElement>("BotonGuardar");
        toggleModificar = root.Q<Toggle>("ToggleModificar");
        inputNombre = root.Q<TextField>("TextFieldNombre");
        inputApellido = root.Q<TextField>("TextFieldApellido");
    
        contenerdorDerecha.RegisterCallback<ClickEvent>(SeleccionTarjeta);
        botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
        botonGuardar.RegisterCallback<ClickEvent>(GuardarIndividuos);
        inputNombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        inputApellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);
        root.Query("MenuImages")
            .Descendents<VisualElement>()
            .ForEach(elem => elem.RegisterCallback<ClickEvent>(CambioImagen));
        
        listaIndividuos = BasedatosP6.getData();
        foreach (IndividuoP6 individuo in listaIndividuos)
        {
            VisualElement nuevaTarjeta = assetTarjeta.Instantiate();
            TarjetaP6 tarjetaData = new TarjetaP6(nuevaTarjeta, individuo);

            contenerdorDerecha.Add(nuevaTarjeta);
        }
    }

    void CambioNombre(ChangeEvent<string> e) 
    {
        if (selecIndividuo != null) selecIndividuo.Nombre = e.newValue;
    }

    void CambioApellido(ChangeEvent<string> e) 
    {
        if (selecIndividuo != null) selecIndividuo.Apellido = e.newValue;
    }

    void CambioImagen(ClickEvent e)
    {
        Texture2D imagen = (e.target as VisualElement).style.backgroundImage.value.texture;
        if (selecIndividuo != null)
        {
            selecIndividuo.BackgroundTexture = imagen;
        }
    }


    void SeleccionTarjeta(ClickEvent e)
    {
        VisualElement tarjeta = e.target as VisualElement;
        selecIndividuo = tarjeta.userData as IndividuoP6;

        inputNombre.SetValueWithoutNotify(selecIndividuo.Nombre);
        inputApellido.SetValueWithoutNotify(selecIndividuo.Apellido);

        toggleModificar.value = true;

        tarjetasBordeNegro();
        tarjetaBordeBlanco(tarjeta);
    }

    void NuevaTarjeta(ClickEvent e) 
    {
        if (!toggleModificar.value && listaIndividuos.Count < 9) 
        {
            if (assetTarjeta == null) 
            {
                Debug.LogError("Plantilla no detectada, añade la plantilla de la tarjeta al campo serializado 'assetTarjeta'");
            }
            else
            {
                VisualElement nuevaTarjeta = assetTarjeta.Instantiate();
                IndividuoP6 individuo = new IndividuoP6(inputNombre.value, inputApellido.value);
                TarjetaP6 tarjetaData = new TarjetaP6(nuevaTarjeta, individuo);

                contenerdorDerecha.Add(nuevaTarjeta);
                
                selecIndividuo = individuo;

                tarjetasBordeNegro();
                tarjetaBordeBlanco(nuevaTarjeta);

                listaIndividuos.Add(individuo);
            }
        }
    }

    void GuardarIndividuos(ClickEvent e) 
    {
        StreamWriter sr = new StreamWriter("Assets/Resources/guardadoP6");

        sr.Write(JsonHelperIndividuo.ToJson(listaIndividuos, true));

        sr.Close();

    }

    void tarjetasBordeNegro() 
    {
        List<VisualElement> listaTarjetas = contenerdorDerecha.Children().ToList();
        listaTarjetas.ForEach(
            elem => 
            {
                VisualElement tarjeta = elem.Q("Card");

                tarjeta.style.borderBottomColor = Color.black;
                tarjeta.style.borderTopColor    = Color.black;
                tarjeta.style.borderRightColor  = Color.black;
                tarjeta.style.borderLeftColor   = Color.black;
            }
        );
    }

    void tarjetaBordeBlanco(VisualElement tarjetaRoot) 
    {
        VisualElement tarjeta = tarjetaRoot.Q("Card");

        tarjeta.style.borderBottomColor = Color.white;
        tarjeta.style.borderTopColor    = Color.white;
        tarjeta.style.borderRightColor  = Color.white;
        tarjeta.style.borderLeftColor   = Color.white;
    }
}

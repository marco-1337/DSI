using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tarjeta 
{
    VisualElement tarjetaRoot;
    Individuo myIndividuo;

    Label nombreLabel;
    Label apellidoLabel;

    public Tarjeta(VisualElement tarjetaRoot, Individuo individuo)
    {
        this.tarjetaRoot = tarjetaRoot;
        myIndividuo = individuo;

        nombreLabel = tarjetaRoot.Q<Label>("NameLabel");
        apellidoLabel = tarjetaRoot.Q<Label>("SurnameLabel");
        tarjetaRoot.userData = myIndividuo;

        tarjetaRoot
            .Query(className: "card")
            .Descendents<VisualElement>()
            .ForEach(elem => elem.pickingMode = PickingMode.Ignore);

        UpdateUI();

        myIndividuo.Cambio += UpdateUI;
    }

    void UpdateUI()
    {
        nombreLabel.text = myIndividuo.Nombre;
        apellidoLabel.text = myIndividuo.Apellido;
        
        if (myIndividuo.BackgroundTexture != null)
            tarjetaRoot.Q("CardImage").style.backgroundImage = myIndividuo.BackgroundTexture;
    }
}

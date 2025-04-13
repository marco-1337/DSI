using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

[Serializable]
public class IndividuoP6
{
    public event Action Cambio;
    [SerializeField]
    private string nombre;
    public string Nombre 
    {
        get { return nombre; }
        set
        {
            if (value != nombre)
            {
                nombre = value;
                Cambio?.Invoke();
            }
        }
    }
    [SerializeField]
    private string apellido;
    public string Apellido 
    {
        get { return apellido; }
        set
        {
            if (value != apellido)
            {
                apellido = value;
                Cambio?.Invoke();
            }
        }
    }

    [SerializeField]
    private Texture2D backgroundTexture;
    public Texture2D BackgroundTexture
    {
        get { return backgroundTexture; }
        set
        {
            if (value != backgroundTexture)
            {
                backgroundTexture = value;
                Cambio?.Invoke();
            }
        }
    }

    public IndividuoP6(string nombre, string apellido)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        backgroundTexture = null;
    } 
}

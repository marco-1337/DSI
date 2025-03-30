using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Individuo
{
    public event Action Cambio;

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

    private Texture2D backgroundTexture;
    public Texture2D BackgroundTexture
    {
        get { return backgroundTexture; }
        set
        {
            if (value != backgroundTexture)
            {
                Debug.Log("eNTRA 2");
                backgroundTexture = value;
                Debug.Log(backgroundTexture);
                Cambio?.Invoke();
            }
        }
    }

    public Individuo(string nombre, string apellido)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        backgroundTexture = null;
    } 
}

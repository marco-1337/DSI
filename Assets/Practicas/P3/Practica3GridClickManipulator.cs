using UnityEngine;
using UnityEngine.UIElements;

public class Practica3GridClickManipulator : MouseManipulator
{
    private StyleColor _baseColor, _highlightColor;

    bool _highlighted = false;

    public Practica3GridClickManipulator(StyleColor baseC, StyleColor highlightC)
    {
        activators.Add(new ManipulatorActivationFilter{button = MouseButton.LeftMouse});

        _baseColor = baseC;
        _highlightColor = highlightC;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
    }

    private void OnMouseDown(MouseDownEvent e) {
        Debug.Log(target.name + ": click en elemento");

        StyleColor c;

        if (_highlighted)
            c = _baseColor;
        else    
            c = _highlightColor;
        
        target.style.backgroundColor = c;

        _highlighted = !_highlighted;
        
        e.StopPropagation();
    }
    
}

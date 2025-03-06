using UnityEngine;
using UnityEngine.UIElements;

public class Practica3Manipulator : MouseManipulator
{
    public Practica3Manipulator()
    {
        activators.Add(new ManipulatorActivationFilter{button = MouseButton.RightMouse});
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
    }

    private void OnMouseDown(MouseDownEvent e)
    {
        Debug.Log(target.name + ": Click en elemento");
        if (CanStartManipulation(e))
        {
            target.style.borderBottomColor  = Color.white;
            target.style.borderLeftColor    = Color.white;
            target.style.borderTopColor     = Color.white;
            target.style.borderRightColor   = Color.white;

            e.StopPropagation();
        }
    }
}

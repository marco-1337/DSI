using UnityEngine;
using UnityEngine.UIElements;

public class Practica3Manipulator : Manipulator
{
    public Practica3Manipulator()
    {
        //activators.Add(new ManipulatorActivationFilter{button = MouseButton.RightMouse});
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseOverEvent>(OnMouseEnter);
        target.RegisterCallback<MouseOutEvent>(OnMouseExit);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseOverEvent>(OnMouseEnter);
        target.UnregisterCallback<MouseOutEvent>(OnMouseExit);
    }

    private void OnMouseEnter(MouseOverEvent e) {
                Debug.Log(target.name + ": hover en elemento");
            target.style.borderBottomColor  = Color.white;
            target.style.borderLeftColor    = Color.white;
            target.style.borderTopColor     = Color.white;
            target.style.borderRightColor   = Color.white;

            e.StopPropagation();
        }

    private void OnMouseExit(MouseOutEvent e) {
                Debug.Log(target.name + ": hover en elemento");
        
            target.style.borderBottomColor  = Color.black;
            target.style.borderLeftColor    = Color.black;
            target.style.borderTopColor     = Color.black;
            target.style.borderRightColor   = Color.black;

            e.StopPropagation();
    }
    
}

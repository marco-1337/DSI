using UnityEngine;
using UnityEngine.UIElements;

public class Practica3ResizerManipulator : PointerManipulator
{
    private float _factor, _min, _max;

    private bool _enableRes = false;

    public Practica3ResizerManipulator(float factor, float min, float max)
    {
        _factor = factor;
        _min = min;
        _max = max;
        
        activators.Add(new ManipulatorActivationFilter{button = MouseButton.LeftMouse});
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<WheelEvent>(OnScroll);
        target.RegisterCallback<PointerDownEvent>(OnPointerDown);
        target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        target.RegisterCallback<MouseOutEvent>(OnMouseExit);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<WheelEvent>(OnScroll);
        target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        target.RegisterCallback<MouseOutEvent>(OnMouseExit);
    }

    private void OnScroll(WheelEvent e) {
        float delta = e.delta.y;

        if (_enableRes)
            target.transform.scale =
                new Vector3(
                    Mathf.Clamp(target.transform.scale.x + delta * _factor, _min, _max), 
                    Mathf.Clamp(target.transform.scale.y + delta * _factor, _min, _max), 
                    target.transform.scale.z );

        e.StopPropagation();
    }

    private void OnPointerDown(PointerDownEvent e) {
        Debug.Log(target.name + ": click en elemento");
        _enableRes = true;
        e.StopPropagation();
    }

    private void OnPointerUp(PointerUpEvent e) {
        Debug.Log(target.name + ": release en elemento");
        _enableRes = false;
        e.StopPropagation();
    }

    private void OnMouseExit(MouseOutEvent e) {
        Debug.Log(target.name + ": leave hover en elemento");
        _enableRes = false;
        e.StopPropagation();
    }
    
}

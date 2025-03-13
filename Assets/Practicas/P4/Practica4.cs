using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Practica4 : VisualElement
{

    // Query all stat tmplates

    public new class UxmlFactory : UxmlFactory<Practica4, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription statName = new UxmlStringAttributeDescription { name = "statName", defaultValue = "Stat" };
        UxmlStringAttributeDescription filename = new UxmlStringAttributeDescription { name = "filename", defaultValue = "" };
        UxmlIntAttributeDescription value = new UxmlIntAttributeDescription { name = "value", defaultValue = 5 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
        }
    }
}

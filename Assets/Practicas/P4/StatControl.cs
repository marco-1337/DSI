using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatControl : VisualElement
{

    private string _statName = "";
    public string statName {
        get { return _statName; }
        set { 
            _statName = value;
            changeStatName();
        }
    }

    private string _itemPic = "";
    public string itemPic
    {
        get { return _itemPic; }
        set { 
            _itemPic = value;
            changeItemPic();
        }
    }

    private int _value;
    public int value
    {
        get { return _value; }
        set { 
            _value = value;
            changeValue();    
        }
    }

    public StatControl()
    {
        AddToClassList("stat");

        var title = new VisualElement();
        title.AddToClassList("stat-title");

        //var label = new Label(_statName);
        //title.Add(label);

        hierarchy.Add(title);


        var value = new VisualElement();
        value.AddToClassList("stat-level");
        var item = new VisualElement();
        item.AddToClassList($"item");
        //if(_itemPic != "")
        //    item.AddToClassList($"item-{_itemPic}");

        //for (int i = 0; i < 5; i++)
        //    value.Add(item);
        value.Add(item);
        value.Add(item);
        value.Add(item);
        value.Add(item);
        value.Add(item);

        hierarchy.Add(value);
    }

    public void changeStatName()
    {
        var title = this.Q<VisualElement>("stat-title");
        var label = title.Q<Label>();
        label.text = _statName;
    }

    public void changeItemPic()
    {
        var value = this.Q<VisualElement>("stat-level");
        List<VisualElement> items = value.Query<VisualElement>("item").ToList();
        foreach (var item in items)
        {
            item.ClearClassList();
            item.AddToClassList($"item");
            if (_itemPic != "")
                item.AddToClassList($"item-{_itemPic}");
        }
    }

    public void changeValue()
    {
        var value = this.Q<VisualElement>("stat-level");
        List<VisualElement> items = value.Query<VisualElement>("item").ToList();
        for (int i = 0; i < 5; i++)
        {
            if (i < _value)
                items[i].RemoveFromClassList("item-inactive");
            else
                items[i].AddToClassList("item-inactive");
        }
    }


    public new class UxmlFactory : UxmlFactory<StatControl, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription myStatName = new UxmlStringAttributeDescription { name = "statName", defaultValue = "Stat" };
        UxmlStringAttributeDescription myItemPic = new UxmlStringAttributeDescription { name = "itemPic", defaultValue = "" };
        UxmlIntAttributeDescription myValue = new UxmlIntAttributeDescription { name = "value", defaultValue = 5 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            ((StatControl)ve)._statName = myStatName.GetValueFromBag(bag, cc);
            //((StatControl)ve).itemPic = myItemPic.GetValueFromBag(bag, cc);
            //((StatControl)ve).value = myValue.GetValueFromBag(bag, cc);
        }
    }
}


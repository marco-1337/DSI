using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class StatControl : VisualElement
{

    private string _statName;
    public string statName {
        get { return _statName; }
        set { 
            _statName = value;
            changeStatName();
        }
    }

    private string _itemPic;
    public string itemPic
    {
        get { return _itemPic; }
        set { 
            _itemPic = value;
            changeItemPic();
        }
    }

    private int _statLevel;
    public int statLevel
    {
        get { return _statLevel; }
        set { 
            _statLevel = value;
            changeValue();    
        }
    }

    #region VE
    VisualElement title = new VisualElement();
    Label label = new Label();

    VisualElement statValue = new VisualElement();
    List<VisualElement> items = new List<VisualElement>();
    #endregion

    public StatControl()
    {
        AddToClassList("stat");

        title.AddToClassList("stat-title");
        title.Add(label);
        changeStatName();

        hierarchy.Add(title);

        statValue.AddToClassList("stat-level");
        for(int i = 0; i < 5; i++)
        {
            VisualElement item = new VisualElement();
            item.AddToClassList("item");
            if (_itemPic != "")
            {
                item.AddToClassList($"item-{_itemPic}");
            }
            items.Add(item);
            statValue.Add(item);
        }
        changeItemPic();

        hierarchy.Add(statValue);
    }

    public void changeStatName()
    {
        label.text = _statName;
        Debug.Log("Stat Name: " + _statName);
    }

    public void changeItemPic()
    {
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
        for (int i = 0; i < 5; i++)
        {
            if (i < _statLevel)
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
            ((StatControl)ve).statName = myStatName.GetValueFromBag(bag, cc);
            ((StatControl)ve).itemPic = myItemPic.GetValueFromBag(bag, cc);
            ((StatControl)ve).statLevel = myValue.GetValueFromBag(bag, cc);
        }
    }
}


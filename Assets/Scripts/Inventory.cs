using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _inventoryLength = 6;

    private int _inventoryIndex = 0;
    private List<IItem> _items;

    void Start()
    {
        _items = new List<IItem>(_inventoryLength);
    }

    public void MoveIndexUp() => _inventoryIndex = Mathf.Min(_inventoryIndex + 1, _inventoryLength - 1);

    public void MoveIndexDown() => _inventoryIndex = Mathf.Max(_inventoryIndex - 1, 0);

    public void UseCurrentItem()
    {
        _items[_inventoryIndex].Use();
    }
}

public interface IItem
{
    void Use();
}

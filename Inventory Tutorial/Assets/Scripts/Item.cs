using System;
using UnityEngine;

public class Item : ScriptableObject {

    public string Name;
    public Texture2D Icon;
    public Enums.ItemType ItemType;

    public void Consume() { }
}

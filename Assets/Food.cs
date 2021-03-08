using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName="Food")]
public class Food : ScriptableObject
{
    public Category category;
    public Sprite image;
    public Food progression;
}

public enum Category {
    compost,
    landfill,
    recycle,
    liquid,
    donate
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rune Config")]
public class RuneConfig : ScriptableObject
{
    public float lifeTime;
    public float size;
    public int cost;

    public float GetLifeTime()
    {
        return lifeTime;
    }

    public float GetSize()
    {
        return size;
    }

    public int GetCost()
    {
        return cost;
    }
}

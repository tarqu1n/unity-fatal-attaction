using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] availableSprites;
    public List<int> usedSpriteIndexes = new List<int>();
    public Sprite GetRandom()
    {
        int index = UnityEngine.Random.Range(0, availableSprites.Length);
        if (!usedSpriteIndexes.Contains(index)) {
            usedSpriteIndexes.Add(index);
            return availableSprites[index];
        }
        else
        {
            return GetRandom();
        }
        
    }
}

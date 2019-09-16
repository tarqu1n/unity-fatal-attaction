using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] availableSprites;
    public GameObject[] selectionEffects;

    [HideInInspector]
    public List<int> usedSpriteIndexes = new List<int>();
    public MonsterInfo GetRandom()
    {
        int index = UnityEngine.Random.Range(0, availableSprites.Length);
        MonsterInfo monsterInfo = new MonsterInfo();
        if (!usedSpriteIndexes.Contains(index)) {
            usedSpriteIndexes.Add(index);

            monsterInfo.sprite = availableSprites[index];
            monsterInfo.selectionEffect = GetSelectionEffectByIndex(index);

            return monsterInfo;
        }
        else
        {
            return GetRandom();
        }
    }

    private GameObject GetSelectionEffectByIndex (int index)
    {
        GameObject def = null;
        foreach (GameObject obj in selectionEffects)
        {
           if (obj.name == index.ToString())
            {
                return obj;
            }
           if (obj.name == "Default")
            {
                def = obj;
            }
        }

        return def;
    }
    [HideInInspector]
    public class MonsterInfo
    {
        public Sprite sprite;
        public GameObject selectionEffect;
    }
}

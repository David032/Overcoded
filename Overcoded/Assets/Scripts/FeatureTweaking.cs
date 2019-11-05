﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class FeatureTweaking 
{
    public static bool ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dict,
                                       TKey oldKey, TKey newKey)
    {
        TValue value;
        if (!dict.TryGetValue(oldKey, out value))
            return false;

        dict.Remove(oldKey);  // do not change order
        dict[newKey] = value;  // or dict.Add(newKey, value) depending on ur comfort
        return true;
    }
}

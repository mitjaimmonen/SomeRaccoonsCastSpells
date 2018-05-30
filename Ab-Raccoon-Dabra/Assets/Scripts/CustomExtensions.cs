using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomExtensions {

    public static List<int> GetMaskIndices(LayerMask aMask)
    {
        List<int> indices = new List<int>(32);
        for(int i = 0; i < 32; i++)
        {
            if ((aMask.value & (1 << i)) > 0)
                indices.Add(i);
        }
        return indices;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPickUpFinger : MonoBehaviour
{
    public bool[] HasFinger = new bool[5];
    public int Count = 0;

    private void Update()
    {
        Count = CountFinger();
    }
    int CountFinger()
    {
        int count = 0;
        for(int i = 0; i < HasFinger.Length; i++)
        {
            if(HasFinger[i] == true)
            {
                count++;
            }
        }

        return count;
    }
}

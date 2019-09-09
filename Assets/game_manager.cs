using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class game_manager : MonoBehaviour
{
    public static int[,] ARR = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public static int black_or_white = 1;
    int play = 1;
    int refer()
    {
        int zero = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (ARR[i, j]==0)
                {
                    zero++;
                }
            }
            if (ARR[i, 0] == 1 && ARR[i, 1] == 1 && ARR[i, 2] == 1)
            {
                return 1;
            }
            if (ARR[0, i] == 1 && ARR[1, i] == 1 && ARR[2, i] == 1)
            {
                return 1;
            }
            if (ARR[i, 0] == 2 && ARR[i, 1] == 2 && ARR[i, 2] == 2)
            {
                return 2;
            }
            if (ARR[0, i] == 2 && ARR[1, i] == 2 && ARR[2, i] == 2)
            {
                return 2;
            }
        }
        if (ARR[0, 0] == 1 && ARR[1, 1] == 1 && ARR[2, 2] == 1)
        {
            return 1;
        }
        if (ARR[0, 2] == 1 && ARR[1, 1] == 1 && ARR[2, 0] == 1)
        {
            return 1;
        }
        if (ARR[0, 0] == 2 && ARR[1, 1] == 2 && ARR[2, 2] == 2)
        {
            return 2;
        }
        if (ARR[0, 2] == 2 && ARR[1, 1] == 2 && ARR[2, 0] == 2)
        {
            return 2;
        }
        if (zero==0)
        {
            return 3;
        }
        return 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play==1)
        {
            int r = refer();
            if (r == 1)
            {
                Debug.Log("Black Win");
                play = 0;
            }
            if (r == 2)
            {
                Debug.Log("white Win");
                play = 0;
            }
            if (r == 3)
            {
                Debug.Log("draw");
                play = 0;
            }
        }
    }
}

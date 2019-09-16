using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class game_manager : MonoBehaviour
{
    public static int[,] ARR = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public static int black_or_white = 1;
    private int LENGTH = 9;
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



    public void AI()
    {
        int[,] NEW_ARR = new int[3, 3];

        ArrayList zero_list_y = new ArrayList();
        ArrayList zero_list_x = new ArrayList();
        ArrayList monte = new ArrayList();
        void make_arr()
        {
            zero_list_y.Clear();
            zero_list_x.Clear();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ARR[i, j] == 0)
                    {
                        zero_list_y.Add(i);
                        zero_list_x.Add(j);
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NEW_ARR[i, j] = ARR[i, j];
                }
            }
        }

        make_arr();
        Debug.Log(zero_list_y.Count);
        Debug.Log(zero_list_x.Count);
        int simul_refer(int hb)
        {
            while(true)
            {
                int zero = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (NEW_ARR[i, j] == 0)
                        {
                            zero++;
                        }
                    }
                    if (NEW_ARR[i, 0] == 1 && NEW_ARR[i, 1] == 1 && NEW_ARR[i, 2] == 1)
                    {
                        return -2;
                    }
                    if (NEW_ARR[0, i] == 1 && NEW_ARR[1, i] == 1 && NEW_ARR[2, i] == 1)
                    {
                        return -2;
                    }
                    if (NEW_ARR[i, 0] == 2 && NEW_ARR[i, 1] == 2 && NEW_ARR[i, 2] == 2)
                    {
                        return 2;
                    }
                    if (NEW_ARR[0, i] == 2 && NEW_ARR[1, i] == 2 && NEW_ARR[2, i] == 2)
                    {
                        return 2;
                    }
                }
                if (NEW_ARR[0, 0] == 1 && NEW_ARR[1, 1] == 1 && NEW_ARR[2, 2] == 1)
                {
                    return -2;
                }
                if (NEW_ARR[0, 2] == 1 && NEW_ARR[1, 1] == 1 && NEW_ARR[2, 0] == 1)
                {
                    return -2;
                }
                if (NEW_ARR[0, 0] == 2 && NEW_ARR[1, 1] == 2 && NEW_ARR[2, 2] == 2)
                {
                    return 2;
                }
                if (NEW_ARR[0, 2] == 2 && NEW_ARR[1, 1] == 2 && NEW_ARR[2, 0] == 2)
                {
                    return 2;
                }
                if (zero == 0 || zero_list_y.Count==0 || zero_list_x.Count == 0)
                {
                    return 0;
                }
                int rand = Random.Range(0, (int)zero_list_y.Count);
                int yy = (int)zero_list_y[rand];
                int xx = (int)zero_list_x[rand];
                NEW_ARR[yy,xx] = hb;
                zero_list_y.RemoveAt(rand);
                zero_list_x.RemoveAt(rand);

                if (hb == 1)
                {
                    hb = 2;
                }
                else
                {
                    hb = 1;
                }
            }
        }
        int RR = zero_list_y.Count;

        for (int i = 0; i < RR; i++)
        {
            monte.Add(0);
        }
        for (int i = 0; i < RR; i++)
        {
            int yy = (int)zero_list_y[i];
            int xx = (int)zero_list_x[i];
            NEW_ARR[yy, xx] = 2;
            zero_list_y.RemoveAt(i);
            zero_list_x.RemoveAt(i);
            // 백을 둔다.
            
            monte[i] = (int)monte[i] + simul_refer(1);
            make_arr();
            Debug.Log(monte[i]);
            //Debug.Log(monte.Count);
            //Debug.Log(i);
        }

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

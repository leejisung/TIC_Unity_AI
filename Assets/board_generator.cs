using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board_generator : MonoBehaviour
{
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y<3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Transform cell = Instantiate(prefab, new Vector3(y, x, 0), Quaternion.identity);
                cell.GetComponent<cell>().x = x;
                cell.GetComponent<cell>().y = y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

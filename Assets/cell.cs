using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{
    public GameObject manager;
    public Sprite empty;
    public Sprite black;
    public Sprite white;
    public int x;
    public int y;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        if (game_manager.ARR[x,y]==0)
        {
            if (game_manager.black_or_white == 1)
            {
                game_manager.ARR[x, y] = 1;
                game_manager.black_or_white = 2;
            }
            else if (game_manager.black_or_white == 2)
            {
                game_manager.ARR[x, y] = 2;
                game_manager.black_or_white = 1;
            }
        }
    }
    void Update()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (game_manager.ARR[x,y]==0)
        {
            spriteRenderer.sprite = empty;
        }
        if (game_manager.ARR[x, y] == 1)
        {
            spriteRenderer.sprite = black;
        }
        if (game_manager.ARR[x, y] == 2)
        {
            spriteRenderer.sprite = white;
        }
        

    }
}

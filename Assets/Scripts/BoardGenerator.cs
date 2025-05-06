using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardGenerator : MonoBehaviour
{
    [Serializable]
    public class GridItem
    {
        public RectInt position;
        public float value;
        public GameObject assigned;
        public Sprite design;
        public GridItem ( RectInt position ) 
        {
            this.position = position; 
            value = position.width * position.height;
        }
    }

    public class GridRectanglePiece : GridItem
    {
        public Team team;
        public enum Team
        {
            Blu,
            Red
        }
        public GridRectanglePiece( RectInt position, Team team ) : base( position )
        {
            this.team = team;
        }
    }
    public class GridPlacablePiece : GridItem
    {
        public GridPlacablePiece ( RectInt position ) : base( position ) { }
    }


    // :P
    public float scale;

    [SerializeField]
    public List<GridItem> board = new() { };

    public Sprite background;
    public Sprite frame;

    public void Start ( )
    {
        foreach (var item in board)
        {
            GameObject obj = new("Board Piece");
            obj.transform.SetParent( transform );
            item.assigned = obj;
            obj.AddComponent<Image>();
        }
        ReDraw( );
    }

    public void Update ( )
    {
        ReDraw( );
    }

    public void ReDraw ( )
    {
        foreach (var item in board)
        {
            GameObject obj = item.assigned;
            obj.transform.localPosition = new Vector3( item.position.x, item.position.y ) * scale;
            obj.transform.localScale = new Vector3( item.position.width, item.position.height ) * scale;
            Image i = obj.GetComponent<Image>( );
            i.sprite = item.design;
        }
    }
}

using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Vector2 roomSize = new Vector2(16, 9);
    public float wallThickness = 0.1f;

    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls()
    {
        CreateWall(new Vector2(0, roomSize.y / 2 + wallThickness / 2), new Vector2(roomSize.x, wallThickness));
        CreateWall(new Vector2(0, -roomSize.y / 2 - wallThickness / 2), new Vector2(roomSize.x, wallThickness));
        CreateWall(new Vector2(-roomSize.x / 2 - wallThickness / 2, 0), new Vector2(wallThickness, roomSize.y));
        CreateWall(new Vector2(roomSize.x / 2 + wallThickness / 2, 0), new Vector2(wallThickness, roomSize.y));
    }

    void CreateWall(Vector2 position, Vector2 scale)
    {
        GameObject wall = new GameObject("Wall");
        wall.transform.parent = transform;
        wall.transform.position = position;

        BoxCollider2D collider = wall.AddComponent<BoxCollider2D>();
        collider.size = scale;

        SpriteRenderer sr = wall.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("white_square");
        sr.color = Color.gray;
    }

}

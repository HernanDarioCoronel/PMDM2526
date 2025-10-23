using UnityEngine;

public class Explode2D : MonoBehaviour
{
    [Header("Explosion Settings")]
    int piecesX = 15;
    int piecesY = 15;
    float minForce = 3f;
    float maxForce = 8f;
    float minTorque = 100f;
    float maxTorque = 500f;
    float explosionDuration = 3f;

    public void Explode()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (!spriteRenderer)
            return;

        Texture2D texture = spriteRenderer.sprite.texture;
        Rect rect = spriteRenderer.sprite.rect;

        float pieceWidth = rect.width / piecesX;
        float pieceHeight = rect.height / piecesY;

        for (int x = 0; x < piecesX; x++)
        {
            for (int y = 0; y < piecesY; y++)
            {
                GameObject piece = new GameObject("Piece");
                piece.transform.position = transform.position;
                piece.transform.localScale = new Vector3(3f, 3f, 1);

                SpriteRenderer pieceSR = piece.AddComponent<SpriteRenderer>();
                pieceSR.sprite = Sprite.Create(
                    texture,
                    new Rect(
                        rect.x + x * pieceWidth,
                        rect.y + y * pieceHeight,
                        pieceWidth,
                        pieceHeight
                    ),
                    new Vector2(0.5f, 0.5f),
                    spriteRenderer.sprite.pixelsPerUnit
                );
                pieceSR.sortingLayerID = spriteRenderer.sortingLayerID;
                pieceSR.sortingOrder = spriteRenderer.sortingOrder;

                piece.transform.localScale = Vector3.one * Random.Range(1f, 1.3f);

                Rigidbody2D rb = piece.AddComponent<Rigidbody2D>();

                Vector2 direction = new Vector2(
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f)
                ).normalized;
                float force = Random.Range(minForce, maxForce);
                rb.AddForce(direction * force, ForceMode2D.Impulse);

                float torque = Random.Range(minTorque, maxTorque) * (Random.value < 0.5f ? -1 : 1);
                rb.AddTorque(torque);
                Destroy(piece, explosionDuration);
            }
        }
    }
}

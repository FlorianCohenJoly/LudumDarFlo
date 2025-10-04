using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 move;

    void Awake() { rb = GetComponent<Rigidbody2D>(); rb.gravityScale = 0; rb.freezeRotation = true; }

    void Update() {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        if (move.sqrMagnitude > 1) move.Normalize();
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}

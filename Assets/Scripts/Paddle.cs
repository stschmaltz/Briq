using UnityEngine;
using UnityEngine.InputSystem;


public class Paddle : MonoBehaviour
{
    public Rigidbody2D rigidBody { get; private set; }

    public Vector2 direction { get; private set; }

    private void Awake()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(transform.position);
        Debug.Log(Touchscreen.current.primaryTouch.press.isPressed);
        Debug.Log($"Touchscreen position{Touchscreen.current.primaryTouch.position.ReadValue()}");
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue());
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(touchedPos.x, transform.position.y, 0f), 0.3f);
        }
    }
}


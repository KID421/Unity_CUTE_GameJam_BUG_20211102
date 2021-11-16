using UnityEngine;

public class Controller2D : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 10;

    public float valueHorizontal { get => Input.GetAxis("Horizontal"); }

    private Rigidbody2D rig;
    

    private void Awake() 
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        Flip();
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void Move()
    {
        rig.velocity = Vector2.right * valueHorizontal * speed;
    }

    private void Flip()
    {
        if (Mathf.Abs(valueHorizontal) < 0.1f) return;
        float y = valueHorizontal > 0 ? 0 : 180;
        transform.eulerAngles = new Vector3(0, y, 0 );
    }
}

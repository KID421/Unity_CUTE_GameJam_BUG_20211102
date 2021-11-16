using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    private void Hit(GameObject hit)
    {
        hit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.name == "玩家") Hit(other.gameObject);
    }
}

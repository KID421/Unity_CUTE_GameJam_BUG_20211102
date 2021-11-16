using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("閃退位置與半徑")]
    public Vector3 positionCrash = new Vector3(6, -3.3f, 0);
    [Range(0, 5)]
    public float radiusCrash = 1;

    private void OnDrawGizmos() 
    {
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(positionCrash, radiusCrash);
    }

    private void Update() 
    {
        CheckPlayerInCrashPosition();
    }

    private void CheckPlayerInCrashPosition()
    {
        Collider2D hit = Physics2D.OverlapCircle(positionCrash, radiusCrash, 1 << 3);

        if (hit) Crash();
    }

    private void Crash()
    {
        Application.Quit();
        print("閃退");
    }
}

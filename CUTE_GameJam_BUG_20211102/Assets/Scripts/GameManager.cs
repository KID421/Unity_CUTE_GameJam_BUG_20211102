using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("閃退位置與半徑")]
    public Vector3 positionCrash = new Vector3(6, -3.3f, 0);
    [Range(0, 5)]
    public float radiusCrash = 1;

    [Header("正確位置與半徑")]
    public Vector3 positionCorrect = new Vector3(6, -3.3f, 0);
    [Range(0, 5)]
    public float radiusCorrect = 1;

    public bool clickUp { get => Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W); }

    public Transform traClassRoom;

    private void OnDrawGizmos() 
    {
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(positionCrash, radiusCrash);

        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(positionCorrect, radiusCorrect);
    }

    private void Update() 
    {
        if (clickUp) CheckPlayerInCrashPosition();
        if (clickUp) CheckPlayerInCorrectPosition();
    }

    private void CheckPlayerInCrashPosition()
    {
        Collider2D hit = Physics2D.OverlapCircle(positionCrash, radiusCrash, 1 << 3);

        if (hit) Crash();
    }

    private void CheckPlayerInCorrectPosition()
    {
        Collider2D hit = Physics2D.OverlapCircle(positionCorrect, radiusCorrect, 1 << 3);

        if (hit) Correct(hit.transform);
    }

    private void Crash()
    {
        Application.Quit();
        print("閃退");
    }

    private void Correct(Transform target)
    {
        print("正確");
        target.position = traClassRoom.position;
    }
}


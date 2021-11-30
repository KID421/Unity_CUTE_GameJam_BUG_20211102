using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("對話位置與半徑")]
    public Vector3 positionCrash = new Vector3(1, -3.5f, 0);
    [Range(0, 5)]
    public float radiusCrash = 1;

    [Header("對話內容")]
    public string[] dialogueContent = 
    {
        "嗨，你是新同學嗎？",
        "請交保護費~"
    };

    [Header("打字事件")]
    public UnityEvent onType;

    public CanvasGroup groupDialogue;

    public float dialogueInterval = 0.02f;

    public Text textDialogue;

    public bool playerIn;

    public GameObject tipDialogue;

    private void OnDrawGizmos() 
    {
        Gizmos.color = new Color(0.2f, 0, 1f, 0.3f);
        Gizmos.DrawSphere(positionCrash, radiusCrash);
    }

    private void Update() 
    {
        CheckPlayerInCrashPosition();
    }

    private void CheckPlayerInCrashPosition()
    {
        Collider2D hit = Physics2D.OverlapCircle(positionCrash, radiusCrash, 1 << 3);

        if (!playerIn && hit) 
        {
            playerIn = true;
            StartDialouge();
        }
        else if (playerIn && hit == null)
        {
            playerIn = false;
            StartCoroutine(GroupDialogueFade(false));
        }
    }

    private void StartDialouge()
    {
        StartCoroutine(GroupDialogueFade(true));
    }

    private IEnumerator GroupDialogueFade(bool increase)
    {
        float add = increase ? 0.1f : -0.1f;

        for (int i = 0; i < 10; i++)
        {
            groupDialogue.alpha += add;
            yield return new WaitForSeconds(0.05f);
        }

        if (increase) StartCoroutine(ShowDialogue());
    }   

    private IEnumerator ShowDialogue()
    {
        for (int i = 0; i < dialogueContent.Length; i++)
        {
            textDialogue.text = "";
            tipDialogue.SetActive(false);

            for (int j = 0; j < dialogueContent[i].Length; j++)
            {
                onType.Invoke();
                textDialogue.text += dialogueContent[i][j];
                yield return new WaitForSeconds(dialogueInterval);
            }

            tipDialogue.SetActive(true);

            while (!Input.anyKeyDown) yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Transform target; // ��������, ��� ������� ����� ������������ �����
    public Vector3 offset = new Vector3(0, 2, 0); // �������� ������ ��� ������� ���������
    private float typingSpeed; // �������� ���������
    private float delayClean; 

    public TextMeshProUGUI textComponent;
    private string fullText; // ������ �����, ������� ����� �������

    private void Start()
    {
        fullText = textComponent.text; // ��������� ������ �����
        textComponent.text = ""; // ������� ����� ����� ����������

        StartCoroutine(TypeText()); // ��������� ��������� ������
    }

    private void FixedUpdate()
    {
        // ��������� ������� UI Image ��� ������� ���������
        if (target != null)
        {
            Vector3 screenPosition = (target.position + offset);//Camera.main.WorldToScreenPoint
            transform.position = screenPosition;
        }
    }

    private IEnumerator TypeText()
    {
        // ���������� ��������� �����
        for (int i = 0; i < fullText.Length; i++)
        {
            if (fullText[i] == '<')
            {
                for (; fullText[i] != '>'; i++) ;
                i++;
            }// filter html tags

            textComponent.text = fullText.Substring(0, i);  
            yield return new WaitForSeconds(typingSpeed); // �������� ��� ������� ���������
        }
        textComponent.text = fullText.Substring(0, fullText.Length);// gavno kod :(

        // ���� ����� ��������� ������
        yield return new WaitForSeconds(delayClean);

        // ���������� ������� �����
        for (int i = fullText.Length-1; i > 0; i--)
        {
            if (fullText[i] == '>')
            {
                for (; fullText[i] != '<'; i--) ;
                i--;
            }// filter html tags
            
            textComponent.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed); // �������� ��� ������� ��������
        }
        textComponent.text = fullText.Substring(0, 0);// gavno kod :(

    }

    /// <summary>
    /// For "enter" use \n
    /// For coloring use html, example: <color=#FF0000>Red</color>
    /// </summary>
    public void SetText(string newText, float typingSpeed = 0.05f, float delayClean = 1f)
    {
        this.typingSpeed = typingSpeed;
        this.delayClean = delayClean;
        this.fullText = newText; // ��������� ������ �����

        StopAllCoroutines(); // ������������� ������� �������� ���������
        StartCoroutine(TypeText()); // ������������� ��������� � ����� �������
    }
}

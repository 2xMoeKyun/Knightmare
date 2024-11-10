using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Transform target; // Персонаж, над которым будет отображаться текст
    public Vector3 offset = new Vector3(0, 2, 0); // Смещение текста над головой персонажа
    private float typingSpeed; // Скорость печатания
    private float delayClean; 

    public TextMeshProUGUI textComponent;
    private string fullText; // Полный текст, который нужно вывести

    private void Start()
    {
        fullText = textComponent.text; // Сохраняем полный текст
        textComponent.text = ""; // Очищаем текст перед печатанием

        StartCoroutine(TypeText()); // Запускаем печатание текста
    }

    private void FixedUpdate()
    {
        // Обновляем позицию UI Image над головой персонажа
        if (target != null)
        {
            Vector3 screenPosition = (target.position + offset);//Camera.main.WorldToScreenPoint
            transform.position = screenPosition;
        }
    }

    private IEnumerator TypeText()
    {
        // Постепенно добавляем текст
        for (int i = 0; i < fullText.Length; i++)
        {
            if (fullText[i] == '<')
            {
                for (; fullText[i] != '>'; i++) ;
                i++;
            }// filter html tags

            textComponent.text = fullText.Substring(0, i);  
            yield return new WaitForSeconds(typingSpeed); // Задержка для эффекта печатания
        }
        textComponent.text = fullText.Substring(0, fullText.Length);// gavno kod :(

        // Ждем перед удалением текста
        yield return new WaitForSeconds(delayClean);

        // Постепенно убираем текст
        for (int i = fullText.Length-1; i > 0; i--)
        {
            if (fullText[i] == '>')
            {
                for (; fullText[i] != '<'; i--) ;
                i--;
            }// filter html tags
            
            textComponent.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed); // Задержка для эффекта удаления
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
        this.fullText = newText; // Обновляем полный текст

        StopAllCoroutines(); // Останавливаем текущую анимацию печатания
        StartCoroutine(TypeText()); // Перезапускаем печатание с новым текстом
    }
}

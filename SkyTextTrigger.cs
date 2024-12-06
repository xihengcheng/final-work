using UnityEngine;
using TMPro;

public class SkyTextTrigger : MonoBehaviour
{
    public TextMeshPro textMesh; // ���� TextMeshPro �ı�
    public float fadeDuration = 2f; // �������ʱ��

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // �������Ƿ���봥������
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(FadeInText());
        }
    }

    private System.Collections.IEnumerator FadeInText()
    {
        float elapsedTime = 0f;

        // ��ȡ�ı���ǰ��ɫ
        Color textColor = textMesh.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            textColor.a = alpha; // ���� Alpha ͨ��
            textMesh.color = textColor; // �����ı���ɫ
            yield return null; // �ȴ���һ֡
        }

        // ȷ���ı���ȫ��ʾ
        textColor.a = 1f;
        textMesh.color = textColor;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameEndTrigger : MonoBehaviour
{
    public Image endImage; // ���ý���ͼƬ
    public float fadeDuration = 2f; // ͼƬ�������ʱ��

    private bool isGameEnded = false;

    private void OnTriggerEnter(Collider other)
    {
        // �������Ƿ���봥������
        if (other.CompareTag("Player") && !isGameEnded)
        {
            isGameEnded = true;
            StartCoroutine(FadeInEndImage());
        }
    }

    private System.Collections.IEnumerator FadeInEndImage()
    {
        float elapsedTime = 0f;

        // ��ȡͼƬ��ǰ����ɫ
        Color imageColor = endImage.color;

        // ȷ����Ϸδ��ͣ
        Time.timeScale = 1f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageColor.a = alpha; // ���� Alpha ͨ��
            endImage.color = imageColor; // ����ͼƬ��ɫ
            yield return null; // �ȴ���һ֡
        }

        // ȷ��ͼƬ��ȫ��ʾ
        imageColor.a = 1f;
        endImage.color = imageColor;

        // ��ͣ��Ϸ
        Time.timeScale = 0f;
    }
}

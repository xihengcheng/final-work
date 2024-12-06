using UnityEngine;
using TMPro;

public class SkyTextTrigger : MonoBehaviour
{
    public TextMeshPro textMesh; // 引用 TextMeshPro 文本
    public float fadeDuration = 2f; // 淡入持续时间

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // 检查玩家是否进入触发区域
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(FadeInText());
        }
    }

    private System.Collections.IEnumerator FadeInText()
    {
        float elapsedTime = 0f;

        // 获取文本当前颜色
        Color textColor = textMesh.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            textColor.a = alpha; // 更新 Alpha 通道
            textMesh.color = textColor; // 设置文本颜色
            yield return null; // 等待下一帧
        }

        // 确保文本完全显示
        textColor.a = 1f;
        textMesh.color = textColor;
    }
}

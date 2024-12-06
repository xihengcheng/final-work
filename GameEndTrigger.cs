using UnityEngine;
using UnityEngine.UI;

public class GameEndTrigger : MonoBehaviour
{
    public Image endImage; // 引用结束图片
    public float fadeDuration = 2f; // 图片淡入持续时间

    private bool isGameEnded = false;

    private void OnTriggerEnter(Collider other)
    {
        // 检查玩家是否进入触发区域
        if (other.CompareTag("Player") && !isGameEnded)
        {
            isGameEnded = true;
            StartCoroutine(FadeInEndImage());
        }
    }

    private System.Collections.IEnumerator FadeInEndImage()
    {
        float elapsedTime = 0f;

        // 获取图片当前的颜色
        Color imageColor = endImage.color;

        // 确保游戏未暂停
        Time.timeScale = 1f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageColor.a = alpha; // 更新 Alpha 通道
            endImage.color = imageColor; // 设置图片颜色
            yield return null; // 等待下一帧
        }

        // 确保图片完全显示
        imageColor.a = 1f;
        endImage.color = imageColor;

        // 暂停游戏
        Time.timeScale = 0f;
    }
}

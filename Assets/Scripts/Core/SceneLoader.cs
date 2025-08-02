using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private CanvasGroup _fadeCanvasGroup;
    [SerializeField] private Image _danceImage; // Один Image для общей картинки

    [Header("Sprites")]
    [SerializeField] private Sprite[] _danceSprites; // 2 кадра: оба персонажа на одном спрайте

    [Header("Fade Settings")]
    [SerializeField] private float _fadeDuration = 0.5f;
    [SerializeField] private float _animFrameTime = 0.3f;

    private Coroutine _animCoroutine;

    private void Awake()
    {
        if (_fadeCanvasGroup != null)
            _fadeCanvasGroup.alpha = 0f;
        if (_danceImage != null)
            _danceImage.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return StartCoroutine(Fade(1f));

        if (_danceImage != null) _danceImage.gameObject.SetActive(true);

        _animCoroutine = StartCoroutine(PlayDanceAnimation());

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        if (_animCoroutine != null)
            StopCoroutine(_animCoroutine);

        if (_danceImage != null) _danceImage.gameObject.SetActive(false);

        yield return StartCoroutine(Fade(0f));

        asyncLoad.allowSceneActivation = true;  
    }

    private IEnumerator PlayDanceAnimation()
    {
        int frame = 0;
        while (true)
        {
            if (_danceSprites.Length > 0 && _danceImage != null)
                _danceImage.sprite = _danceSprites[frame % _danceSprites.Length];

            frame++;
            yield return new WaitForSeconds(_animFrameTime);
        }
    }

    private IEnumerator Fade(float targetAlpha)
    {
        if (_fadeCanvasGroup == null)
            yield break;

        float startAlpha = _fadeCanvasGroup.alpha;
        float time = 0f;

        while (time < _fadeDuration)
        {
            _fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / _fadeDuration);
            time += Time.unscaledDeltaTime;
            yield return null;
        }
        _fadeCanvasGroup.alpha = targetAlpha;
    }
}
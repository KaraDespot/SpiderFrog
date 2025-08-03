using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private CanvasGroup _fadeCanvasGroup;
        [SerializeField] private Image _frogDanceImage; // лягушка
    [SerializeField] private Image _spiderDanceImage; // паук

    [Header("Sprites")]
    [SerializeField] private Sprite _frogDanceSprite1;
    [SerializeField] private Sprite _frogDanceSprite2;
    [SerializeField] private Sprite _spiderDanceSprite1;
    [SerializeField] private Sprite _spiderDanceSprite2;

    [Header("Fade Settings")]
    [SerializeField] private float _fadeDuration = 0.5f;
    [SerializeField] private float _animFrameTime = 0.3f;

    private Coroutine _animCoroutine;

    private void Awake()
    {
        if (_fadeCanvasGroup != null)
            _fadeCanvasGroup.alpha = 0f;
        if (_frogDanceImage != null)
            _frogDanceImage.gameObject.SetActive(false);
        if (_spiderDanceImage != null)
            _spiderDanceImage.gameObject.SetActive(false);
    }

    public void Start()
    {
        // Только для LoadingScene: автозапуск загрузки целевой сцены
        if (SceneManager.GetActiveScene().name == "LoadingScene")
        {
            string nextScene = PlayerPrefs.GetString("NextScene", "GameScene");
            StartCoroutine(LoadSceneAsync(nextScene));
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return StartCoroutine(Fade(1f));

        if (_frogDanceImage != null) _frogDanceImage.gameObject.SetActive(true);
        if (_spiderDanceImage != null) _spiderDanceImage.gameObject.SetActive(true);

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

        if (_frogDanceImage != null) _frogDanceImage.gameObject.SetActive(false);
        if (_spiderDanceImage != null) _spiderDanceImage.gameObject.SetActive(false);

        yield return StartCoroutine(Fade(0f));

        asyncLoad.allowSceneActivation = true;  
    }

    private IEnumerator PlayDanceAnimation()
    {
        int frame = 0;
        while (true)
        {
            if (_frogDanceImage != null)
                _frogDanceImage.sprite = (frame % 2 == 0) ? _frogDanceSprite1 : _frogDanceSprite2;
            if (_spiderDanceImage != null)
                _spiderDanceImage.sprite = (frame % 2 == 0) ? _spiderDanceSprite1 : _spiderDanceSprite2;

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
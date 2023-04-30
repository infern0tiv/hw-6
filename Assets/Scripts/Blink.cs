using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    private Color[][] _defaultEmissionColors;
    private float blinkTime = 1f;

    private void Start()
    {
        for(int i = 0; i < _renderers.Length; i++)
        {
            for(int j = 0; j < _renderers[i].materials.Length; j++)
            {
                _defaultEmissionColors[i][j] = _renderers[i].materials[j].GetColor("_EmissionColor");
            }
        }
    }

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    private IEnumerator ShowEffect()
    {
        for (float t = 0; t < blinkTime; t += Time.deltaTime)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                for (int j = 0; j < _renderers[i].materials.Length; j++)
                {
                    _renderers[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * .5f + .5f, 0, 0, 0));
                }
            }

            yield return null;
        }

        // Не получилось вернуть свечение
        for (int i = 0; i < _renderers.Length; i++)
        {
            for (int j = 0; j < _renderers[i].materials.Length; j++)
            {
                _renderers[i].materials[j].SetColor("_EmissionColor", _defaultEmissionColors[i][j]);
            }
        }

    }
}

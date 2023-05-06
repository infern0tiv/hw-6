using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    private float blinkTime = 1f;

    private List<Color>[] _defaultEmissionColors;

    private void Start()
    {
        _defaultEmissionColors = new List<Color>[_renderers.Length];
        for (int i = 0; i < _renderers.Length; i++)
        {
            _defaultEmissionColors[i] = new List<Color>();
            for (int j = 0; j < _renderers[i].materials.Length; j++)
            {
                _defaultEmissionColors[i].Add(_renderers[i].materials[j].GetColor("_EmissionColor"));
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
            SetColor(new Color(Mathf.Sin(t * 30) * .5f + .5f, 0, 0, 0));
            yield return null;
        }

        ResetColor();
    }

    private void SetColor(Color color)
    {
        for (int i = 0; i < _renderers.Length; i++)
        {
            for (int j = 0; j < _renderers[i].materials.Length; j++)
            {
                _renderers[i].materials[j].SetColor("_EmissionColor", color);
            }
        }

    }

    private void ResetColor()
    {
        for (int i = 0; i < _renderers.Length; i++)
        {
            for (int j = 0; j < _renderers[i].materials.Length; j++)
            {
                _renderers[i].materials[j].SetColor("_EmissionColor", _defaultEmissionColors[i][j]);
            }
        }
    }
}

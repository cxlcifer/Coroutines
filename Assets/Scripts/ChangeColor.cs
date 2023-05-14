using System.Collections;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Spawn _spawn;
    [SerializeField] private float _time;
    void Awake()
    {
        _spawn = GetComponent<Spawn>();
    }

    public IEnumerator EditColor(Color newColor)
    {
        for (int i = 0; i < _spawn._cubes.Count; i++)
        {
            var color = _spawn._cubes[i].GetComponent<SpriteRenderer>().color;
            var currentTime = 0f;
            while (currentTime < _time)
            {
                var t = currentTime / _time;
                _spawn._cubes[i].GetComponent<SpriteRenderer>().color = Color.Lerp(color, newColor, t);
                currentTime += Time.deltaTime;
                yield return null;
            }

            currentTime = 0;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void GenerateColor()
    {
        var color = Random.ColorHSV();
        StartCoroutine(EditColor(color));
    }
}

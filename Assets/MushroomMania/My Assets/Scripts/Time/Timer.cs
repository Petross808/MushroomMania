using TypesAdvanced;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField, Min(1)] private int _time;
    [SerializeField] private IntVariable _timer;

    public void TickDown()
    {
        if(_timer.Value > 0)
            _timer.Value -= 1;
    }

    public void ResetTimer()
    {
        _timer.Value = _time;
    }
}

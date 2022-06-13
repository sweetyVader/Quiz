using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
        private Action _completeCallback;
        private bool _isStarted;
        private float _time;
       

        private void Update()
        {
                if (!_isStarted)
                        return;
                _time -= Time.deltaTime;
                
                if (_time<0)
                {
                        _isStarted = false;
                        _completeCallback?.Invoke();
                }
}

        public void StartTimer(float time, Action completeCallback)
        {
                _completeCallback = completeCallback;
                _isStarted = true;
                _time = time;
        }
}
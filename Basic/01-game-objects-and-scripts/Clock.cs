using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour {
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    [SerializeField]
    private bool IsDiscrete = true;

    const int h_degree = 360 / 12, m_degree = 360 / 60, s_degree = 360 / 60;

    private void SetRotation() {
        TimeSpan dt = DateTime.Now.TimeOfDay;
        float h = (float)dt.TotalHours;
        float m = (float)dt.TotalMinutes;
        float s = (float)dt.TotalSeconds;
        if (IsDiscrete) {
            s = Mathf.Round(s);
        }
        hoursPivot.localRotation = Quaternion.Euler(0, 0, -h_degree * h);
        minutesPivot.localRotation = Quaternion.Euler(0, 0, -m_degree * m);
        secondsPivot.localRotation = Quaternion.Euler(0, 0, -s_degree * s);
    }

    private void Awake() {
        SetRotation();
    }

    // Start is called before the first frame update
    void Start() {
        SetRotation();
    }

    // Update is called once per frame
    void Update() {
        SetRotation();
    }
}

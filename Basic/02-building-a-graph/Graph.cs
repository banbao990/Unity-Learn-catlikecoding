using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] transforms;

    private void Awake() {
        regenerate();
    }

    private void regenerate() {
        float time = Time.time;
        float step = 2F / resolution;
        Vector3 scale = Vector3.one * step;
        transforms = new Transform[resolution];
        for (int i = 0; i < resolution; ++i) {
            Transform p = Instantiate(pointPrefab);
            p.SetParent(transform, false);
            Vector3 pos = Vector3.zero;
            pos.x = (i + 0.5F) * step - 1F;
            pos.y = Mathf.Sin((pos.x + time) * Mathf.PI);
            p.localPosition = pos;
            p.localScale = scale;
            transforms[i] = p;
        }
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(resolution != transforms.Length) {
            removeClones();
            regenerate();
            return;
        }

        float time = Time.time;
        for (int i = 0; i < transforms.Length; ++i) {
            Transform p = transforms[i];
            Vector3 pos = p.localPosition;
            pos.y = Mathf.Sin((pos.x + time) * Mathf.PI);
            p.localPosition = pos;
        }
    }

    private void removeClones() {
        for (int i = 0; i < transforms.Length; ++i) {
            DestroyImmediate(transforms[i]);
        }
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers {

    public class AnimationHelper : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        void OnAnimationEnd() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
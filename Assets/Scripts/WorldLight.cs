
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

namespace WorldTime{
    [RequireComponent(typeof(Light2D))]

    
    public class WorldLight : MonoBehaviour
    {
        public float duration = 5f;

        [SerializeField] private Gradient gradient;
        public Light2D light2D;
        public float timeElapsed;


        private void Awake()
        {
            light2D = GetComponent<Light2D>();
            timeElapsed = Time.time;
        }    

        private void Update()
        {
            float t = Mathf.Sin(Time.time - timeElapsed) / (duration * Mathf.PI * 2) * 0.5f + 0.5f;
            float percent = Mathf.Clamp01(t);
            light2D.color = gradient.Evaluate(percent);
        }
        
    }

}
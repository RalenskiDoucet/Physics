using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Particales
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField]
        public ParticleData pd;

        // Use this for initialization
        void Start()
        {
            ScriptableObject.CreateInstance("ProjectileData");
        }

        public Vector3 ProjectileMove(Vector3 velocity, float angle, Vector3 initial_height)
        {
            pd.gravity = new Vector3(0, -9.81f, 0);
            pd.time = Time.deltaTime;
            pd.current_velocity.x = pd.starting_velocity.x * Mathf.Cos(angle);
            pd.current_velocity.y = pd.starting_velocity.y * Mathf.Sin(angle);

            //calulate the magnitude of the velocity
            float velocity_mag = (pd.current_velocity - pd.starting_velocity).magnitude;

            //calculate the speed
            pd.speed = velocity_mag / (2.0f * pd.gravity).magnitude;
            velocity_mag = 2.0f * pd.gravity.magnitude * pd.speed;

            //calculate the current position
            pd.current_position.x = pd.initial_position.x + (pd.starting_velocity.x * pd.time);
            pd.current_position.y = pd.initial_position.y + (pd.starting_velocity.y * pd.time) +
                                  (1 / 2 * (pd.gravity.magnitude * pd.time));

            return pd.current_position;
        }
    }

#if UNITY_EDITOR

    [CustomEditor(typeof(ProjectileBehaviour))]
    public class ProjectileMovementEditor : Editor
    {
        private ProjectileBehaviour pb;
        public ParticleData pd;

        private Vector3 initial_velocity;
        private float angle;
        private Vector3 initial_height;
        private Vector3 current_position;

        private void OnEnable()
        {
            CreateInstance("ProjectileData");
            pb = target as ProjectileBehaviour;
            initial_velocity = pd.starting_velocity;
            angle = pd.angle;
            initial_height = pd.starting_height;
            current_position = pd.current_position;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Calculate"))
            {
                pb.ProjectileMove(initial_velocity, angle, initial_height);
            }
            GUILayout.Box(" End Position " + current_position.ToString());

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginHorizontal();
            initial_velocity = EditorGUILayout.Vector3Field("initial velocity", initial_velocity);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            angle = EditorGUILayout.FloatField("angle", angle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            initial_height = EditorGUILayout.Vector3Field("initial height", initial_height);
            EditorGUILayout.EndHorizontal();

            if (EditorGUI.EndChangeCheck())
            {
                pd.starting_height = initial_height;
                pd.starting_velocity = initial_velocity;
                pd.angle = angle;
                pd.current_position = current_position;
            }
            
        }
    }
}
#endif
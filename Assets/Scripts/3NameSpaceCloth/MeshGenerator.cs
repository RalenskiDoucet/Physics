﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particales;

namespace ClothPhyics { 
    public class MeshGenerator : MonoBehaviour {

        public List<Vector3> Vertices = new List<Vector3>();
        public List<Particle> Particles = new List<Particle>();
        public List<SpringDampner> Springs = new List<SpringDampner>();
        public List<int> TrianglePoints = new List<int>();
        public  List<Vector3> SurfaceNormals = new List<Vector3>();
        public List<Vector2> UVs = new List<Vector2>();
        public MeshFilter InstanceMeshFilter;
        public Mesh InstanceMesh = new Mesh();


        void Awake()
        {
            InstanceMeshFilter.name = gameObject.name.ToString();
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Vertices.Add(new Vector3(x, y, 0));
                }
            }
            InstanceMesh.vertices = Vertices.ToArray();
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (i % 5 != 5 - 1 && i < Vertices.Count - 5)
                {
                    //Bot Triangle
                    TrianglePoints.Add(i); //bot left
                    TrianglePoints.Add(i + 1); //bot right
                    TrianglePoints.Add(i + 5); //top Left

                    //Top Trianlge
                    TrianglePoints.Add(i + 1); //bot right
                    TrianglePoints.Add(i + 5 + 1); //top right
                    TrianglePoints.Add(i + 5); //top left
                }
            }
            InstanceMesh.triangles = TrianglePoints.ToArray();
            foreach (var vert in Vertices)
            {
                SurfaceNormals.Add(new Vector3(0, 0, 1));
            }
            InstanceMesh.normals = SurfaceNormals.ToArray();
            foreach (var vert in Vertices)
            {

                UVs.Add(new Vector2(vert.x / (5 - 1), vert.y / (5 - 1)));
            }
            InstanceMesh.uv = UVs.ToArray();
            InstanceMeshFilter.mesh = InstanceMesh;
        }
        // Use this for initialization
        void Start() {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
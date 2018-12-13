using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particales;
 namespace ClothPhyics
{
    public class SliderBehavior : MonoBehaviour
{
    public MeshGenerator cg;
    public Slider gravitySlider;
    public Slider ksSlider;
    public Slider kdSlider;
    public Slider forceSlider;

    void Update()
    {
        foreach (var p in cg.Particles)
        {
            p..y = gravitySlider.value;
        }
        foreach (var s in cg.Springs)
        {
            s.restLength = ksSlider.value;
            s.unitLength = kdSlider.value;
        }
        foreach (var a in cg.TrianglePoints)
        {
            a.AeroForce.z = forceSlider.value;
        }
    }
}
}
using Alchemy.Inspector;
using LitMotion;
using UnityEngine;

public class A2B : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _target;
    
    [SerializeField] private Ease _ease;

    [Button]
    public void StartAnimation()
    {
        LMotion.Create(_start.position, _end.position, 0.4f)
            .WithEase(_ease)
            .Bind(targetPos =>
            {
                _target.position = targetPos;
            });
    }
}

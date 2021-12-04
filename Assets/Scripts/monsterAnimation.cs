using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WayPointMovement))]

public class monsterAnimation : MonoBehaviour
{
    private Animator _animator;
    private List<string> _animations = new List<string> { "isWalkUp", "isWalkDown", "isWalkLeft", "isWalkRight" };

    private string _currentAnimation;

    private WayPointMovement _wayPointMovement;

    void Start()
    {
        _wayPointMovement = GetComponent<WayPointMovement>();
        _animator = GetComponent<Animator>();
    }

    void GetAnimation(ref string animation)
    {
        Vector3 direction = _wayPointMovement.Direction;

        if (direction.x > 0)
        {
            animation = "WalkRight";
        }
        else if (direction.x < 0)
        {
            animation = "WalkLeft";
        }
        else if (direction.y > 0)
        {
            animation = "WalkUp";
        }
        else if (direction.y < 0)
        {
            animation = "WalkDown";
        }
    }

    void UpdateAnimator(string currentAnimation)
    {
        foreach (var animation in _animations)
        {
            if (animation != currentAnimation)
            {
                _animator.SetBool(animation, false);
            }
        }

        switch (currentAnimation)
        {
            case "WalkUp":
                _animator.SetBool("isWalkUp", true);
                break;
            case "WalkDown":
                _animator.SetBool("isWalkDown", true);
                break;
            case "WalkLeft":
                _animator.SetBool("isWalkLeft", true);
                break;
            case "WalkRight":
                _animator.SetBool("isWalkRight", true);
                break;
        }
    }

    void Update()
    {
        GetAnimation(ref _currentAnimation);
        UpdateAnimator(_currentAnimation);
    }
}

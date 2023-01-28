using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHuman
{
    void StartAnimation(string state);
    IMoveSystem MoveSystem { get; }
}

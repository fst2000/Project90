using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public interface IHumanState
{
    IHumanSize Size{get;}
    IHumanMotion Motion{get;}
    void OnEnter();
    void OnUpdate();
    void OnExit();
    IHumanState NextState();
}

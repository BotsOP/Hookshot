﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILootable
{
    void OnStartLook();
    void OnInteract();
    void OnEndLook();
}

using UnityEngine;
using UnityEngine.Events;

/// <summary>
///     An event representing a movement input in the direction of its parameter
/// </summary>
public class MoveEvent : UnityEvent<Vector2> { }

/// <summary>
///     An event representing an attack input with the given configuration
/// </summary>
public class LeftClickEvent : UnityEvent<bool> { }

/// <summary>
///     An event representing a dash input with the given configuration
/// </summary>
public class RightClickEvent : UnityEvent<bool> { }


/// <summary>
///     An event representing a pause input
/// </summary>
public class PauseEvent : UnityEvent<bool> { }
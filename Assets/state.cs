using System;
using Unity.Behavior;

[BlackboardEnum]
public enum state
{
    idle,
	chase,
	patrol
}

internal class BlackboardEnumAttribute : Attribute
{
}
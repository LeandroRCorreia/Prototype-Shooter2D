using UnityEngine;

public interface IMovable
{
    public void SetInput(Vector2 input);
    public Vector2 Direction {get;}
    
}

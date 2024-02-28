using UnityEngine;

public class CharacterFacing2D : MonoBehaviour
{

    public void UpdateFacing(float horizontal)
    {
            transform.rotation = horizontal < 0 
            ? Quaternion.Euler(0,180, 0) 
            : Quaternion.identity;


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessFields : MonoBehaviour
{

    Color m_MouseOverColor = Color.gray;

    //This stores the GameObject’s original color
    Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;


    // Start is called before the first frame update
    void Start()
    {     
            //Fetch the mesh renderer component from the GameObject
            m_Renderer = GetComponent<MeshRenderer>();
            //Fetch the original color of the GameObject
            m_OriginalColor = m_Renderer.material.color;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {    
            // Change the color of the GameObject to red when the mouse is over GameObject
            m_Renderer.material.color = m_MouseOverColor;
    }

    void OnMouseExit()
    {
        //Reset the color of the GameObject back to normal
            m_Renderer.material.color = m_OriginalColor;
            this.transform.position = new Vector3(0, 0, 0);
            System.Threading.Thread.Sleep(100);
    }
}

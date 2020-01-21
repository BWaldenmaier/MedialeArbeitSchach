using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurenMouseOver : MonoBehaviour
{
	
	//When the mouse hovers over the GameObject, it turns to this color (red)
    Color m_MouseOverColor = Color.gray;

    //This stores the GameObject’s original color
    Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;

    bool clicked = false;
	
    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseOver()
    {
        if (clicked == false){
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = m_MouseOverColor;
        //this.transform.position = new Vector3(0, 12, 0);
		//System.Threading.Thread.Sleep(150);
        }
    }

    void OnMouseExit()
    {
        //Reset the color of the GameObject back to normal
        if (clicked == false){
        m_Renderer.material.color = m_OriginalColor;
        this.transform.position = new Vector3(0, 0, 0);
		System.Threading.Thread.Sleep(100);      
        }    
    }

    void Update(){

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();      
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
 
             if (Physics.Raycast(ray, out hit))
             {
                 if (hit.transform.name == this.name)
                 {
                    Debug.Log(this.name);
                     Debug.Log("Click!!!");
                     this.transform.position = new Vector3(0, 12, 0);
                    clicked = true;
                 }
                 else if (hit.transform.name != this.name)
                 {
                     Debug.Log("Click outside this Object");
                     m_Renderer.material.color = m_OriginalColor;
                     this.transform.position = new Vector3(0, 0, 0);
                   clicked = false;
                 }
             }
             else
             {
                 Debug.Log("Click outside of any object");
                 m_Renderer.material.color = m_OriginalColor;
                 this.transform.position = new Vector3(0, 0, 0);
                clicked = false;
             }
        }
    }          
}
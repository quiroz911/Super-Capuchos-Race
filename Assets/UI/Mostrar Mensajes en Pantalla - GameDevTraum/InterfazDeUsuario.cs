using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfazDeUsuario : MonoBehaviour
{

    #region CAMPOS

    [Header("Mensaje Salteable (cualquier tecla)")]


    [SerializeField]
    private GameObject mensajeSalteableTeclaObjeto; //Contenedor
    [SerializeField]
    private Text mensajeSalteableTeclaTexto; //Objeto Texto
    private bool mensajeSalteableTeclaActivo; //Estado del mensaje


    #endregion

    #region MÉTODOS


    void Start()
    {
        mensajeSalteableTeclaObjeto.SetActive(false);
    }


    private void OnGUI()
    {
        if (mensajeSalteableTeclaActivo)
        {
            if (Input.anyKeyDown)
            {
                LimpiarMensajeTecla();
                SceneManager.LoadScene("SinglePlayerScene");
            }
        }

    }

    public void MostrarMensajeSalteableTecla(string mensaje)
    {
        mensajeSalteableTeclaActivo = true;
        mensajeSalteableTeclaTexto.text = mensaje;
        mensajeSalteableTeclaObjeto.SetActive(true);
    }

    private void LimpiarMensajeTecla()
    {
        mensajeSalteableTeclaActivo = false;
        mensajeSalteableTeclaObjeto.SetActive(false);
    }

    

    #endregion

}

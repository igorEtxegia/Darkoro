using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Variable que indica la posicion actual de cada ficha
    public Vector3 targetPosition;
    //Variable que indicara la posicion correcta de cada ficha
    private Vector3 correctPosition;
    //Variable de tipo SpriteRenderer que nos sera de utilidad para cuando queramos pintar una pieza que este en su posicion correcta del puzle.
    private SpriteRenderer _sprite;
    public int number;
    public bool inRightPlace;

    // Start is called before the first frame update
    void Awake()
    {
        //la posicion inicial de las fichas sera su propia posicion.
        targetPosition = transform.position;
        //establecemos la posicion correcta de cada ficha
        correctPosition = transform.position;
        // recogemos el componente SpriteRenderer
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Efecto que se le ponen a las fichas para cuando se muevan sobre el puzle con un retardo en movimiento de 0.5
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);

        //Comprobamos si la posicion actual de las piezas estan en el lugar correcto
        if(targetPosition == correctPosition)
        {
            //y si es asi, lo pintamos en verde
            _sprite.color = Color.green;
            inRightPlace = true;
        } else
        {
            // y sino lo pintamos en blanco que viene a ser no pintarlo de ningun color
            _sprite.color = Color.white;
            inRightPlace = false;
        }
    }
}

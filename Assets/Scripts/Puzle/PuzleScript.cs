using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzleScript : MonoBehaviour
{
    // declaracion de la variable tipo objeto que representa el espacio vacio del puzle.
    // Serialize field se usa para que sea de ambito privado pero podamos incluir el objeto en el inspector de Unity.
    [SerializeField] private Transform emptySpace = null;

    // declaracion de la variable camara que representa la camara principal del minijuego del puzle.
    [SerializeField] private Camera _camera;
    [SerializeField] private TileScript[] tiles;
    private int emptySpaceIndex = 8;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PararTodoAudio();
        AudioManager.instance.PlayAudio(AudioManager.instance.musicPuzzle);
        Shuffle(); // Metodo para barajear aleatoriamente las fichas del puzle.
    }

    // Update is called once per frame
    void Update()
    { 
        // Comprobamos si ha hecho click izquierdo en la camara del puzle
        if (Input.GetMouseButtonDown(0))
        {
            // Creamos un rayo con el nombre ray que recogera la posicion del raton en el momento que hemos hecho click, para identificar que ficha es la que debemos mover.
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            // Variable donde recogeremos el origen del rayo y hacia la direccion que ha de ir.
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //Comprobamos si la variable hit contiene algun movimiento
            if (hit)
            {
                // Comprobamos si la pieza a la que hemos hecho click izquierdo es adyacente a la posicion vacia del juego para saber si se puede mover la pieza
                // en este caso se usa el valor de 3.5 aunque dependiendo del diseño el número puede variar.
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 3.5 )
                {
                    // Guardamos en la nueva variable creada de tipo Vector2 la última posicion del espacio vacio del puzle
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    // Recogemos componente del TileScript
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    // El espacio vacio del puzle su nueva posicion sera donde hayamos clickado.
                    emptySpace.position = thisTile.targetPosition;
                    // ...y la nueva posicion de la ficha a la que se le ha hecho click izquierdo sera donde estuvo el hueco vacio del puzle.

                    // ---- Esto es para que se pueda visualizar en el editor de unity como vas cambiando las piezas y como cambian de orden, no afectan al juego ----//
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }

        // Variable que indica la cantidad de fichas correctas
        int correctTiles = 0;

        // Búcle que recorre constantemente las fichas del puzle y si estan en la posicion correcta suma al contador.
        foreach (var a in tiles)
        {
            // Comprobacion de que no devuelva ningun valor nulo
            if (a != null)
            {
                if (a.inRightPlace)
                {
                    correctTiles++;
                }
            } 
        }

        if (correctTiles == tiles.Length -1)
        {
            Debug.Log("Has ganado, hay cambio de escena.");

            //Obtenemos la escena actual
            Scene escenaActual = SceneManager.GetActiveScene();
            // Indicamos que cargue el siguiente nivel
            // En este caso es -1, ya que el puzle tiene un indice de 5 en el proyecto y el mapa 3 tiene el indice de 4.
            SceneManager.LoadScene(escenaActual.buildIndex - 1);
        }
    }

    // Metodo para barajeo aleatorio del puzle al empezar
    public void Shuffle()
    {
        int invertion;

        // Si en la ultima casilla no se encuentra el hueco vacio del puzle
        if (emptySpaceIndex != 8)
        {
            // Se lo asignaremos para que asi sea.
            var tileOn8LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn8LastPos;

            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;

            emptySpaceIndex = 8;
        }

        // Preparamos bucle do while para que desordene las piezas tantas veces como sea necesario hasta que el puzle sea solucionable.
        do
        {
            // Recorremos todas las piezas del tablero
            for (int i = 0; i < 8; i++)
            {
                // Guardamos en la variable la posicion de cada una de las piezas que hemos recorrido.
                var lastPos = tiles[i].targetPosition;
                // Creamos variable que contendra de una forma aleatoria diferentes indices
                int randomIndex = Random.Range(0, 7);

                // Le establecemos a cada ficha un indice aleatorio para que se desordenen.
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                // Establecemos que las ultima posicion de las piezas es la generada con indices aleatorios.
                tiles[randomIndex].targetPosition = lastPos;


                // ------ Estos cambios de a continuacion es para poder visualizarlo en unity y ver mejor los indices aleatorios ------- //
                // Recogemos la informacion de cada ficha recorrida.
                var tile = tiles[i];
                // Le asignamos un nuevo indice aleatorio a cada ficha
                tiles[i] = tiles[randomIndex];
                // Establecemos el nuevo orden en la variable creada previamente.
                tiles[randomIndex] = tile;
            }

            // Obtenemos el valor invertion
            invertion = GetInversions();
            // Mostramos por consola cuantas veces barajea cada vez que jugamos
            Debug.Log("Shuffle");

        } while (invertion % 2 != 0); // Hasta que el resto no de 0, seguira en el búcle.
        
    }

    public int findIndex(TileScript ts)
    {
        // Recorremos todas las fichas
        for (int i = 0; i < tiles.Length; i++)
        {
            // Comprobacion de si las fichas no vienen con valor nulo
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    // Devolvemos el indice.
                    return i;
                }
            }
        }
        // Si en alguna pieza no hemos devuelto su indice devolvera -1
        return -1;
    }

    // Comprobacion para que al barajear las piezas no lo haga de forma que el puzle no se pueda resolver.
    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }
}

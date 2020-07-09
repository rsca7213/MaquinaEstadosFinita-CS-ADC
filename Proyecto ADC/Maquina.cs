using Proyecto_ADC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_ADC
{

    /* 
     * Declaracion de la estructura para
     * cada objeto utilizado 
    */
    public struct objeto
    {
        public bool activo;
        public int x, y;
        public int estado;
    }

    /* 
     * Clase que contendrá la lógica de los estados
     * y los movimientos de los objetos utilizados 
    */
    public class Maquina
    {

        // Creación de los 8 objetos utilizados
        public objeto[] jugs = new objeto[8];

        /* 
         * Función que determina que sucedera
         * con los estatus de los objetos dependiendo
         * del estado actual del jugador
         * y asigna un nuevo estado a este
        */
        public void determinarEstado(int sigx, int sigy, int i)
        {
            if (jugs[0].estado == 0)
            {
                if (sigx == 800 && sigy == 400)
                {
                    jugs[0].estado = 4;
                    jugs[0].activo = false;
                }
                else if(jugs[i].activo == true) jugs[0].estado = 1;
            }
            else if (jugs[0].estado == 1)
            {
                if (sigx == 800 && sigy == 400)
                {
                    jugs[0].estado = 4;
                }
                else
                {
                    if (jugs[i].activo == true)
                    {
                        jugs[0].estado = 2;
                        jugs[i].activo = false;
                    }
                }
            }
            else
            {
                if (sigx == 800 && sigy == 400)
                {
                    jugs[0].estado = 3;
                    jugs[7].activo = false;
                }
                else jugs[0].estado = 0;
            }    
        }

        public void moverObjetos()
        {
            Random ver = new Random(Guid.NewGuid().GetHashCode());
            Random hor = new Random(Guid.NewGuid().GetHashCode());

            int mver = ver.Next(1, 3);

            if (mver == 2)
            {
                // movimiento vertical hacia abajo
                if (jugs[0].y == 200)
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        if (jugs[i].x == jugs[0].x && jugs[i].y == 400)
                        {
                            determinarEstado(jugs[i].x, jugs[i].y, i);
                            jugs[0].y = 400;
                            if(i != 7)
                                jugs[i].y = 200;
                            return;
                        }
                    }
                }
                // movimiento vertical hacia arriba
                else
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        if (jugs[i].x == jugs[0].x && jugs[i].y == 200)
                        {
                            determinarEstado(jugs[i].x, jugs[i].y, i);
                            jugs[0].y = 200;
                            if (i != 7)
                                jugs[i].y = 400;
                            return;
                        }
                    }
                }
            }
            else
            {
                int mhor = hor.Next(1, 3);
                // movimiento horizontal hacia la derecha
                if ((jugs[0].x == 200) || (jugs[0].x != 800 && mhor == 2))
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        if (jugs[0].y == jugs[i].y && jugs[0].x + 200 == jugs[i].x)
                        {
                            determinarEstado(jugs[i].x, jugs[i].y, i);
                            jugs[0].x += 200;
                            if (i != 7)
                                jugs[i].x -= 200;
                            return;
                        }
                    }
                }
                // movimiento horizontal hacia la izquierda
                else if ((jugs[0].x == 800) || (jugs[0].x != 200 && mhor == 1))
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        if (jugs[0].y == jugs[i].y && jugs[0].x - 200 == jugs[i].x)
                        {
                            determinarEstado(jugs[i].x, jugs[i].y, i);
                            jugs[0].x -= 200;
                            if (i != 7)
                                jugs[i].x += 200;
                            return;
                        }
                    }
                }

            }
        }


        /*
         * Constructor de la clase, realiza la asignacion
         * de atributos iniciales de los objetos
        */
        public Maquina()
        {
            int x = 200;
            int y = 200;

            for (int i = 0; i <= 7; i++)
            {
                jugs[i].x = x;
                jugs[i].y = y;
                jugs[i].estado = 0;
                jugs[i].activo = true;

                if (i == 3)
                {
                    x = 200;
                    y = 400;
                }
                else x += 200;
            }
        }

        /*
         * Punto de inicio de la aplicación,
         * se encarga de llamar a la creación de
         * la interfaz gráfica
        */
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_matemática
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Crea un objeto aleatorio llamado aleatorizador para generar números aleatorios.
        Random randomizer = new Random();

        // Estas variables enteras almacenan los números para el problema de suma.
        int addend1;
        int addend2;

        // Estas variables enteras almacenan los números para el problema de resta.
        int minuend;
        int subtrahend;

        // Estas variables enteras almacenan los números para el problema de multiplicación.
        int multiplicand;
        int multiplier;

        // Estas variables enteras almacenan los números para el problema de división.
        int dividend;
        int divisor;

        // Esta variable entera realiza un seguimiento de la tiempo restante.
        int timeLeft;





        /// <summary>
        /// Comience el cuestionario completando todos los problemas y poner en marcha el cronómetro.
        /// </summary>
        public void StartTheQuiz()
        {
            // Completa el problema de suma.Genera dos números aleatorios para sumar. Almacene los valores en las variables 'addend1' y 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convierte los dos números generados aleatoriamente en cadenas para que puedan mostrarse en los controles de etiqueta.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            // 'suma' es el nombre del control NumericUpDown.Este paso asegura que su valor sea cero antes añadiendo cualquier valor a la misma.
               sum.Value = 0;


            //Completa el problema de resta.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;
            // Completa el problema la multiplicacion.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;
            // Completa el problema la division.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Iniciar Contador
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        /// <summary>
        /// Verifique la respuesta para ver si el usuario hizo todo bien.
        /// </summary>
        /// <returns>Verdadero si la respuesta es correcta, falso en caso contrario.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // Si CheckTheAnswer() devuelve verdadero, entonces el usuario acerté la respuesta.Detenga el cronómetro y muestre un cuadro de mensaje.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Si CheckTheAnswer() devuelve falso, sigue contando abajo.Disminuya el tiempo restante en un segundo y mostrar el nuevo tiempo restante actualizando el Etiqueta de tiempo restante.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // Si al usuario se le acabó el tiempo, detiene el cronómetro, muestra un cuadro de mensaje y complete las respuestas.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;

                startButton.Enabled = true;
            }


        }

        private void anser_Enter(object sender, EventArgs e)
        {
            // Seleccione la respuesta completa en el control NumericUpDown.
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }

        }

        
    }
}

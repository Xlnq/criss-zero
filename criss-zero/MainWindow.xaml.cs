using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace criss_zero
{

    public partial class MainWindow : Window
    {
        string human = "X";
        string ai = "O";
        List<Button> buttons;
        Random rand = new Random();
        int xod = 0;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            reset();
        }
        private void reset()
        {
            button1.IsEnabled = true; button1.Content = "";
            button2.IsEnabled = true; button2.Content = "";
            button3.IsEnabled = true; button3.Content = "";
            button4.IsEnabled = true; button4.Content = "";
            button5.IsEnabled = true; button5.Content = "";
            button6.IsEnabled = true; button6.Content = "";
            button7.IsEnabled = true; button7.Content = "";
            button8.IsEnabled = true; button8.Content = "";
            button9.IsEnabled = true; button9.Content = "";
        }
        private void end()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            xod = 0;
            reset();
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            if (human == "X")
            {
                ai = "X";
                human = "O";
                AI();
            }
            else
            {
                ai = "O";
                human = "X";
            }
        }
        private void AI()
        {
            if (buttons.Count > 0)
            {
                int ind = rand.Next(buttons.Count);
                buttons[ind].Content = ai;
                buttons[ind].IsEnabled = false;
                buttons.RemoveAt(ind);
                Proverka();
                xod++;
            }
        }

        private void PlayerClickButton(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Content = human;
            button.IsEnabled = false;
            buttons.Remove(button);
            Proverka();
            AI();
            xod++;
        }
        private void Proverka()
        {
            if (button1.Content == "O" && button2.Content == "O" && button3.Content == "O"
            || button4.Content == "O" && button5.Content == "O" && button6.Content == "O"
            || button7.Content == "O" && button9.Content == "O" && button8.Content == "O"
            || button1.Content == "O" && button4.Content == "O" && button7.Content == "O"
            || button2.Content == "O" && button5.Content == "O" && button8.Content == "O"
            || button3.Content == "O" && button6.Content == "O" && button9.Content == "O"
            || button1.Content == "O" && button5.Content == "O" && button9.Content == "O"
            || button3.Content == "O" && button5.Content == "O" && button7.Content == "O")
            {
                end();
                if (human == "X")
                {
                    MessageBox.Show("Поражение");
                }
                else
                {
                    MessageBox.Show("Победа");
                }

            }
            else if (button1.Content == "X" && button2.Content == "X" && button3.Content == "X"
            || button4.Content == "X" && button5.Content == "X" && button6.Content == "X"
            || button7.Content == "X" && button9.Content == "X" && button8.Content == "X"
            || button1.Content == "X" && button4.Content == "X" && button7.Content == "X"
            || button2.Content == "X" && button5.Content == "X" && button8.Content == "X"
            || button3.Content == "X" && button6.Content == "X" && button9.Content == "X"
            || button1.Content == "X" && button5.Content == "X" && button9.Content == "X"
            || button3.Content == "X" && button5.Content == "X" && button7.Content == "X")
            {
                end();
                if (human == "O")
                {
                    MessageBox.Show("Поражение");
                }
                else
                {
                    MessageBox.Show("Победа");
                }
            }
            else if (xod >= 8)
            {
                end();
                MessageBox.Show("Ничья");
            }
        }
    }
}

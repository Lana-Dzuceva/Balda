using System;
using System.Drawing;
using System.Windows.Forms;

namespace Balda
{
    public partial class FormMain : Form
    {
        static int size = 10;
        int cellSize = 100;
        Label[][] field = new Label[size][];
        int ind = -1;
        Label[] massiveLetters = new Label[size];
        string letter = "";
        int x = -1, y = -1;
        string letters = "йцукенгшщзхфывапролджэячсмитьбю";
        
        public FormMain()
        {
            InitializeComponent();
            
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            if (e.Button == MouseButtons.Right || letter == "")
            {
                label.Text = "";
                return;
            }
            label.BackColor = Color.Bisque;
            label.Text = letter;
        }

        private void label_MouseDown_ChooseLetter(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.Yellow;
            if (ind != -1)
            {
                massiveLetters[ind].BackColor = Color.White;
            }
            ind = Array.IndexOf(massiveLetters, label);
            letter = label.Text;
        }

        private void flowLayoutPanelField_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            flowLayoutPanelField.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            for (int i = 0; i < size; i++)
            {
                field[i] = new Label[size];
                for (int r = 0; r < size; r++)
                {
                    Label label = new Label
                    {
                        Width = cellSize,
                        Height = cellSize,
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Microsoft Sans Serif", 20F)
                    };
                    label.MouseDown += new MouseEventHandler(label_MouseDown);
                    flowLayoutPanelField.Controls.Add(label);
                    field[i][r] = label;
                }
            }
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                Label label = new Label
                {
                    Width = 70,
                    Height = 70,
                    Text = letters[rnd.Next(letters.Length)].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 20F),
                    BorderStyle = BorderStyle.FixedSingle
                };
                label.MouseDown += new MouseEventHandler(label_MouseDown_ChooseLetter);
                flowLayoutPanel1.Controls.Add(label);
                massiveLetters[i] = label;
            }
        }
        }
}

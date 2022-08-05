using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racssoft_Dokan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                
            }

        }
        List<int> isComboAdded = new List<int>();
        Dictionary<int, Label> isAddedLabel = new Dictionary<int, Label>();
        Dictionary<int, TextBox> isAddedTextBox = new Dictionary<int, TextBox>();
        Dictionary<int, Button> isAddedButton = new Dictionary<int, Button>();
        static int count = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            addWallet(comboBox1.Items[comboBox1.SelectedIndex].ToString(), comboBox1.SelectedIndex);
        }
        void addWallet(string walletName, int i)
        {
            if (isComboAdded.Where(w => w == i).ToList().Count > 0) return;
            
            System.Windows.Forms.TextBox textBox = new TextBox();
            System.Windows.Forms.Label label = new Label();
            System.Windows.Forms.Button delete = new Button();

            label.AutoSize = true;
            //label.Location = new System.Drawing.Point(21, 30 + count * 22);
            label.Name = "label_" + i;
            label.Size = new System.Drawing.Size(35, 20);
            label.TabIndex = 0;
            label.Text = walletName;

            //textBox.Location = new System.Drawing.Point(96, 30 + count * 20);
            textBox.Name = "textBox_" + i;
            textBox.Size = new System.Drawing.Size(100, 20);

            //delete.Location = new System.Drawing.Point(226, 30 + count * 20);
            delete.Name = "Delete_" + i;
            delete.Size = new System.Drawing.Size(17, 20);
            delete.TabIndex = 2;
            delete.Text = "x";
            delete.ForeColor = Color.Red;
            delete.TextAlign = ContentAlignment.MiddleCenter;
            delete.BackColor = System.Drawing.SystemColors.Control;
            delete.FlatStyle = FlatStyle.Flat;
            delete.FlatAppearance.BorderSize = 0;
            delete.Cursor = System.Windows.Forms.Cursors.Hand;

            isComboAdded.Add(i);
            isAddedTextBox.Add(i, textBox);
            isAddedLabel.Add(i, label);
            isAddedButton.Add(i, delete);
            setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
            this.panel1.Controls.Add(textBox);
            this.panel1.Controls.Add(label);
            this.panel1.Controls.Add(delete);
            delete.Click += new System.EventHandler(this.button1_Click_1);


            
            count++;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m = "this.textBox" + "2";
            //this.panel1.Controls.Remove(Convert.m);
            //this.panel1.Controls.Remove(this.label2);

            string[] s = "s_1".Split('_');

            int i = Convert.ToInt32(s[1]);
            isComboAdded.Remove(i);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string[] s = button.Name.Split('_');

            int i = Convert.ToInt32(s[1]);
            isComboAdded.Remove(i);
            this.panel1.Controls.Remove((Button)sender);
            isAddedButton.Remove(i);
            this.panel1.Controls.Remove(isAddedLabel[i]);
            isAddedLabel.Remove(i);
            this.panel1.Controls.Remove(isAddedTextBox[i]);
            isAddedTextBox.Remove(i);
            setLocation(isAddedLabel, isAddedTextBox, isAddedButton);
            //this.panel1.Controls.Remove(isAddedTextBox[i]);
            //if (isAddedLabel.Where(w => w.Name == "label_" + i).ToList().Count > 0) this.panel1.Controls.Remove(w);

            //this.panel1.Where(w => w.name == "textBox_" + i).Remove(w);
            //isAddedTextBox.Remove(isAddedTextBox[i]);
            //this.panel1.Controls.Remove(isAddedLabel[i]);
            //isAddedLabel.Remove(isAddedLabel[i]);
            // this.panel1.Controls.Remove("this.textBox + s[1]");




        }

        void setLocation(Dictionary<int, Label> labels, Dictionary <int, TextBox> textBoxes, Dictionary<int, Button> buttons)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels.ElementAt(i).Value.Location = new System.Drawing.Point(15, 10 + i * 22);
                textBoxes.ElementAt(i).Value.Location = new System.Drawing.Point(90, 10 + i * 22); 
                buttons.ElementAt(i).Value.Location = new System.Drawing.Point(200, 10 + i * 22);
            }
        }
    }
}

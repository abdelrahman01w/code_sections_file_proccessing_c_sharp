using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace code_sections_six_file_proccessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        FileStream myFile;
        StreamReader sr;
        StreamWriter sw;
        string fileName;

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            DialogResult res = fd.ShowDialog();
            if (res == DialogResult.Cancel)
                return;

            fileName = fd.FileName;
            myFile = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            sw = new StreamWriter(myFile);
            sr = new StreamReader(myFile);
            MessageBox.Show("File is opened");
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sw.Close();
            sr.Close();
            myFile.Close();
            MessageBox.Show("File Closed");
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button10.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myFile.Seek(0, SeekOrigin.End);
            MessageBox.Show("Enf of the file");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myFile.Seek(0, SeekOrigin.Begin);
            MessageBox.Show("Begin of the file");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            myFile.Seek(0, SeekOrigin.End);
            string record = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," +
            textBox4.Text;
            sw.WriteLine(record);
            sw.Flush();
            MessageBox.Show("Record saved");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string record = sr.ReadLine();
            string[] field;
            if (record != null)
            {
                field = record.Split(',');
                textBox1.Text = field[0];
                textBox2.Text = field[1];
                textBox3.Text = field[2];
                textBox4.Text = field[3];
            }
            else
            {
                MessageBox.Show("No more record");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int searchAccountId = int.Parse(textBox1.Text);
            String line;
            String[] field;
            while ((line = sr.ReadLine()) != null)
            {
                field = line.Split(',');

                if (int.Parse(field[0]) == searchAccountId)
                {
                    textBox2.Text = field[1];
                    textBox3.Text = field[2];
                    textBox4.Text = field[3];
                    MessageBox.Show("Account found");
                    return;
                }
            }
            MessageBox.Show("Account not found");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            myFile.Seek(0, SeekOrigin.Begin);
            myFile.Flush();
            sw.Flush();
            string line;
            string[] field;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                field = line.Split(',');
                if (field[0] == textBox1.Text)
                {
                    myFile.Seek(count, SeekOrigin.Begin);
                    sw.Write("*");
                    sw.Flush();
                    myFile.Flush();
                }
                count += line.Length + 2;
            }
            MessageBox.Show("deleted successfuly");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string line;
            myFile.Seek(0, SeekOrigin.Begin);
            FileStream SQfile = new FileStream("Squeeze.txt", FileMode.Create, FileAccess.Write);
            StreamWriter SQwriter = new StreamWriter(SQfile);
            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] != '*')
                {
                    SQwriter.WriteLine(line);
                    SQwriter.Flush();
                }
            }
            SQwriter.Close();
            SQfile.Close();
            MessageBox.Show("Squeeze operation completed successfully!");
        }
    }
}
        

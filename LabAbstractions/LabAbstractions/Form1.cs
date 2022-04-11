using System.Text;

namespace LabAbstractions
{
    public partial class Form1 : Form
    {
        private double sum1 = 0;
        private double sum2 = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String[] readAllline = File.ReadAllLines(openFileDialog.FileName);

                String readAllText = File.ReadAllText(openFileDialog.FileName);
                for (int i = 0; i < readAllline.Length; i++)
                {
                    string allDATARAW = readAllline[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView2.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[2], allDATASplited[3]);

                }

            }


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = " CSV(*.csv) |*.csv";
                bool FileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!FileError)
                    {
                        try
                        {
                            int columcount = dataGridView2.Columns.Count;
                            string column = "";
                            string[] outputCSV = new string[dataGridView2.Rows.Count + 1];
                            for(int i = 0;i < outputCSV.Length; i++)
                            {
                                column += dataGridView2.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += column;
                            for (int i = 1; (i - 1) < dataGridView2.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                                {
                                    outputCSV[i] += dataGridView2.Rows[i-1].Cells[i].Value.ToString() + ",";
                                }

                            }
                            File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                        }   
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :"+ ex.Message);
                        }

                        

                        
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowTndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowTndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sum1 += sum2;

            string User_or_ID = textBox1.Text;
            string Password = textBox2.Text;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Staff";
            dataGridView1.Rows[n].Cells[1].Value = sum1;
            dataGridView1.Rows[n].Cells[2].Value = User_or_ID;
            dataGridView1.Rows[n].Cells[3].Value = Password;

            textBox1.Text = "";
            textBox2.Text = "";
 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Major = comboBox1.Text;
            string SSID = textBox3.Text;
            string Name = textBox4.Text;
            string Password = textBox5.Text;
            string Staff = "NO";

            int n = dataGridView2.Rows.Add();

            if (Major == "Staff")
            {
                Staff staff = new Staff();

                staff.Name = Name;
                staff.SSID = SSID;
                staff.Password = Password;
                
                dataGridView2.Rows[n].Cells[2].Value = staff.Name;
                dataGridView2.Rows[n].Cells[1].Value = staff.SSID;
                dataGridView2.Rows[n].Cells[3].Value = staff.Password;
                dataGridView2.Rows[n].Cells[0].Value = staff;
 
            }
            if (Major == "Teacher")
            {
                Teacher teacher = new Teacher();

                teacher.Major = Major;
                teacher.Name = Name;
                teacher.SSID = SSID;

                dataGridView2.Rows[n].Cells[0].Value = teacher.Major;
                dataGridView2.Rows[n].Cells[2].Value = teacher.Name;
                dataGridView2.Rows[n].Cells[1].Value = teacher.SSID;
            }
            if (Major == "Student")
            {
                Student student = new Student();

                student.Major = Major;
                student.Name = Name;
                student.SSID = SSID;

                dataGridView2.Rows[n].Cells[0].Value = student.Major;
                dataGridView2.Rows[n].Cells[2].Value = student.Name;
                dataGridView2.Rows[n].Cells[1].Value = student.SSID;

            }
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
using System;
using System.IO;
using System.Windows.Forms;

namespace FileOrganizerConfigurationManager
{
    public partial class Form1 : Form
    {
        private const string configFileName = @"C:\tester\foconfig.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as CheckBox).Checked)
            {
                button1.Enabled = textBox1.Enabled = true;
            }
            else
            {
                button1.Enabled = textBox1.Enabled = !true;
                textBox1.Text = String.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Interval Type";
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
                radioButton2.Checked = !radioButton1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeConfigToFile();
        }

        private void writeConfigToFile()
        {
            string[] config =  new string[3];
            config[0] = GenerateWorkingPath();
            config[1] = GenerateInterval();
            config[2] = GenerateActivation();
            
            File.WriteAllLines(configFileName, config);
            

        }

        private string GenerateInterval()
        {
            return $"Interval:{numericUpDown1.Value}-{comboBox1.SelectedItem}";
        }

        private string GenerateActivation()
        {
            return radioButton1.Checked ? $"Activate:True" : $"Activate:False";
        }

        private string GenerateWorkingPath()
        {
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            if (!checkBox1.Checked)
            {
                if (Directory.Exists(textBox1.Text))
                {
                    return textBox1.Text;
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show($"Directory {textBox1.Text} does not exist. Press Yes to create or No to use defult directory", "Problem", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        Directory.CreateDirectory(textBox1.Text);
                        return textBox1.Text;
                    }
                    else
                    {
                        return pathDownload;
                    }
                }
            }
            else
            {
                return pathDownload;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton4.Checked = !radioButton3.Checked;
            changeEnableForServiceComponents(radioButton3.Checked);
            changeEnableForManualComponents(!radioButton3.Checked);
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = !radioButton4.Checked;
            changeEnableForServiceComponents(!radioButton4.Checked);
            changeEnableForManualComponents(radioButton4.Checked);
        }

        private void changeEnableForServiceComponents(bool i_Enable)
        {
           
        }

        private void changeEnableForManualComponents(bool i_Enable)
        {
                       
        }
    }
}

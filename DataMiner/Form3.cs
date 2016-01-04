using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiner
{
    public partial class Form3 : Form
    {
        public BayesianCorrelation<List<DisplayData>, DisplayData> bc;
        public BayesianCorrelation<List<DisplayData>, DisplayData> filtered_bc;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem as string) != "" && (comboBox2.SelectedItem as string) != "")
            {
                var factor = (chkFilter.Checked?filtered_bc.Correlations:bc.Correlations)[(comboBox1.SelectedItem as string)]
                    [(comboBox2.SelectedItem as string)];
                var negfactor = (chkFilter.Checked ? filtered_bc.NegCorrelations : bc.NegCorrelations)[(comboBox1.SelectedItem as string)]
                    [(comboBox2.SelectedItem as string)];
                if (!double.IsNaN(factor))
                {
                    if (!double.IsNaN(negfactor))
                    {
                        labelCorr.Text = string.Format("For field {0}, field {1} is a {2:0.##}% predictor.  Not having field {1} is a {3:0.##}% predictor.",
                            (comboBox1.SelectedItem as string), (comboBox2.SelectedItem as string), factor * 100, negfactor * 100);
                    }
                    else
                    {
                        labelCorr.Text = string.Format("For field {0}, field {1} is a {2:0.##}% predictor. Insufficient data to evaluate not having field {1}.",
                           (comboBox1.SelectedItem as string), (comboBox2.SelectedItem as string), factor * 100);
                    }
                }
                else
                {
                    labelCorr.Text = string.Format("For field {0}, field {1} is an unknown predictor (not enough data).",
                       (comboBox1.SelectedItem as string), (comboBox2.SelectedItem as string));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {


            comboBox1.DataSource = bc.Correlations.Keys.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem as string) != "")
            {
               
                comboBox2.DataSource = (chkFilter.Checked? filtered_bc.Correlations:bc.Correlations)[(comboBox1.SelectedItem as string)].Keys.ToList();
                listBox1.Items.Clear();
                var k = (chkFilter.Checked ? filtered_bc.Correlations : bc.Correlations)[comboBox1.SelectedItem as string];
                var nk = (chkFilter.Checked ? filtered_bc.NegCorrelations : bc.NegCorrelations)[comboBox1.SelectedItem as string];
                var list = k.Where(s => !double.IsNaN(s.Value))
                    .OrderBy(s => s.Value * -1)
                    .Select(s => s.Key + " - " + (s.Value * 100).ToString("0.##") + "% "+
                    (double.IsNaN(nk[s.Key])?"(insufficient data for negative case)":("(neg: "+(nk[s.Key]*100).ToString("0.##")+"%)") ))
                    .Take(10).ToList();

                foreach (var s in list)
                {
                    listBox1.Items.Add(s);
                }
            }
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}

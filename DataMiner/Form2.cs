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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public List<Filter> filters = new List<Filter>();
        private void button1_Click(object sender, EventArgs e)
        {
            Filter f = new Filter();
           

            f.FieldName = CurrentProperty;
            f.ReflectionName = CoreProperty;
            //add the current filter
            if (CurrentType == typeof(bool))
            {
                var val = rdBool1.Checked && !rdBool2.Checked;
                f.Description = string.Format("{0} is {1}", CurrentProperty, val.ToString());
                f.Apply = o =>
               {
                   return ((bool)o) == val;
               };
                hidePanels();
            }
            else if (CurrentType == typeof(string))
            {

                var val = textBoxString.Text;
                //string matching
                f.Description = string.Format("{0} contains \"{1}\"",CurrentProperty,val);
                f.Apply = o => ((string)o).ToUpper().Contains(val.ToUpper());
                hidePanels();
               
            }
            else if (CurrentType == typeof(DateTime) || CurrentType == typeof(Nullable<DateTime>))
            {
                var val1 = dateTimePicker1.Value;
                var val2 = dateTimePicker2.Value;
                //date range
                f.Description = string.Format("{0} between {1:M/d/yyyy} and {2:M/d/yyyy}", CurrentProperty, val1, val2);
                f.Apply = o => val1 <= ((DateTime)o) && val2 >= ((DateTime)o);
                
            }
            else if (CurrentType == typeof(double))
            {
                //numeric

                double val1;
                if (!double.TryParse(textBoxNumber1.Text,out val1)) {
                    val1 = double.MinValue;
                };
                double val2;
                if (!double.TryParse(textBoxNumber2.Text, out val2))
                {
                    val2 = double.MaxValue;
                };
                //number range
                f.Description = string.Format("{0} between {1:0.##} and {2:0.##}", CurrentProperty, val1, val2);
                f.Apply = o => val1 <= ((double)o) && val2 >= ((double)o);

            }
            else if (CurrentType == typeof(int))
            {
                int val1;
                if (!int.TryParse(textBoxNumber1.Text, out val1))
                {
                    val1 = int.MinValue;
                };
                int val2;
                if (!int.TryParse(textBoxNumber2.Text, out val2))
                {
                    val2 = int.MaxValue;
                };
                //number range
                f.Description = string.Format("{0} between {1:0.##} and {2:0.##}", CurrentProperty, val1, val2);
                f.Apply = o => val1 <= ((int)o) && val2 >= ((int)o);
            }
            filters.Add(f);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new BindingList<Filter>(filters);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var props = ((Type)listBox1.SelectedValue).GetProperties();
            listBox2.DisplayMember = "Name";
            listBox2.ValueMember = "Value";
            listBox2.DataSource = props.Select(v => {

                var t = typeof(DisplayData).GetProperty(v.Name);

                var name = (t.GetCustomAttributes(typeof(DisplayNameAttribute), false)).Length == 0 ?
                    t.Name :
                    ((DisplayNameAttribute)t.GetCustomAttributes(typeof(DisplayNameAttribute), false).SingleOrDefault()).DisplayName;

                return new
                {
                    CoreName = t.Name,
                    Name =name,
                    Value = t.PropertyType
                };
            }).ToList();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //populate filter boxes
            var props=typeof(ParsedData).GetProperties();
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Value";
            listBox1.DataSource = props.Select(t=> {
                return new
                {
                    Name = ((DisplayNameAttribute)t.GetCustomAttributes(typeof(DisplayNameAttribute), false).SingleOrDefault()).DisplayName,
                    Value = t.PropertyType
                };
            }).ToList();
            hidePanels();
            dataGridView1.DataSource = new BindingList<Filter>(filters);
            

        }
        public void hidePanels()
        {
            panelBool.Hide();
            panelString.Hide();
            panelDate.Hide();
            panelNumber.Hide();
        }
        public string CurrentProperty = "";
        public Type CurrentType = null;
        public string CoreProperty = "";
        private void button3_Click(object sender, EventArgs e)
        {
            hidePanels();
            //create filter buttons
            //look at type of selected
            Type type = (Type)listBox2.SelectedValue;
            string name = listBox2.SelectedItem.GetType().GetProperty("Name").GetValue(listBox2.SelectedItem).ToString();
            label5.Text = string.Format("Filter for {0}",name);
            CurrentProperty = name;
            CurrentType = type;
            CoreProperty = listBox2.SelectedItem.GetType().GetProperty("CoreName").GetValue(listBox2.SelectedItem).ToString();
            if (type == typeof(bool))
            {
                //yes/no filter
                panelBool.Show();
                lblBool.Text = name;

            }
            else if (type == typeof(string)) { 

                panelString.Show();
                //string matching
                labelString.Text = string.Format("{0} contains: ", name);
            }
            else if (type == typeof(DateTime)||type == typeof(Nullable<DateTime>))
            {
                //date range
                panelDate.Show();
                labelDate.Text = string.Format("{0} between: ", name);
               
            }
            else if (type == typeof(double))
            {
                //nume
                panelNumber.Show();
                labelNumber.Text = string.Format("{0} between: ", name);
            }
            else if(type == typeof(int))
            {
                //numeric
                panelNumber.Show();
                labelNumber.Text = string.Format("{0} between: ", name);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            
            }
          
        }
    }
}

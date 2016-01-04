using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Xps.Packaging;
using Microsoft.VisualBasic.FileIO;

namespace DataMiner
{
    public partial class Form1 : Form
    {
        public string dir;
        public List<Filter> filters= new List<Filter>();
        public Form1()
        {
            InitializeComponent();
            toolStripProgressBar1.Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // var fbd = new FolderBrowserDialog();
            //  if(fbd.ShowDialog() == DialogResult.OK)
            if (true)
            {
                //      textBox1.Text=fbd.SelectedPath;
                //    var files = Directory.GetFiles(textBox1.Text, "*.xps");
                //  progressBar1.Maximum = files.Length;
                //  progressBar1.Value = 0;
                //  label2.Text = "";
                //  label2.Show();
                //  progressBar1.Show();

                bs = new SortableBindingList<DisplayData>();
                //foreach (var f in files)
                //{

                //    label2.Text = "Processsing File: " + f;
                //    progressBar1.Value++;
                //    Update();
                //    System.Threading.Thread.Sleep(500);
                //    var p = parseData(f);
                //    if (p != default(ParsedData)){
                //        bs.Add(parseData(f));
                //    }

                //}
                // progressBar1.Hide();
                //label2.Text = string.Format("Loaded {0} files.", files.Length);


                dataGridView1.DataSource = bs;
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AllowUserToOrderColumns = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.Dock = DockStyle.Fill;
                for (int x = 0; x < dataGridView1.Columns.Count; x++)
                {
                    dataGridView1.Columns[x].Resizable = DataGridViewTriState.True;
                    dataGridView1.Columns[x].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;


                }

            }




        }
        public SortableBindingList<DisplayData> bs;


        public ParsedData parseData(string filename)
        {
            /*
                NAME (last, first)	CHAR	DOE, JOHN
                DOB	NUM	MM/DD/YYYY
                MRN	CHAR	NNNNNNN
                StudyID	NUM	AlphaNumeric
                SEX	CHAR	M/F
                RACE	CHAR	WHITE, BLACK, ASIAN, NATIVE AMERICAN, PACIFIC ISLANDER, BIRACIAL, etc
                ETHNICITY	CHAR	HISPANIC, NOT HISPANIC, MIDDLE EASTERN
                ADMISSION DATE	NUM	MM/DD/YYYY
                DISCHARGE DATE	NUM	MM/DD/YYYY
                HOSPITAL LOCATION	NUM	SR AFLAC IP, EG 3-E (AFLAC), EG AFLAC BMT, SR PEDIATRIC ICU, EG PEDIATRIC ICU
                PRIMARY ONC DIAGNOSIS 	CHAR	SPECIFIC DISEASE
                DATE OF PRIMARY ONC DIAGNOSIS	NUM	MM/DD/YYYY
                SECONDARY ONC DIAGNOSIS	CHAR	SPECIFIC DISEASE
                DATE OF SECONDARY ONC DIAGNOSIS	NUM	MM/DD/YYYY
                RELAPSE	CHAR	Y/N
                DATE OF RELAPSE	NUM	MM/DD/YYYY
                BMT	CHAR	Y/N
                BMT DATE	NUM	MM/DD/YYYY
                BMT TYPE	CHAR	ALLO/AUTO
                LINE INSERTION DATE	NUM	MM/DD/YYYY
                LINE REMOVAL DATE	NUM	MM/DD/YYYY
                LINE TYPE	CHAR	DLCVL, PORT, DLPORT, PICC
                HAS SECONDARY LINE	CHAR	Y/N
                SECONDARY LINE TYPE	CHAR	DLCVL, PORT, DLPORT, PICC
                BLOOD CULTURE ORDERED	CHAR	Y/N
                POSITIVE BLOOD CULTURE	CHAR	Y/N
                ORGANISM PRESENT IN BLOOD CULTURE	CHAR	GENUS SPECIES
                DATE OF POS BLOOD CULTURE	NUM	MM/DD/YYYY
                CLABSI	CHAR	Y/N
                TOTAL NUMBER CLABSI DURING TIME INTERVAL	NUM	0-N
                WBC COUNT AT POS BCX DX	NUM	0-NNN,NNN
                ANC AT POS BCX DX	NUM	0-NNN,NNN
                LINE ENTRIES IN INTERVAL	NUM	0-N
                LINE ENTRIES LAST 24 HRS	NUM	0-N 
                NUMBER MOUTH CARE IN INTERVAL	NUM	0-N
                NUMBER MOUTH CARE 72 HRS	NUM	0-N
                MOUTHCARE TYPE	CHAR	BRUSH, RINSE
                RINSE AGENT	CHAR	BIOTENE, PERIDEX
                NUMBER CHG BATHS IN INTERVAL	NUM	0-N
                CHG BATHS 72 HRS BEFORE POSITIVE BCX	NUM	0-N
                PREOP CHG BATH	CHAR	Y/N
                ROUTINE BATH	CHAR	Y/N
                OTHER EXTERNAL LINE/DRAIN PRESENT	CHAR	GT, GJT, CT, JPDRAIN, WOUNDVAC, FOLEY, NEPHROSTOMY, TRACH
                LAST DRESSING CHANGE DATE	NUM	MM/DD/YYYY
                DATES OF DRESSING CHANGES	NUM	MM/DD/YYYY
                FREQUENCY DRESSING CHANGE (DAYS)	NUM	0-NN
                TOTAL DRESSING CHANGES IN INTERVAL	NUM	0-N
                LAST TUBING CHANGE DATE	NUM	MM/DD/YYYY
                FREQUENCY TUBING CHANGE (DAYS)	NUM	0-NN
                LAST CAP CHANGE DATE	NUM	MM/DD/YYYY
                FREQUENCY CAP CHANGE (DAYS)	NUM	0-NN
                TOTAL CAP CHANGES	NUM	0-N
                HIGH TOUCH SURFACE CLEAN PROTOCOL	CHAR	Y/N
                DAILY LINEN CHANGE	CHAR	Y/N
            */

            XpsDocument _xpsDocument = new XpsDocument(filename, System.IO.FileAccess.Read);
            IXpsFixedDocumentSequenceReader fixedDocSeqReader
                = _xpsDocument.FixedDocumentSequenceReader;
            IXpsFixedDocumentReader _document = fixedDocSeqReader.FixedDocuments[0];
            IXpsFixedPageReader _page
                = _document.FixedPages[0];
            StringBuilder _currentText = new StringBuilder();
            System.Xml.XmlReader _pageContentReader = _page.XmlReader;
            if (_pageContentReader != null)
            {
                while (_pageContentReader.Read())
                {
                    if (_pageContentReader.Name == "Glyphs")
                    {
                        if (_pageContentReader.HasAttributes)
                        {
                            if (_pageContentReader.GetAttribute("UnicodeString") != null)
                            {
                                _currentText.Append(" ");
                                _currentText.
                                  Append(_pageContentReader.
                                  GetAttribute("UnicodeString"));
                            }
                        }
                    }
                }
            }
            string _fullPageText = _currentText.ToString();
            // MessageBox.Show(_fullPageText);
            // return new ParsedData() { Name = filename };
            return fakeparse(filename);

        }

        public IEnumerable<ParsedData> generateData(int count)
        {
            List<ParsedData> data = new List<ParsedData>();


            for (int x = 0; x < count; x++)
            {

                ParsedData pd = new ParsedData();
                pd.demographic = generateDemographics();
                pd.hospital = generateHospital();
                pd.disease = generateDisease();
                pd.device = generateDevice();
                pd.care = generateCare();
                pd.lab = generateLab();

                pd.exam = new PhysicalExam();
                pd.meds = new Medications();
                pd.proc = new Procedures();

                if (pd.disease.DateOfPrimaryONCDiagnosis < pd.hospital.AdmissionDate)
                    pd.disease.DateOfPrimaryONCDiagnosis = pd.hospital.AdmissionDate;

                if (pd.disease.PrimaryONCDiagnosis == "Acute Myeloid Leukemia")
                {
                    pd.hospital.PICUTransfer = pd.hospital.PICUTransfer||(r.NextDouble() < 0.13);
                    if(pd.hospital.PICUTransfer)
                    {
                        pd.hospital.DateOfPICUTransfer = pd.hospital.AdmissionDate.Value.AddDays(r.Next() % 5);
                    }
                }
                //transfer probabilities
                if (pd.hospital.PICUTransfer)

                {
                    pd.exam.Fever = r.NextDouble() < 0.9;
                    pd.exam.OxygenRequired = r.NextDouble() < 0.9;
                    pd.exam.AlteredMentalState = r.NextDouble() < 0.1;
                    pd.meds.TransfusionInLast24H = r.NextDouble() < 0.5;
                    pd.lab.BloodCultureOrdered = true;
                    pd.lab.PositiveBloodCulture = r.NextDouble() < 0.85;
                    if (pd.lab.PositiveBloodCulture)
                    {
                        pd.lab.DateOfPositiveBloodCulture = pd.hospital.DateOfPICUTransfer;
                        pd.lab.ANCPositiveBloodCulture = 210 - Math.Round( r.NextDouble() * 80);
                    }

                    pd.disease.Relapse = r.NextDouble() < 0.4;
                    pd.proc.SurgeryInLast24H = r.NextDouble() < 0.25;
                }
                else //normal population
                {
                    pd.exam.Fever = r.NextDouble() < 0.5;
                    pd.exam.OxygenRequired = r.NextDouble() < 0.1;
                    pd.exam.AlteredMentalState = r.NextDouble() < 0.05;
                    pd.meds.TransfusionInLast24H = r.NextDouble() < 0.8;
                    pd.lab.BloodCultureOrdered = r.NextDouble() <0.8;
                    if (pd.lab.BloodCultureOrdered)
                    {
                        pd.lab.PositiveBloodCulture = r.NextDouble() < 0.07;
                        if (pd.lab.PositiveBloodCulture)
                        {
                            pd.lab.DateOfPositiveBloodCulture = pd.hospital.DateOfPICUTransfer.HasValue? pd.hospital.DateOfPICUTransfer.Value:
                                pd.hospital.AdmissionDate.Value.AddDays(r.Next()%7);
                            pd.lab.ANCPositiveBloodCulture = 230 - Math.Round(r.NextDouble() * 50);
                        }
                    }
                    pd.disease.Relapse = r.NextDouble() < 0.2;
                    pd.proc.SurgeryInLast24H = r.NextDouble() < 0.05;
                }
                /*
                 Diagnosis(AML most likely) - 40, 90
                 Fever(yes) - 50, 90 
                 Oxygen requirement(yes) - 10, 90
                 Altered Mental Status(yes) - 5, 10
                 Received Transfusion within 24 hours - 80, 50 
                 Blood Culture Positive(yes) - 7, 85
                 Relapse(yes) - 20, 40
                 ANC(absolute neutrophil  count) < 200 (yes) - 40, 80
                 Surgery within last 24 hours(yes) - 5, 25
             */


                data.Add(pd);
            }


            return data;
        }

        public LabData generateLab()
        {
            return new LabData();
            throw new NotImplementedException();
        }

        public CareDeliveryData generateCare()
        {
            return new CareDeliveryData();
            throw new NotImplementedException();
        }

        public DeviceData generateDevice()
        {
            return new DeviceData();
            throw new NotImplementedException();
        }

        public DiseaseData generateDisease()
        {
            /*
            Sickle Cell - HbSS - 30
            Sickle Cell - HbSC - 15
            Sickle Cell - HbS beta plus thalassemia
            Sickle Cell - HbS beta zero thalassemia
            Severe Aplastic Anemia - 3
            ITP 


            Neuroblastoma, Stage IV - 10
            B-Lymphoblastic Leukemia - 3
            T-Lymphoblastic Leukemia - 3
            Acute Myeloid Leukemia - 20
            */

            string[] diseases = {
                 "Sickle Cell - HbSS", // - 30
                  "Acute Myeloid Leukemia",// - 20
            "Sickle Cell - HbSC", //- 15
            "Neuroblastoma, Stage IV",//- 10
             "B-Lymphoblastic Leukemia",// - 3
            "T-Lymphoblastic Leukemia",// - 3
            "Severe Aplastic Anemia",// - 3
            "ITP",//
              "Sickle Cell - HbS beta plus thalassemia",//
            "Sickle Cell - HbS beta zero thalassemia",//
            };
            var rand = r.Next();
            DiseaseData d = new DiseaseData();
            d.BMT = false;
            d.Relapse = false;
            var rf = r.NextDouble();
            if (rf < 0.3)
            {
                d.PrimaryONCDiagnosis = diseases[0];

            }
            else if (rf < 0.5)
            {
                d.PrimaryONCDiagnosis = diseases[1];
            }
            else if (rf < 0.65)
            {
                d.PrimaryONCDiagnosis = diseases[2];
            }
            else if (rf < 0.75)
            {
                d.PrimaryONCDiagnosis = diseases[3];
            }
            else if (rf < 0.78)
            {
                d.PrimaryONCDiagnosis = diseases[4];
            }
            else if (rf < 0.81)
            {
                d.PrimaryONCDiagnosis = diseases[5];
            }
            else if (rf < 0.84)
            {
                d.PrimaryONCDiagnosis = diseases[6];
            }
            else
            {
                d.PrimaryONCDiagnosis = diseases[(rand % 3)+7];
            }
            d.DateOfPrimaryONCDiagnosis = DateTime.Parse("07/5/2015").AddDays(rand % 15);
            

            return d;
        }
        public HospitalData generateHospital()
        {
            var rand = r.Next();
            HospitalData h = new HospitalData();
            h.AdmissionDate = DateTime.Parse("07/01/2015").AddDays(rand % 30);
            h.DischargeDate = rand % 10 != 0 ? (DateTime?)(h.AdmissionDate.Value.AddDays((rand % 14)+5)) : null;
            h.HospitalLocation = "EG 3 - E(AFLAC)";
            h.PICUTransfer = rand % 25 == 0;
            if(h.PICUTransfer)
            {
                h.DateOfPICUTransfer = h.AdmissionDate.Value.AddDays((rand % 10) + 1);
            }
            return h;
        }

        int counter = 0;
        List<string> MaleNames = new List<string>();
        List<DateTime> DOBS = new List<DateTime>();
        List<string> FemaleNames = new List<string>();
        List<string> MRNS = new List<string>();
        Random r = new Random();
        public void LoadData()
        {
            TextFieldParser parser = new TextFieldParser("dataNov-21-2015.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters("|");
            var fields = parser.ReadFields();

            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();
                MaleNames.Add(fields[0]);
                FemaleNames.Add(fields[1]);
                DOBS.Add(DateTime.Parse(fields[2]));
                MRNS.Add(fields[3]);

            }

            parser = new TextFieldParser("dataNov-21-2015 (1).csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters("|");
            fields = parser.ReadFields();

            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();
                MaleNames.Add(fields[0]);
                FemaleNames.Add(fields[1]);
                DOBS.Add(DateTime.Parse(fields[2]));
                MRNS.Add(fields[3]);

            }
        }
        public DemographicData generateDemographics()
        {
            if (MRNS.Count == 0)
                LoadData();

            DemographicData d = new DemographicData();

            var rand = r.Next();
            d.Name = (rand % 2 == 0) ? MaleNames[rand % MaleNames.Count] : FemaleNames[rand % FemaleNames.Count];
            d.DOB = DOBS[rand % DOBS.Count];
            d.MRN = MRNS[counter % MRNS.Count];
            d.Race = "";
            d.Ethnicity = "";
            d.Sex = (rand % 2 == 0) ? "M" : "F";
            d.StudyID = "SampleData";
            counter++;
            return d;
        }
        public ParsedData fakeparse(string f)
        {
            if (f.Contains("BS8715"))
            {
                ParsedData p = new ParsedData();


                return p;
            }
            return default(ParsedData);
        }

        public List<DisplayData> displayedData = new List<DisplayData>();
        public List<DisplayData> filteredData = new List<DisplayData>();
        private void button5_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = "Loaded " + fbd.SelectedPath;
                bs = new SortableBindingList<DisplayData>();

                foreach (var d in generateData(100))
                {
                    bs.Add(new DisplayData(d));
                    displayedData.Add(new DisplayData(d));
                    filteredData.Add(new DisplayData(d));
                }

                dataGridView1.DataSource = bs;
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AllowUserToOrderColumns = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.Dock = DockStyle.Fill;
                for (int x = 0; x < dataGridView1.Columns.Count; x++)
                {
                    dataGridView1.Columns[x].Resizable = DataGridViewTriState.True;
                    dataGridView1.Columns[x].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;


                }
            }

        }

        private void ApplyFilters()
        {
            dataGridView1.ClearSelection();
            if (dataGridView1.DataSource != null)
            {
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];

                currencyManager.SuspendBinding();
                if (filters != null)
                {
                    for (var x = 0; x < dataGridView1.Rows.Count; x++)
                    {
                        var item = (dataGridView1.Rows[x].DataBoundItem as DisplayData);
                        if (item == null)
                        {
                            MessageBox.Show("This failed");
                        }
                        dataGridView1.Rows[x].Visible = true;
                     
                        foreach (var f in filters.GroupBy(s=>s.FieldName))
                        {
                            //at least one filter for that property passes
                         
                            var val = item.GetType().GetProperty(f.First().ReflectionName).GetValue(item);
                            if (!f.Any(s=>s.Apply(val)))
                            {
                                dataGridView1.Rows[x].Visible = false;
                                break;
                            }

                        }
                    }
                    filteredData.Clear();
                    foreach(var d in displayedData)
                    {
                        var inc = true;
                        foreach(var f in filters.GroupBy(s=>s.FieldName))
                        {
                            var val = d.GetType().GetProperty(f.First().ReflectionName).GetValue(d);
                            if (!f.Any(s=>s.Apply(val)))
                            {
                                inc = false;
                                break;
                            }
                        }
                        if (inc)
                            filteredData.Add(d);
                    }
                }
                currencyManager.ResumeBinding();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //show filter dialog
            Form2 filter = new Form2();

            filter.filters = filters;
            filter.ShowDialog();
            filters=filter.filters;
            ApplyFilters();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 analyze = new Form3();
            analyze.bc = new BayesianCorrelation<List<DisplayData>, DisplayData>(displayedData);
            analyze.filtered_bc = new BayesianCorrelation<List<DisplayData>, DisplayData>(filteredData);
            analyze.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Comma-Separated Value file (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(sfd.FileName);

            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}

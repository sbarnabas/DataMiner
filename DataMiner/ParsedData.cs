using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DataMiner
{
    public class DemographicData
    {
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public string MRN { get; set; }
        public string StudyID { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
    }
    public class HospitalData
    {
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string HospitalLocation { get; set; }
        public bool PICUTransfer { get; set; }
        public DateTime? DateOfPICUTransfer { get; set; }
    }
    public class DiseaseData
    {
        public string PrimaryONCDiagnosis { get; set; }
        public DateTime? DateOfPrimaryONCDiagnosis { get; set; }
        public string SecondaryONCDiagnosis { get; set; }
        public DateTime? DateOfSecondaryONCDiagnosis { get; set; }
        public bool Relapse { get; set; }
        public DateTime? DateOfRelapse { get; set; }
        public bool BMT { get; set; }
        public DateTime? DateOfBMT { get; set; }
        public string BMTType { get; set; }

    }
    public class DeviceData
    {
        public DateTime? LineInsertionDate { get; set; }
        public DateTime? LineRemovalDate { get; set; }
        public string LineType { get; set; }
        public bool HasSecondaryLine { get; set; }
        public string SecondaryLineType { get; set; }
        public DateTime[] LineEntries { get; set; }
        public string ExternalLinePresent { get; set; }


    }
    public class CLABSIData
    {
        public DateTime OnsetDate { get; set; }
        public string Type { get; set; }
        public string Organism { get; set; }
    }
    public class LabData
    {
        public bool BloodCultureOrdered { get; set; }
        public bool PositiveBloodCulture { get; set; }
        public string OrganismInBloodCulture { get; set; }
        public DateTime? DateOfPositiveBloodCulture { get; set; }
        public double ANCPositiveBloodCulture { get; set; }
        public double WBCPositiveBloodCulture { get; set; }
        public bool CLABSI { get; set; }

        public CLABSIData[] TotalCLABSI { get; set; }


    }
    public class CareDeliveryData
    {
        public DateTime[] MouthCare { get; set; }
        public DateTime[] BathChanges { get; set; }
        public DateTime[] DressingChange { get; set; }
        public DateTime[] TubingChange { get; set; }
        public DateTime[] CapChange { get; set; }
        public bool PreOpCHGBath { get; set; }
        public bool RoutineBath { get; set; }
        public bool HighTouchSurfaces { get; set; }
        public bool DailyLinenChange { get; set; }
        public string MouthCareType { get; set; }
        public string RinseAgent { get; set; }
    }
    public class Procedures
    {
        public bool SurgeryInLast24H { get; set; }
    }
    public class Medications
    {
        public bool TransfusionInLast24H { get; set; }
    }
    public class PhysicalExam
    {
        public bool Fever { get; set; }
        public bool OxygenRequired { get; set; }
        public bool AlteredMentalState { get; set; }
    }
    public class ParsedData
    {
        [DisplayName("Demographic Information")]
        public DemographicData demographic{get; set;}
        [DisplayName("Hospital Information")]
        public HospitalData hospital { get; set; }
        [DisplayName("Disease Data")]
        public DiseaseData disease { get; set; }
        [DisplayName("Device Data")]
        public DeviceData device { get; set; }
        [DisplayName("Labs Data")]
        public LabData lab { get; set; }
        [DisplayName("Care Delivery Information")]
        public CareDeliveryData care { get; set; }
        [DisplayName("Physical Exam")]
        public PhysicalExam exam { get; set; }
        [DisplayName("Procedure Information")]
        public Procedures proc { get; set; }
        [DisplayName("Medication")]
        public Medications meds { get; set; }
        
    }


    public class DisplayData
    {
        [IgnoreForCorrelation(true)]
        public string Name { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime? DOB { get; set; }
        [IgnoreForCorrelation(true)]
        [DisplayName("Medical Record Number")]
        public string MRN { get; set; }
        [IgnoreForCorrelation(true)]
        [DisplayName("Study ID")]
        public string StudyID { get; set; }

        public string Sex { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }

        [DisplayName("Admission Date")]
        public DateTime? AdmissionDate { get; set; }

        [DisplayName("Discharge Date")]
        public DateTime? DischargeDate { get; set; }

        [DisplayName("Hospital")]
        public string HospitalLocation { get; set; }

        [DisplayName("Primary Hematology/Oncology Diagnosis")]
        public string PrimaryONCDiagnosis { get; set; }

        [DisplayName("Date of Primary Hematology/Oncology Diagnosis")]
        public DateTime? DateOfPrimaryONCDiagnosis { get; set; }

        [DisplayName("Secondary Hematology/Oncology Diagnosis")]
        public string SecondaryONCDiagnosis { get; set; }

        [DisplayName("Date of Secondary Hematology/Oncology Diagnosis")]
        public DateTime? DateOfSecondaryONCDiagnosis { get; set; }

        [DisplayName("Transfered to PICU?")]
        public bool PICUTransfer { get; set; }
        [DisplayName("Date of PICU Transfer")]
        public DateTime? DateOfPICUTransfer { get; set; }

        public bool Relapse { get; set; }


        [DisplayName("Date of Relapse")]
        public DateTime? DateOfRelapse { get; set; }

        [DisplayName("Bone Marrow Transplant?")]
        public bool BMT { get; set; }
        [DisplayName("Date of Bone Marrow Transplant")]
        public DateTime? DateOfBMT { get; set; }
        [DisplayName("Bone Marrow Transplant Type")]
        public string BMTType { get; set; }

        [DisplayName("Line Insertion Date")]
        public DateTime? LineInsertionDate { get; set; }

        [DisplayName("Line Removal Date")]
        public DateTime? LineRemovalDate { get; set; }

        [DisplayName("Line Type")]
        public string LineType { get; set; }

        [DisplayName("Has Secondary Line?")]
        public bool HasSecondaryLine { get; set; }

        [DisplayName("Secondary Line Type")]
        public string SecondaryLineType { get; set; }

        [Browsable(false)]
        public DateTime[] LineEntries { get; set; }

        [DisplayName("Number of Line Entries")]
        public int LineEntryCount { get { return LineEntries==null?0:LineEntries.Length; } }

        [DisplayName("External Line Present?")]
        public string ExternalLinePresent { get; set; }

        [DisplayName("Blood Culture Ordered?")]
        public bool BloodCultureOrdered { get; set; }

        [DisplayName("Positive Blood Culture?")]
        public bool PositiveBloodCulture { get; set; }
        [DisplayName("Organism in Blood Culture")]
        public string OrganismInBloodCulture { get; set; }
        [DisplayName("Date of Positive Blood Culture")]
        public DateTime? DateOfPositiveBloodCulture { get; set; }
        [DisplayName("Absolute Neutraphil Count at Positive Blood Culture")]
        public double ANCPositiveBloodCulture { get; set; }

        [Browsable(false), DisplayName("Absolute Neutraphil Count <200 at Positive Blood Culture")]
        public bool ANCLT200 { get { return ANCPositiveBloodCulture < 200&& ANCPositiveBloodCulture>0; } }

        [DisplayName("White Blood Cell Count at Positive Blood Culture")]
        public double WBCPositiveBloodCulture { get; set; }
        [DisplayName ("Has CLASBI?")]
        public bool CLABSI { get; set; }
        [Browsable(false)]
        public CLABSIData[] TotalCLABSI { get; set; }
        [Browsable(false)]
        public DateTime[] MouthCare { get; set; }
        [Browsable(false)]
        public DateTime[] BathChanges { get; set; }
        [Browsable(false)]
        public DateTime[] DressingChange { get; set; }
        [Browsable(false)]
        public DateTime[] TubingChange { get; set; }
        [Browsable(false)]
        public DateTime[] CapChange { get; set; }
       
        [DisplayName("PreOP CHG Bath?")]
        public bool PreOpCHGBath { get; set; }
        [DisplayName("Routine Bath?")]
        public bool RoutineBath { get; set; }
        [DisplayName("High Touch Surfaces?")]
        public bool HighTouchSurfaces { get; set; }
        [DisplayName("Daily Linen Change")]
        public bool DailyLinenChange { get; set; }
        [DisplayName("Mouth Care Type")]
        public string MouthCareType { get; set; }
        [DisplayName("Rinse Agent")]
        public string RinseAgent { get; set; }


        public bool Fever { get; set; }
        [DisplayName("Oxygen Required")]
        public bool OxygenRequired { get; set; }
        [DisplayName("Altered Mental State")]
        public bool AlteredMentalState { get; set; }
        [DisplayName("Had Surgery in Last 24H")]
        public bool SurgeryInLast24H { get; set; }
        [DisplayName("Had Transfusion in Last 24H")]
        public bool TransfusionInLast24H { get; set; }

        public DisplayData(ParsedData p)
        {

            //match field names one level deep
           var toplevel= p.GetType().GetProperties();
            var myprops = this.GetType().GetProperties();
            foreach(var x in toplevel )
            {
                var props = x.PropertyType.GetProperties();
                var propinst = x.GetValue(p);
                foreach(var val in props)
                {
                    foreach(var my in myprops)
                    {
                        if (my.Name == val.Name)
                        {
                            if (propinst != null)
                            {
                                my.SetValue(this, val.GetValue(propinst));
                            }
                        }
                    }

                }
            }
            
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiner
{
    public class BayesianCorrelation<T, U> where T : ICollection<U>
    {
        //finds correlations between fields of T, given a collection of T

        public Dictionary<string, Dictionary<string, double>> Correlations = new Dictionary<string, Dictionary<string, double>>();
        public Dictionary<string, Dictionary<string, double>> NegCorrelations = new Dictionary<string, Dictionary<string, double>>();

        public Dictionary<string, Func<U, bool>> fieldExtractors = new Dictionary<string, Func<U, bool>>();
        public BayesianCorrelation(T data)
        {
            //for each pair of fields in U, if they are boolean, string

            //identify fields (boolean, and string categories), get extractors
            foreach (var prop in typeof(U).GetProperties())
            {
                //for boolean fields, it's just displayname
                if (prop.PropertyType == typeof(bool))
                {
                    var name = prop.Name;
                    var attr = prop.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                    if (attr.Length > 0)
                    {
                        name = ((DisplayNameAttribute)attr.Single()).DisplayName;
                    }
                    Func<U, bool> extractor = u =>
                     {
                         return (bool)prop.GetValue(u);
                     };

                    fieldExtractors.Add(name, extractor);
                }
                //for string fields it's displayname + " (" value+ ")"
                //exclude values of ""
                if (prop.PropertyType == typeof(string))
                {
                    var ign=(prop.GetCustomAttributes(typeof(IgnoreForCorrelationAttribute), false).SingleOrDefault() as IgnoreForCorrelationAttribute);
                    if (ign == null || !ign.Ignore)
                    {
                        var basename = prop.Name;
                        var attr = prop.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                        if (attr.Length > 0)
                        {
                            basename = ((DisplayNameAttribute)attr.Single()).DisplayName;
                        }
                        //find values
                        foreach (U item in data)
                        {
                            var val = (string)prop.GetValue(item);
                            if (!string.IsNullOrWhiteSpace(val))
                            {
                                var name = basename + " (" + val + ")";
                                if (!fieldExtractors.ContainsKey(name))
                                {
                                    Func<U, bool> extractor = u =>
                                     {
                                         return (string)prop.GetValue(u) == val;
                                     };
                                    fieldExtractors.Add(name, extractor);
                                }
                            }
                        }
                    }
                }
            }
            //all fields are in fieldextractor.keys
            //mapping from each field to each other field 
            foreach (string A in fieldExtractors.Keys)
            {
                Correlations.Add(A, new Dictionary<string, double>());
                NegCorrelations.Add(A, new Dictionary<string, double>());
                var correlationvector = Correlations[A];
                var negcorrelationvector = NegCorrelations[A];
                var Pa = (double)(data.Where(s => fieldExtractors[A](s)).Count()) / data.Count;
                var Pna = 1.0 - Pa;
                foreach (string x in fieldExtractors.Keys)

                {
                    if (x != A)
                    {
                        var Pxa = (double)(data.Where(s => fieldExtractors[A](s)).Where(s => fieldExtractors[x](s)).Count()) /
                            data.Where(s => fieldExtractors[A](s)).Count();
                        var Pxna = (double)(data.Where(s => !fieldExtractors[A](s)).Where(s => fieldExtractors[x](s)).Count()) /
                            data.Where(s => !fieldExtractors[A](s)).Count();
                        var Pnxa = (double)(data.Where(s => fieldExtractors[A](s)).Where(s => !fieldExtractors[x](s)).Count()) /
                            data.Where(s => fieldExtractors[A](s)).Count();
                        var Pnxna = (double)(data.Where(s => !fieldExtractors[A](s)).Where(s => !fieldExtractors[x](s)).Count()) /
                            data.Where(s => !fieldExtractors[A](s)).Count();

                        correlationvector.Add(x, (Pxa * Pa) / (Pxa * Pa + Pxna * Pna));
                        negcorrelationvector.Add(x, (Pnxa * Pa) / (Pnxa * Pa + Pnxna * Pna));
                        
                        
                    }
                }
            }





            // Possibility that A is true given X (x predictor of A)

            //var 1 (independent) =x, var 2 (dependent) =a
            //P(x|a) P(a) / P(x|a)P(a) + P(x|~A)P(~A)

            //P(x|a) = probability of both x and a (% co-incidence)
            //P(a) = probability of just a (%a)
            //P(x|~a) = probability of x without a
            //P(~A) = probability of not A


        }


    }
}
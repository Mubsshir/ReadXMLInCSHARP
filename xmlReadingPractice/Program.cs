using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xmlReadingPractice
{
    public class ReadXML
    {
        public void F_ReadXML(string path)
        {
            DataTable StudentTable = new DataTable();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode students = doc.DocumentElement.ChildNodes.Cast<XmlNode>().ToList()[0];//First CHILD OF ROOT ADDED TO STUDENTS I.E STUDENT tag
                                                                                          //Adding Tag name as a column name in datatable
            foreach (XmlNode student in students)
            {
                StudentTable.Columns.Add(student.Name);
            }
            //getting total number of records in Students tag
            int NoOfStudents = doc.DocumentElement.ChildNodes.Count;
            //now iterate througn each node  add values to rows
            for (int i = 0; i < NoOfStudents; i++)
            {
                XmlNode student = doc.DocumentElement.ChildNodes[i];
                List<string> values = student.ChildNodes.Cast<XmlNode>().ToList().Select(x => x.InnerText).ToList();
                StudentTable.Rows.Add(values.ToArray());
            }
            foreach (DataRow dr in StudentTable.Rows)
            {
                foreach (DataColumn dc in StudentTable.Columns)
                {
                    Console.Write(dr[dc] + "   |  ");
                }
                Console.WriteLine();
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadXML readXML = new ReadXML();
            string PathToXML = @"C:\Users\Mubsshir\source\repos\xmlReadingPractice\xmlReadingPractice\Data.xml";
            readXML.F_ReadXML(PathToXML);
            Console.ReadKey();
        }
    }
}

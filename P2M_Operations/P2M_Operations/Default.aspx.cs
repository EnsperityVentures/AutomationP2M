using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CsvHelper;
using System.IO;
public partial class _Default : System.Web.UI.Page
{
    string output;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Stream reader will read test.csv file in current folder
        StreamReader sr = new StreamReader(Server.MapPath(@"test.csv"));
        //For easy understanding we will be writing same csv data read from one test.csv file to another copyfile.csv file
        StreamWriter write = new StreamWriter(Server.MapPath(@"copyfile.csv"));
   
        //Csv reader reads the stream
        CsvReader csvread = new CsvReader(sr);
        
        //Csv writer stream
        CsvWriter csw = new CsvWriter(write);
        
        //csvread will fetch all record in one go to the IEnumerable object record
        IEnumerable<TestRecord> record = csvread.GetRecords<TestRecord>();

        foreach (var rec in record) // Each record will be fetched and printed on the screen
        {
            //reads csv and print output
            Response.Write(string.Format("Name : {0}, Sex : {1}, Occupation : {2} <br/>", rec.name, rec.sex, rec.occupation));
            //same time writes the csv file to another file : copyfile.csv
            csw.WriteRecord<TestRecord>(rec);
        }
        sr.Close();
        write.Close();//close file streams
    }
}

public class TestRecord // Test record class
{
    public string name { get; set; }
    public string sex { get; set; }
    public string occupation { get; set; }
}
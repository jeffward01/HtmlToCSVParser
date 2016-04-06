using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HTMLtoCSV.Console
{
   public class HtmlToCSV
    {
       public static string GetCSVAttachement()
       {
           //Get XML Values (IE: Html in a strong format)
           var XMLstring =
               "<h2>Advertising License Request</h2><center><table border='1' cellpadding='3'><tr style='background-color:#EEE;'><td style='width:25%'>Full Name</td><td>sdcsaca</td></tr><tr><td style='width:25%'>Company Name</td><td>asc</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Full Address</td><td>asc, </td></tr><tr><td style='width:25%'>Country</td><td>United States</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Phone</td><td>4159480160</td></tr><tr><td style='width:25%'>Fax</td><td>No Fax number listed</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Email</td><td>sacsa@gmail.com</td></tr><tr><td style='width:25%'>Publishing Company</td><td></td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Artist/Master/Album(if you are using Master)</td><td>Master Used: True</td></tr><tr><td style='width:25%'>Have you cleared the Master? ('Master' refers to the master recording, the copyrighted performance of the artist or band who made the song popular, or a copyrighted performance by a cover band. the master must be licensed from a record label.)</td><td>Master Cleared: True</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Project Title</td><td>324324</td></tr><tr><td style='width:25%'>Budget</td><td>234</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Music Budget</td><td>234</td></tr><tr><td style='width:25%'>Release/Air Date(Film must be released no later than 6 months from submission date of request) </td><td>3/17/2016 7:00:00 AM</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Scene Description</td><td>234324</td></tr><tr><td style='width:25%'>Total Length of Song Use</td><td>Duration: 234</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Number of Songs in Film</td><td>342</td></tr><tr><td style='width:25%'>Will you be altering the lyrics in any way? </td><td>Lyrics Changed: Parody Lyrics: True</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Media </td><td></td></tr><tr><td style='width:25%'>Term </td><td>324234</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Territory </td><td>324</td></tr><tr><td style='width:25%'>Web Address </td><td>google.com</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Proposed Structure </td><td>234</td></tr><tr><td style='width:25%'>Timing Type ID </td><td>3</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Paid Media Online </td><td>432</td></tr><tr><td style='width:25%'>Media Rights</td><td>True</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Re-Record</td><td>True</td></tr><tr><td style='width:25%'>Renewal for Second Term</td><td>True</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Extended to new territory</td><td>True</td></tr><tr><td style='width:25%'>Add Commercials to Campaign</td><td>True</td></tr><tr style='background-color:#EEE;'><td style='width:25%'>Lyrics</td><td>324324324324234234234</td></tr></table></center><br/><h3>Requested Songs</h3><table style='width:50%; border:solid 1px #666;'><tr><td style='width:10%; font-weight:bold;'>#</td><td style='font-weight:bold'>Song Title</td><td style='font-weight:bold'>Song Artist</td><td style='font-weight:bold'>Song Writer</td></tr><tr><td>1). </td><td>234324</td><td>234324</td><td>234234</td></tr><tr><td>2). </td><td>234324</td><td>23423</td><td>234234</td></tr><tr><td>3). </td><td>234234</td><td>234324</td><td>234324</td></tr><tr><td>4). </td><td>23432</td><td>234234</td><td>234234</td></tr></table><br/>";

           //Load XML string into a HTML doc
           HtmlDocument htmlDocument = new HtmlDocument();
           htmlDocument.LoadHtml(XMLstring);

           //Extract Document Title
           var documentTitle = htmlDocument.DocumentNode.SelectSingleNode("h2").InnerHtml;
           var myTable = htmlDocument.DocumentNode.Descendants("tr");
           //Build holder string for each row values
           StringBuilder rowValues = new StringBuilder();

           //Append Document Title to start of string
           rowValues.AppendLine(documentTitle);

           //Get all <tr> nodes


           //Iterate over each row <tr>
           foreach (HtmlNode node in myTable)
           {
               //Build string to hold cell values
               StringBuilder cellvalues = new StringBuilder();
               var counter = 1;
               
               //Iterate over each cell <td> within each <tr>
               foreach (HtmlNode node2 in node.Descendants("td"))
               {
                   var attribute = node2.InnerHtml;
                   if (counter == 1)
                   {
                       cellvalues.Append(attribute + ",");
                   }
                   else
                   {
                       cellvalues.Append(attribute);
                   }
                   counter++;

               }
               //Append Cell values to new line, this creates the CSV file.
               rowValues.AppendLine(cellvalues.ToString());
           }
           return rowValues.ToString();
       }

    }
}



   
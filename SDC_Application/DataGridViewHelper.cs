using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


/* 
  USAGE
 DataGridViewHelper dgh = new DataGridViewHelper(GridViewKhewatMalikaan);
            dgh.ExportAllRowsToCSV();
 */
public class DataGridViewHelper
{
    private DataGridView dataGridView;
    private DataGridViewSelectionMode originalSelectionMode;

    public DataGridViewHelper(DataGridView dgv)
    {
        dataGridView = dgv;
        originalSelectionMode = dataGridView.SelectionMode;
    }


    public void ExportAllRowsToCSV()
    {
        // Save the original selection mode
        DataGridViewSelectionMode previousSelectionMode = dataGridView.SelectionMode;

        // Set the selection mode to FullRowSelect
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Create a StringBuilder to build the CSV content
        StringBuilder csvContent = new StringBuilder();



        // Add headers row
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {
            if (column.Visible)
            {
                csvContent.Append(column.HeaderText); // Add Text qualifier to headers
                csvContent.Append(",");
            }
        }
        csvContent.AppendLine(); // New line after headers


        // Iterate through all rows
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            // Iterate through all cells in the row
            foreach (DataGridViewCell cell in row.Cells)
            {

                if (cell.OwningColumn.Visible)
                { 
                       // Append the cell value, replacing "," with "-"
                    string cellValue = cell.Value != null ? cell.Value.ToString().Replace(",", "-") : "";
                    csvContent.Append(cellValue);

                    // Add a comma unless it's the last cell in the row
                    if (cell.OwningColumn.Index < row.Cells.Count - 1)
                    {
                        if(cell.Visible)csvContent.Append(",");
                    }             
                }

            }

            // Add a new line to separate rows
            csvContent.AppendLine();
        }

        // Restore the original selection mode
        dataGridView.SelectionMode = previousSelectionMode;


        GenerateHtmlTable(csvContent.ToString());
        /*
        // Save the CSV content to a file in the temp folder
        string tempFolderPath = Path.GetTempPath();
        string csvFilePath = Path.Combine(tempFolderPath, "AllData.csv");

        using (TextWriter writer = new StreamWriter(csvFilePath, false, Encoding.UTF8))
        {
            writer.Write(csvContent.ToString());
        }

        // Open the CSV file with the default system application
        System.Diagnostics.Process.Start(csvFilePath);
        */
    }

    public void ExportSelectedRowsToCSV()
    {
         
        // Save the original selection mode
        DataGridViewSelectionMode previousSelectionMode = dataGridView.SelectionMode;

        // Set the selection mode to FullRowSelect
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Select all rows
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            row.Selected = true;
        }

        // Copy the selected data to the clipboard
        dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        dataGridView.SelectAll();
        DataObject dataObj = dataGridView.GetClipboardContent();
        Clipboard.SetDataObject(dataObj);

        // Restore the original selection mode
        dataGridView.SelectionMode = previousSelectionMode;


      
        // Save clipboard data to a Unicode CSV file in the temp folder
        string tempFolderPath = Path.GetTempPath();
        string csvFilePath = Path.Combine(tempFolderPath, "SelectedData.csv");

        using (TextWriter writer = new StreamWriter(csvFilePath, false, Encoding.Unicode)) // Use Encoding.Unicode
        {
            writer.Write(Clipboard.GetText());
        }

        // Open the CSV file with the default system application
        System.Diagnostics.Process.Start(csvFilePath);
    }

    public static void GenerateHtmlTable(string csvContent)
    {
        try
        {
            // Create a unique HTML file name based on the current timestamp
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string htmlFileName = "CSVTable_"+timeStamp+".html";

            // Split CSV content into rows and cells
            string[] rows = csvContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length == 0)
            {
                Console.WriteLine("No data to generate an HTML table.");
                return;
            }

            string[] headers = rows[0].Split(new[] { ',' }, StringSplitOptions.None);

            // Construct the HTML content with the CSV data
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine("<html>");
            htmlContent.AppendLine("<head>");
            htmlContent.AppendLine("<style>");
            htmlContent.AppendLine("table { border-collapse: collapse; width: 100%; }");
            htmlContent.AppendLine("th, td { border: 1px solid black; padding: 8px; text-align: left; }");
            htmlContent.AppendLine("</style>");
            htmlContent.AppendLine("</head>");
            htmlContent.AppendLine("<body>");
            htmlContent.AppendLine("<table>");

            // Add headers row
            htmlContent.AppendLine("<tr>");
            foreach (string header in headers)
            {
                htmlContent.AppendLine("<th>"+header+"</th>");
            }
            htmlContent.AppendLine("</tr>");

            // Skip the first row (headers) and process data rows
            for (int i = 1; i < rows.Length; i++)
            {
                string[] cells = rows[i].Split(new[] { ',' }, StringSplitOptions.None);
                htmlContent.AppendLine("<tr>");
                foreach (string cell in cells)
                {
                    htmlContent.AppendLine("<td>"+cell+"</td>");
                }
                htmlContent.AppendLine("</tr>");
            }

            htmlContent.AppendLine("</table>");
            htmlContent.AppendLine("</body>");
            htmlContent.AppendLine("</html>");

            // Save the HTML content to a file
            string tempFolderPath = Path.GetTempPath();
            string htmlFilePath = Path.Combine(tempFolderPath, htmlFileName);

            using (TextWriter writer = new StreamWriter(htmlFilePath, false, Encoding.UTF8))
            {
                writer.Write(htmlContent.ToString());
            }

            // Open the HTML file with the default system application (usually a web browser)
            System.Diagnostics.Process.Start(htmlFilePath);
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur during file generation or opening
            Console.WriteLine("Error: "+ex.Message+"");
        }
    }



}

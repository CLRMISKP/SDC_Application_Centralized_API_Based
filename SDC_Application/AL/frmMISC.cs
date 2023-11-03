using System;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SDC_Application.Classess;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace SDC_Application.AL
{
    public partial class frmMISC : Form
    {


        string dsvr = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
        string db = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
        string password = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
        string connectionString ="";// "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";

        public Sp_Arg_and_Meta_Info Selected_Sp_Arg_and_Meta_Info = null;
        public class Sp_Arg_and_Meta_Info
        {
            public string ProcName { get; set; }
            public Dictionary<string, string> MetadataContent { get; set; }
            public Dictionary<string, string> Arguments { get; set; }
            public List<ControlCreationAndBindingInfo> controlCreationInfo = null;
            public Dictionary<Control, List<Control>>  ControlAndTheirDependentControls = new Dictionary<Control, List<Control>>();

            public Sp_Arg_and_Meta_Info(string procName, Dictionary<string, string> metadataContent, Dictionary<string, string> arguments)
            {
                ProcName = procName;
                MetadataContent = metadataContent;
                Arguments = arguments;               
            }

            public Sp_Arg_and_Meta_Info(string procName)
            {
                ProcName = procName;
                MetadataContent = new Dictionary<string, string>();
                Arguments = new Dictionary<string, string>();
            }

            public Sp_Arg_and_Meta_Info()
            {
                ProcName = "";
                MetadataContent = new Dictionary<string, string>();
                Arguments = new Dictionary<string, string>();
            }

            public override string ToString()
            {
                if (MetadataContent != null && MetadataContent.ContainsKey("Title") && !string.IsNullOrWhiteSpace(MetadataContent["Title"]))
                {
                    return MetadataContent["Title"];
                }

                return ProcName;
            }
        }





        public int Tehsilid = 0;
        public class MonthItem
        {
            public string MonthName { get; set; }
            public DateTime FirstDayOfMonth { get; set; }
        }

        MonthInfo monthInfo = new MonthInfo(DateTime.Now);
        class MonthInfo
        {
            public MonthInfo()
            {
                offset = currentDate = DaysInMonth;
            }
            public int offset; // i.e week of 1st of that month 0 bein sun
            public int currentDate ;
            public int DaysInMonth;

            public MonthInfo(DateTime dt)
            {
                offset = (int)dt.DayOfWeek; // DayOfWeek returns 0 for Sunday, 1 for Monday, and so on.

                currentDate = dt.Day;
                DaysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
            }
        }
        public  DateTime GetFirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public frmMISC()
        {
            InitializeComponent();
        }

        System.Windows.Forms.CheckBox[] chkWeekDays = new CheckBox[5];
        


        // FORM_Load
        private void frmMISC_Load(object sender, EventArgs e)
        {

            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text; DataGridViewHelper.addHelpterToAllFormGridViews(this);

              dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
              db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
              password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
              if (dsvr == null || db == null || password == null)
              {
                  frmDbConn mfrmDbConn = new frmDbConn();
                  connectionString = mfrmDbConn.getConnectionStringFromConfig();
                  if (connectionString == null)
                  {
                      mfrmDbConn.ShowDialog();
                      if ((connectionString = mfrmDbConn.getConnectionStringFromConfig()) == null) { MessageBox.Show("Invalid Database"); return; };
                      
                  }
              }
              else {
                  connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";
              }

              CreateTableFilesIfNotPresent();
              AddStoredProcedureToDbIfNotFound("getReportsMetaData", getReportsMetaData);

              List<Sp_Arg_and_Meta_Info> ret = getReportInfoFromProcedures();
              
            PopulateReportsComboBox(ret);




            if (UsersManagments._Tehsilid == 0) UsersManagments._Tehsilid = 15;// for testing
            Tehsilid = UsersManagments._Tehsilid;


            this.panelParameters.Top = this.cmbReports.Top + this.cmbReports.Height;

        }


    public bool IsConnectionStringValid(string connectionString)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // If the connection opens successfully, it's considered valid
                return true;
            }
        }
        catch (Exception ex)
        {
            // Handle the exception or log it as needed
            Console.WriteLine("Connection error: " + ex.Message);

            return false;
        }
    }


        //--------------------------------------------------------------------------------  REPORT PORTION --------------------------------------------------------------------------------------------------------------------------------------
        
        void PopulateReportsComboBox(List<Sp_Arg_and_Meta_Info> reportInfo)
        {
            foreach (Sp_Arg_and_Meta_Info report in reportInfo)
            {
                cmbReports.Items.Add(report);
            }
        }

        private List<Sp_Arg_and_Meta_Info> getReportInfoFromProcedures(string procNameFilter = null)
        {
            List<Sp_Arg_and_Meta_Info> ret = new List<Sp_Arg_and_Meta_Info>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("getReportsMetaData", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        // Add the @ProcName parameter to filter the reports if a value is provided
                        if (!string.IsNullOrEmpty(procNameFilter))
                        {
                            cmd.Parameters.AddWithValue("@ProcName", procNameFilter);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Sp_Arg_and_Meta_Info report = new Sp_Arg_and_Meta_Info();
                                report.ProcName = reader["ProcName"].ToString();

                                // Parse MetadataContent into Dictionary
                                report.MetadataContent = ParseKeyValuePairs(reader["MetadataContent"].ToString());

                                // Parse Arguments into Dictionary
                                report.Arguments = ParseKeyValuePairs(reader["Arguments"].ToString(), true);

                                report.controlCreationInfo = this.getNewControlCreationInfroFromMetaData(report.MetadataContent);
                                ret.Add(report);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return ret;
        }



private Dictionary<string, string> ParseKeyValuePairs(string content, bool isArguments = false)
{
    Dictionary<string, string> result = new Dictionary<string, string>();

    // Normalize content: Convert multiple spaces or tabs to a single space
    if (isArguments) content = System.Text.RegularExpressions.Regex.Replace(content, @"\s+", " ");

    string[] items;

    if (isArguments)
    {
        // Split arguments based on the comma for further processing
        items = content.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    }
    else
    {
        items = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
    }

    foreach (string item in items)
    {

        string[] parts = null;
        if (isArguments)
        {
            // For arguments, we expect a space to separate the key and value
            parts = item.Split(new char[] { ' ' }, 2);
            if (parts.Length == 2)
            {
                result[parts[0].Trim()] = parts[1].Trim();
            }
        }
        else
        {
            parts = item.Split('=');
            if (parts.Length >1 )
            {
                string key = parts[0].Trim();                
                string value = string.Join("=", parts.Skip(1)).Trim();
                value = value.Split(new[] { "--" }, StringSplitOptions.None)[0].Trim();
                result[key] = value;
            }
        }
    }

    return result;
}

private void handleError(string errMsg)
{
    handleError(errMsg, this.panelParameters);
}
private void handleError(string errMsg, Panel panelOfControls)
{
    // Split the errMsg using the '|' delimiter
    string[] parts = errMsg.Split('|');

    if (parts.Length >= 3)
    {
        string errorType = parts[0].Trim();
        string title = parts[1].Trim();
        string message = parts[2].Trim();

        // Display the message in a MessageBox
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        // If the error type is "CTRL_NOT_VALID"
        if (errorType == "CTRL_NOT_VALID")
        {
            if (parts.Length >= 3)
            {
                string controlName = parts[1].Trim();

                // Find the control with the specified name on the panel
                Control[] foundControls = panelOfControls.Controls.Find(controlName, true);

                if (foundControls.Length > 0)
                {
                    Control targetControl = foundControls[0];
                    targetControl.Focus();
                    // Set focus to the control
                    if (targetControl is TextBox )
                    {
                        TextBox textBox = (TextBox)targetControl;                        
                        textBox.SelectAll(); // Select the text in the TextBox if it's a TextBox
                    }


                }
            }
        }
    }
}

        public class DataSetContainer
        {
            public DataSet ds;
            public string Err_Msg;
            public int Return;

            public DataSetContainer()
            {
                ds = new DataSet();
                Err_Msg = string.Empty;
                Return = 100;
            }
        }

        private DataSetContainer getDataSet(Sp_Arg_and_Meta_Info selectedReport)
        {
            
            DataSetContainer dc = new DataSetContainer();
            if (selectedReport == null) return dc;

                string procName = selectedReport.ProcName;
                Dictionary<string, string> metaData = selectedReport.MetadataContent;
                Dictionary<string, string> arguments = selectedReport.Arguments;

                string errMsg = string.Empty;
                int returnValue;

                using (SqlConnection conn = new SqlConnection(connectionString)) //replace with your connection string
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Create output parameter for "@Err_Msg"
                        SqlParameter errParam = new SqlParameter("@Err_Msg", SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Output,
                            Value = DBNull.Value
                        };
                        cmd.Parameters.Add(errParam);

                        // Create return value parameter
                        SqlParameter returnParam = new SqlParameter("@Return", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        cmd.Parameters.Add(returnParam);

                        // Populate other parameters from arguments dictionary
                        foreach (var arg in arguments)
                        {
                            if (!arg.Value.ToLower().Contains("output")) // Since we've already handled "@Err_Msg"
                            {
                                var parameterControl = panelParameters.Controls.Find(arg.Key.Replace("@", ""), false).FirstOrDefault();
                                if (parameterControl == null)
                                {
                                    ControlCreationAndBindingInfo controlCreationInfo = new ControlCreationAndBindingInfo(arg.Key.Replace("@", ""));
                                    if (arg.Value.ToUpper().StartsWith("DATE")) controlCreationInfo.ControlType = ControlType.DATE;

                                    addAdditionalControlOrUpdateExistingToPanel(controlCreationInfo);
                                    parameterControl = panelParameters.Controls.Find(arg.Key.Replace("@", ""), false).FirstOrDefault();
                                    if (parameterControl != null && arg.Value.ToUpper() == "INT") parameterControl.Text = "0"; // default value
                                    if (this.Selected_Sp_Arg_and_Meta_Info != null) this.Selected_Sp_Arg_and_Meta_Info.controlCreationInfo.Add(controlCreationInfo);
                                    
                                    
                                }

                               // if (parameterControl != null)
                                {
                                    var textBox = parameterControl as TextBox;
                                    if (textBox != null)
                                    {
                                        cmd.Parameters.AddWithValue(arg.Key, textBox.Text);
                                    }
                                    else
                                    {
                                        var comboBox = parameterControl as ComboBox;
                                        if (comboBox != null)
                                        {
                                            if (comboBox.SelectedItem != null)
                                            {
                                                cmd.Parameters.AddWithValue(arg.Key, comboBox.SelectedItem.ToString());
                                            }
                                            else
                                            {
                                                // Handle case where no item is selected in the ComboBox
                                                cmd.Parameters.AddWithValue(arg.Key, DBNull.Value);
                                            }
                                        }
                                        else
                                        {
                                            var dateTimePicker = parameterControl as DateTimePicker;
                                            if (dateTimePicker != null)
                                            {
                                                cmd.Parameters.AddWithValue(arg.Key, dateTimePicker.Value);
                                            }
                                            // You can continue to add more control types if needed...
                                        }
                                    }
                                }
                            }
                        }



                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds);
                        }
                        catch (Exception ex)
                        {
                            
                            throw;
                        }
                        

                        // Retrieve output parameter and return value post execution
                        errMsg = errParam.Value != null ? errParam.Value.ToString() : null;
                        returnValue = (int)returnParam.Value;
                        dc.ds = ds;
                        dc.Err_Msg = errMsg;
                        dc.Return = returnValue;


                        // Now ds contains the result. You can bind it to a control, process it, etc.
                        // For example: dataGridView1.DataSource = ds.Tables[0];
                    }
                }

                // Now, you have errMsg and returnValue to handle accordingly.
                if (!string.IsNullOrEmpty(errMsg))
                {
                    // MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Handle returnValue as per your logic.
            


            return dc;
        }

private void btnShowReport_Click(object sender, EventArgs e)
{
    Sp_Arg_and_Meta_Info selectedReport = cmbReports.SelectedItem as Sp_Arg_and_Meta_Info;
    if (selectedReport != null)
    {
        DataSetContainer dc= getDataSet(selectedReport);
        if (dc.Return == 100)
            HandleOutputFormat(selectedReport.MetadataContent, selectedReport.Arguments, dc.ds);
        else
            handleError(dc.Err_Msg);
    }
}

private void SaveAndOpenCSV(DataSet dataSet)
{
    if (dataSet.Tables.Count == 0) return;
    DataTable data = dataSet.Tables[0];

    // Get the user-specific temporary folder
    string tempFolderPath = Path.GetTempPath();

    // Create a unique CSV file name
    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
    string csvFileName = "output_" + timestamp + ".csv";

    // Combine the temporary folder and file name to create the full output path
    string csvFilePath = Path.Combine(tempFolderPath, csvFileName);

    // Create a StringBuilder to build the CSV content
    StringBuilder csvContent = new StringBuilder();

    // Build the CSV header row
    csvContent.AppendLine(string.Join(",", data.Columns.Cast<DataColumn>().Select(col => "\"" + col.ColumnName + "\"")));

    // Build the CSV data rows
    foreach (DataRow row in data.Rows)
    {
        var rowData = row.ItemArray.Select(item => "\"" + item.ToString().Replace("\"", "\"\"") + "\"");
        csvContent.AppendLine(string.Join(",", rowData));
    }

    // Save the CSV content to the specified output path with UTF-8 encoding
    File.WriteAllText(csvFilePath, csvContent.ToString(), Encoding.Unicode);

    // Open the CSV file with explorer.exe
    Process.Start("explorer.exe", csvFilePath);
}



private void SaveDataAsCsv(DataSet dataSet, string outputPath)
{
    
    DataTable data = dataSet.Tables[0];
    // Create a StringBuilder to build the CSV content
    StringBuilder csvContent = new StringBuilder();

    // Build the CSV header row
    csvContent.AppendLine(string.Join(",", data.Columns.Cast<DataColumn>().Select(col => "'" + col.ColumnName + "'")));

    // Build the CSV data rows
    foreach (DataRow row in data.Rows)
    {
        csvContent.AppendLine(string.Join(",", row.ItemArray.Select(item => "'" + item.ToString().Replace(",", "''") + "'")));
    }

    // Save the CSV content to the specified output path
    File.WriteAllText(outputPath, csvContent.ToString(),Encoding.Unicode);
}


public enum ControlType
{
    TEXT,
    DATE,
    COMBO
    
}

public class ControlCreationAndBindingInfo
{
    public ControlCreationAndBindingInfo(string controlName)
    {
        ControlName = controlName;
        ControlType = ControlType.TEXT; // Default to TextBox
        DataSource = string.Empty;
        DataSourceColumn = string.Empty;
        FilterControl = string.Empty;
        WhereTokens = new List<string>();
        control = null;
        Whereclause = "";
        bHidden = false;
        bEnable = true;

    }

    public bool bEnable { get; set; }
    public bool bHidden { get; set; }
    public Control control { get; set; }
    public string ControlName { get; set; }
    public ControlType ControlType { get; set; }
    public string DataSource { get; set; }
    public string DataSourceColumn { get; set; }
    public string FilterControl { get; set; }
    public List<string> WhereTokens { get; set; }
    public string Whereclause { get; set; }
}


public  List<string> ExtractBracketValues(string s, string TokenStart , out string CompleteCondition)
{
    CompleteCondition = "";
    List<string> result = new List<string>();

    // Split the string based on '|'
    string[] tokens = s.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

    // Define the pattern to match square bracket contents
    string pattern = @"\[(.*?)\]";

    foreach (var token in tokens)
    {

        // Trim spaces and check if the token starts with "Where "
        if (token.TrimStart().StartsWith(TokenStart, StringComparison.OrdinalIgnoreCase))
        {
            CompleteCondition = token;
            // Match all values inside square brackets
            var matches = Regex.Matches(token, pattern);
            foreach (Match match in matches)
            {
                result.Add(match.Groups[1].Value);
            }
        }
    }

    return result;
}



public static string getValueFromStringList(string[] array, string key)
{
    foreach (var entry in array)
    {
        var keyValue = entry.Split(new char[] { '=' }, 2);  // Split at most into 2 parts

        if (string.Equals(keyValue[0].Trim(), key, StringComparison.OrdinalIgnoreCase))

        {
            // If there's a value part after '=', return it. Else return empty string.
            return keyValue.Length > 1 ? keyValue[1].Trim() : "";
        }
    }

    return null;  // Key not found in the list
}
private List<ControlCreationAndBindingInfo> getNewControlCreationInfroFromMetaData(Dictionary<string, string> metaData)
{
    List<ControlCreationAndBindingInfo> ret = new List<ControlCreationAndBindingInfo>();

    // Get all keys from metaData with starting string "mapping_report_argument_"
    // like ProcedureArgument_To_Map|Sno_of_Report_Param|Data Type it will be Date/String/Number

     var parameterKeys = metaData.Keys
        .Where(key => key.StartsWith("create_control_"))
        .Select(key => key.Substring("create_control_".Length)) // Remove the prefix
        .ToList();


    foreach (var parameterKey in parameterKeys)
    {
        string parameterName = parameterKey;
        string parameterValue = metaData["create_control_"+parameterKey];

        var v = new ControlCreationAndBindingInfo(parameterKey);


        // Split parameterValue into its parts
        string[] parameterParts = parameterValue.Split('|');

        string sHidden = getValueFromStringList(parameterParts, "HIDDEN");
        if (sHidden != null && string.Equals(sHidden, "true", StringComparison.OrdinalIgnoreCase))
        {
            v.bHidden = true;
        }
        string sEnable = getValueFromStringList(parameterParts, "ENABLE");
        if (sEnable != null && string.Equals(sEnable, "FALSE", StringComparison.OrdinalIgnoreCase))
        {
            v.bEnable = false;
        }



       

        if(parameterParts.Length>1){
            if(parameterParts[0]=="COMBO")v.ControlType = ControlType.COMBO;
            if(parameterParts[0]=="DATE")v.ControlType = ControlType.DATE;
            if(parameterParts[0]=="TEXT")v.ControlType = ControlType.TEXT;
        }

        if(parameterParts.Length>2){
            v.DataSource = parameterParts[1];
        }

        if(parameterParts.Length>3){
            v.DataSourceColumn = parameterParts[2];
        }

        if(parameterParts.Length>4){
            v.FilterControl = parameterParts[3];
        }

        string outWhereCaluse; 
        v.WhereTokens = ExtractBracketValues(parameterValue, "where", out outWhereCaluse);
        v.Whereclause = outWhereCaluse;

        ret.Add(v);
    }

    return ret;
}


class ReportParameterInfoFromComments
{
    public ReportParameterInfoFromComments()
    {
        // Initialize all properties here
        ParamName = string.Empty;
        DataType = string.Empty;
        BoundingControl = null;
    }

    public string ParamName { get; set; }
    public string DataType { get; set; }
    public Control BoundingControl { get; set; }
}


private List<ReportParameterInfoFromComments> GetReportParameterInfoFromComments(Dictionary<string, string> metaData)
{
    List<ReportParameterInfoFromComments> ret = new List<ReportParameterInfoFromComments>();

    // Get all keys from metaData with starting string "mapping_report_argument_"
    // like ProcedureArgument_To_Map|Sno_of_Report_Param|Data Type it will be Date/String/Number'
    var parameterKeys = metaData.Keys
        .Where(key => key.StartsWith("mapping_report_argument_"))
        .ToList();

    // Sort the parameterKeys based on "Sno_of_Report_Param"
    parameterKeys.Sort((key1, key2) =>
    {
        int sno1 = int.Parse(metaData[key1].Split('|')[1]);
        int sno2 = int.Parse(metaData[key2].Split('|')[1]);
        return sno1.CompareTo(sno2);
    });

    foreach (var parameterKey in parameterKeys)
    {
        string parameterName = parameterKey.Replace("mapping_report_argument_", "");
        string parameterValue = metaData[parameterKey];

        // Split parameterValue into its parts
        string[] parameterParts = parameterValue.Split('|');

        ReportParameterInfoFromComments paramInfo = new ReportParameterInfoFromComments
        {
            ParamName = parameterName,
            DataType = parameterParts.Length >= 3 ? parameterParts[2].Trim() : string.Empty
        };

        // Find the control based on the first part of the parameterValue
        Control[] foundControls = panelParameters.Controls.Find(parameterParts[0], true);
        paramInfo.BoundingControl = foundControls.Length > 0 ? foundControls[0] : null;

        // Add the parameter to the list
        ret.Add(paramInfo);
    }

    return ret;
}


public string GetFilePathOrFromDB(string fileName, bool saveInTempFolder = true)
{
    string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
    string filePathInCurrentFolder = Path.Combine(currentFolder, fileName);

    if (File.Exists(filePathInCurrentFolder))
    {
        return filePathInCurrentFolder;
    }

    string query = "SELECT FileObj FROM ReportFiles WHERE FileName = @FileName";
    byte[] fileBytes = null;

    using (IDbConnection db = new SqlConnection(connectionString))
    {
        db.Open();

        using (SqlCommand command = new SqlCommand(query, (SqlConnection)db))
        {
            command.Parameters.AddWithValue("@FileName", fileName);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    fileBytes = (byte[])reader["FileObj"];
                }
            }
        }
    }

    if (fileBytes != null)
    {
        string destinationFolder = saveInTempFolder ? Path.GetTempPath() : currentFolder;
        string filePath = Path.Combine(destinationFolder, fileName);

        File.WriteAllBytes(filePath, fileBytes);
        return filePath;
    }
    else
    {
        Console.WriteLine("File not found in the current folder or the database.");
        return string.Empty;
    }
}


private void HandleOutputFormat(Dictionary<string, string> metaData, Dictionary<string, string> arguments, DataSet data)
{
   // DataTable data = dataSet.Tables[0];

    if (metaData.ContainsKey("Output_format"))
    {
        string outputFormat = metaData["Output_format"].Trim();

        if (outputFormat == "GRID") {
            dataGridView1.Visible = true;
            dataGridView1.DataSource = data.Tables[0];
            if (data.Tables.Count > 1)
            {
                // Check if dataGridView2 already exists
                if (!this.Controls.ContainsKey("dataGridView2"))
                {
                    // Halve the height of dataGridView1
                    
                    dataGridView1.Height = dataGridView1.Height / 2;

                    // Create and set up dataGridView2
                    DataGridView dataGridView2 = new DataGridView
                    {
                        Name = "dataGridView2",  // Important: Give it a name for future reference
                        Width = dataGridView1.Width,
                        Height = dataGridView1.Height,
                        Top = dataGridView1.Bottom,
                        Left = dataGridView1.Left,
                        Anchor = dataGridView1.Anchor  // Assuming dataGridView1 was anchored to resize with the form
                    };

                    // Add dataGridView2 to the form's controls
                    this.Controls.Add(dataGridView2);
                    dataGridView2.DataSource = data.Tables[1];
                    
                    // Create dataGridView2
                    /*
                    DataGridView dataGridView2 = new DataGridView
                    {
                        Name = "dataGridView2",
                        Dock = DockStyle.Fill
                    };

                    // Create and configure SplitContainer
                    SplitContainer splitContainer = new SplitContainer
                    {
                        Dock = DockStyle.Fill,
                        Orientation = Orientation.Horizontal
                    };

                    // Add dataGridView1 to Panel1 and dataGridView2 to Panel2
                    splitContainer.Panel1.Controls.Add(dataGridView1);
                    splitContainer.Panel2.Controls.Add(dataGridView2);

                    // Add SplitContainer to the form's controls
                    this.Controls.Add(splitContainer);
                    dataGridView2.DataSource = data.Tables[1];
                    */
                }

            }
        }else
        if (outputFormat == "CrystalReport")
        {
            // Check for the 'Report' key in the metadata
            if (metaData.ContainsKey("Report"))
            {
                string reportName = metaData["Report"].Trim();

                // Check if the reportName exists in resource 'Resource1.resx'
                //if (!Resource1.ResourceManager.GetString(reportName, Resource1.Culture).IsNullOrEmpty())
                /*if (!string.IsNullOrEmpty(Resource1.ResourceManager.GetString(reportName, Resource1.Culture))
                    ||
                    File.Exists(Path.Combine(Environment.CurrentDirectory, reportName))
                    )
                    */
                String filePath = GetFile(reportName, true);
                
                if (filePath != string.Empty)
                {
                    try
                    {

                        List<ReportParameterInfoFromComments> ret = GetReportParameterInfoFromComments(metaData);
                        Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();
                        foreach (var paramInforFromMeta in ret)
                        {
                            string controlValue = "0"; // to handle both default number and string format to avoid errors
                            if (paramInforFromMeta.BoundingControl != null) controlValue = paramInforFromMeta.BoundingControl.Text;
                            parameterDictionary.Add(paramInforFromMeta.ParamName, controlValue);
                        }


                        // Now you have a parameterDictionary with parameter names and values
                        // Call your LoadGenericReport method with this dictionary as an argument
                        FardForPersonalRecord_Cr frm = new FardForPersonalRecord_Cr();
                        frm.bUsingForGeneralpurposeThisReport = true;
                        frm.LoadGenericReport(data, parameterDictionary, reportName);
                        //frm.Show();
                        frm.ShowDialog();

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                         SaveAndOpenCSV(data);
                    }
                }
                else
                { SaveAndOpenCSV(data);
                    // Report not found in resources
                    // Check in the local folder if present
                    string localReportPath = Path.Combine(Environment.CurrentDirectory, reportName );

                    if (File.Exists(localReportPath))
                    {
                        // Report found in the local folder
                        // Proceed with handling it or loading it as needed
                        // Example: Load the Crystal Report from the local path
                        // crystalReportViewer1.ReportSource = localReportPath;
                    }
                    else
                    {
                        // Report not found in resources or local folder
                        // Save and open data as CSV
                       
                    }
                }
            }
            else
            {
                // 'Report' key not found in metadata, save and open data as CSV
                SaveAndOpenCSV(data);
            }
        }
        else if (outputFormat == "SSRS_Report")
        {
            // Handle SSRS Report logic here
            // ...
        }
        else
        {
            // Output format not recognized, save and open data as CSV
            SaveAndOpenCSV(data);
        }
    }
    else
    {
        // 'Output_format' key not found in metadata, save and open data as CSV
        SaveAndOpenCSV(data);
    }
}

// Usage:
// Call HandleOutputFormat(metaData, ds.Tables[0]) with your metadata and data table


private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
{

    dataGridView1.Visible = false;
    
    // Clear existing controls from the panel
    panelParameters.Controls.Clear();
    int ControlWidth = 200;
    int spacing = 10;




    Sp_Arg_and_Meta_Info selectedReport = cmbReports.SelectedItem as Sp_Arg_and_Meta_Info;
    if (selectedReport != null)
    {
        Selected_Sp_Arg_and_Meta_Info = selectedReport;

        int yOffset = 10;  // Starting offset

        foreach (var arg in selectedReport.Arguments)
        {
            // Skip if it contains the keyword "output"
            if (arg.Value.Contains("output"))
                continue;

            // Create a label for the argument
            Label lbl = new Label();

            // Remove "@" and replace "_" with a space
            string friendlyArgName = arg.Key.TrimStart('@').Replace('_', ' ');
            lbl.Text = friendlyArgName;// +" (" + arg.Value + "):";
            lbl.Top = yOffset;
            lbl.Left = 10;
            lbl.Width = 150;

            Control inputControl;

            // Check for DATETIME and use appropriate control
            if (arg.Value.ToUpper().Contains("DATETIME"))
            {
                DateTimePicker dtp = new DateTimePicker();
                //dtp.Name = "dtp" + arg.Key;
                dtp.Name = arg.Key.Replace("@", "");
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd MMM yyyy";
                dtp.Top = yOffset;
                dtp.Left = lbl.Right + 10;
                dtp.Width = ControlWidth;
                inputControl = dtp;

                // Add an anonymous event handler for ValueChanged event
                dtp.ValueChanged += (sender2, e2) =>
                {
                    // Handle the date change event here
                    DateTimePicker datePicker = (DateTimePicker)sender2;
                    DateTime selectedDate = datePicker.Value.Date;

                    // Check if the selected date is equal to "30 Jun 1976"
                    if (selectedDate == new DateTime(1976, 6, 30))
                    {
                        // Enable visibility of button1
                        btnUpload.Visible = true;
                    }
                    else
                    {
                        // Disable visibility of button1
                       // button1.Visible = false;
                    }
                };
            }

            else
            {
                TextBox txt = new TextBox();
                //txt.Name = "txt" + arg.Key;
                txt.Name = arg.Key.Replace("@", ""); ;
                txt.Top = yOffset;
                txt.Left = lbl.Right + 10;
                txt.Width = ControlWidth;

                if (arg.Key.Equals("@UserId", StringComparison.OrdinalIgnoreCase))
                {
                    /*txt.Click += (sender2, e2) =>
                    {
                        // Show your custom dialog here. 
                        // Assuming it returns a string value which you want to set to the TextBox.
                       // string dialogValue = ShowCustomDialog();
                        txt.Text = "1822";// dialogValue;
                    };*/
                    txt.Text = UsersManagments.UserId.ToString();
                    txt.ReadOnly = true;
                }

                if (arg.Key.Equals("@TehsilId", StringComparison.OrdinalIgnoreCase))
                {
                 /*   txt.Click += (sender2, e2) =>
                    {
                        txt.Text = "1822";// dialogValue;
                    };
                    */
                    txt.Text = this.Tehsilid.ToString();
                    txt.ReadOnly = true;
                }

                if (arg.Key.Equals("@TokenId", StringComparison.OrdinalIgnoreCase))
                {
                    txt.Click += (sender2, e2) =>
                    {/*
                        frmTokenPopulate PopulateO = new frmTokenPopulate();
                        PopulateO.ServiceTypeId = "0";// GetServiceTypeIdByServiceName("Inteqal");
                        PopulateO.fromform = "0";
                        PopulateO.InteqalMain = true;

                        PopulateO.FormClosed += (sender3, e3) =>
                        {
                            txt.Text = PopulateO.TokenID;
                            txt.ReadOnly = true;
                        };
                        PopulateO.ShowDialog();
                        */
                    };
                }

                inputControl = txt;
            }


            ControlCreationAndBindingInfo cc = selectedReport.controlCreationInfo.FirstOrDefault(c => c.ControlName == inputControl.Name);

            // Add the label and input control to the panel
            lbl.Name = "LABEL_" + inputControl.Name;
            panelParameters.Controls.Add(lbl);
            panelParameters.Controls.Add(inputControl);

            if (cc==null || cc.bEnable == false)
            {
                lbl.Enabled = true;
            }

            // Adjust the offset for the next controls
            yOffset += inputControl.Height + 10;
        }

        // Resize the panel to fit the controls with some additional padding
        panelParameters.Height = yOffset + 20;

        // Position the button below the panelParameters
        btnShowReport.Visible = true;

        panelParameters.BackColor = Color.LightGray; // Change to your desired lighter color       
        btnShowReport.Top = panelParameters.Top + panelParameters.Height + spacing;
        this.btnShowReport.Left = panelParameters.Width - this.btnShowReport.Width - spacing;


        // Show the panel
        panelParameters.Visible = true;

         addAdditionalControlOrUpdateExistingToPanel(selectedReport.controlCreationInfo);


        // Most Important it contains the hirarche of controls 
         this.Selected_Sp_Arg_and_Meta_Info.ControlAndTheirDependentControls = get_ControlAndTheirDependentControls(
                this.Selected_Sp_Arg_and_Meta_Info.controlCreationInfo
             );

        // Most Important it contains the hirarche of controls 
         PopulateTreeView(this.Selected_Sp_Arg_and_Meta_Info.ControlAndTheirDependentControls);
        // Now it is sure that all controll has been created so now papulating them

         PopulateCombo("");
        
    }
    else
    {
        panelParameters.Visible = false;  // Hide the panel if no valid report is selected
    }
}


// Assuming Control has a property 'Name' to represent its name or identifier
public void PopulateTreeView(Dictionary<Control, List<Control>> ControlAndTheirDependentControls)
{
    treeView1.Nodes.Clear();  // Clear existing nodes

    foreach (var entry in ControlAndTheirDependentControls)
    {
        TreeNode parentNode = new TreeNode(entry.Key.Name);
        parentNode.Name = entry.Key.Name; // This step is crucial for the Find method
        ControlCreationAndBindingInfo ctrlInfo = this.GetControlCreationAndBindingInfoByControlName(this.Selected_Sp_Arg_and_Meta_Info.controlCreationInfo, entry.Key.Name);
        ctrlInfo.control = this.GetPanelControlByName(parentNode.Name);
        parentNode.Tag = ctrlInfo;

        TreeNode temp = getDeepestChildNode(entry.Key.Name);
        if (temp != null) parentNode = temp;
        else treeView1.Nodes.Add(parentNode);
        
        //TreeNode parentNode = AddNodeToTreeView(entry.Key.Name);

        foreach (Control childControl in entry.Value)
        {
            //TreeNode childNode = new TreeNode(childControl.Name);
            //parentNode.Nodes.Add(childNode);
            TreeNode parentNodeT = AddNodeToTreeView(entry.Key.Name, childControl.Name);
        }
    }
    treeView1.ExpandAll();  // Optionally, expand all nodes after populating
}
        

public TreeNode AddNodeToTreeView(string parentNodeName, string childNodeName)
{
    TreeNode nodeToAddTo = getDeepestChildNode(parentNodeName);

    if (nodeToAddTo != null)
    {
        TreeNode addedOne = new TreeNode(childNodeName);
        addedOne.Name = childNodeName;
        ControlCreationAndBindingInfo ctrlInfo = this.GetControlCreationAndBindingInfoByControlName(this.Selected_Sp_Arg_and_Meta_Info.controlCreationInfo, addedOne.Name);
        ctrlInfo.control = this.GetPanelControlByName(addedOne.Name);
        addedOne.Tag = ctrlInfo;

       // addedOne.Tag = this.GetPanelControlByName(addedOne.Name);
        nodeToAddTo.Nodes.Add(addedOne);
    }
    else
    {
        TreeNode addedOne = new TreeNode(childNodeName);
        addedOne.Name = childNodeName;
        ControlCreationAndBindingInfo ctrlInfo = this.GetControlCreationAndBindingInfoByControlName(this.Selected_Sp_Arg_and_Meta_Info.controlCreationInfo, addedOne.Name);
        ctrlInfo.control = this.GetPanelControlByName(addedOne.Name);
        addedOne.Tag = ctrlInfo;
        //addedOne.Tag = this.GetPanelControlByName(addedOne.Name);
        treeView1.Nodes.Add(addedOne);
    }
    return nodeToAddTo;
}

public TreeNode getDeepestChildNode(string nodeName)
{
    TreeNode[] nodes = treeView1.Nodes.Find(nodeName, true);

    if (nodes.Length == 0)
        return null;
    return nodes[0];
    /*
    TreeNode node = nodes[0];
    while (node.Nodes.Count > 0)
    {
        node = node.LastNode;
    }

    return node;
    */
}
public Dictionary<Control, List<Control>> get_ControlAndTheirDependentControls(List<ControlCreationAndBindingInfo> controlCreationInfo)
{
    Dictionary<Control, List<Control>> ControlAndTheirDependentControls = new Dictionary<Control, List<Control>>();
        foreach (var v in controlCreationInfo)
        {
            Control effectedControl = GetPanelControlByName(v.ControlName);
            if (effectedControl == null) continue;

            Control filterControl = GetPanelControlByName(v.FilterControl);
            if (filterControl == null) continue;

            if (effectedControl == filterControl) continue;

            List<Control> effectedControls;
            if (!ControlAndTheirDependentControls.TryGetValue(filterControl, out effectedControls))
            {
                effectedControls = new List<Control>();
                ControlAndTheirDependentControls[filterControl] = effectedControls;
            }


            effectedControls.Add(effectedControl);

            if (effectedControls.Contains(filterControl))
                throw new Exception("Circular Dependency of Control affecting himself violating parent-child");

            ControlAndTheirDependentControls[filterControl] = effectedControls;
        }
    return ControlAndTheirDependentControls;
}
ControlCreationAndBindingInfo GetControlCreationAndBindingInfoByControlName(List<ControlCreationAndBindingInfo> controlCreationInfo,string controlName)
{
    return controlCreationInfo.FirstOrDefault(x => x.ControlName == controlName);
}
List<ControlCreationAndBindingInfo> GetControlCreationAndBindingInfoByFilterControl(List<ControlCreationAndBindingInfo> controlCreationInfo,string filterControl)
{
    return controlCreationInfo.Where(x => x.FilterControl == filterControl).ToList();
}
public Control GetPanelControlByName(string name)
{
    foreach (Control control in panelParameters.Controls)
    {
        if (control.Name == name)
        {
            return control;
        }
    }
    return null; // Return null if no control with the given name is found
}
        /*
private void AddDataSourceToControls(Dictionary<string, string> metaData)
{
    List<ControlCreationAndBindingInfo> controlCreationInfo = this.getNewControlCreationInfroFromMetaData(metaData);
    AddDataSourceToControls(controlCreationInfo);
}
        */
private void AddDataSourceToControls(List<ControlCreationAndBindingInfo> controlCreationInfo)
{
    

    foreach (var ctrlInfo in controlCreationInfo)
    {
        Control dependentControl = GetPanelControlByName(ctrlInfo.ControlName);
        Control independentControl = GetPanelControlByName(ctrlInfo.FilterControl);

        if (independentControl != null)
        {
            if (independentControl is ComboBox)
            {
                // Attach to the SelectedIndexChanged event for ComboBox
                ((ComboBox)independentControl).SelectedIndexChanged += (sender, e) =>
                {
                    string value = null;
                    if (((ComboBox)independentControl).SelectedItem != null)
                    {
                        value = ((ComboBox)independentControl).SelectedItem.ToString();
                    }

                    // Handle the value change logic here
                };
            }
            else if (independentControl is TextBox)
            {
                // Attach to the TextChanged event for TextBox
                ((TextBox)independentControl).TextChanged += (sender, e) =>
                {
                    string value = ((TextBox)independentControl).Text;

                    // Handle the value change logic here
                };
            }
            else if (independentControl is DateTimePicker)
            {
                // Attach to the ValueChanged event for DateTimePicker
                ((DateTimePicker)independentControl).ValueChanged += (sender, e) =>
                {
                    string value = ((DateTimePicker)independentControl).Value.ToString();

                    // Handle the value change logic here
                };
            }
        }
    }
}



private int PopulateCombo(string CtrlName)
{
    //List<ControlCreationAndBindingInfo> controlCreationInfo = this.getNewControlCreationInfroFromMetaData(MetadataContent);
    // return PopulateCombo(controlCreationInfo);

    if (CtrlName == "") // Means iterate through all and papulate all 
    {
        foreach (TreeNode selectedNode in treeView1.Nodes)
        {
            // Do something with the child node, for example, print its name.
            //Console.WriteLine("Child Node Name: " + childNode.Text);
            IterateTreeView(selectedNode);
        }
    }
    else
    {   
//        MessageBox.Show("Selected Node Name: " + selectedNode.Text + " Ctrl=" + ctrlInfo.control.Name);     
        TreeNode selectedNode = getDeepestChildNode(CtrlName);
        if (selectedNode != null) IterateTreeView(selectedNode);
    }
    return 0;
}


int  IterateTreeView(TreeNode parentNode)
{
    int ret = 1;

    if (parentNode != null)
    {
        ControlCreationAndBindingInfo ctrlInfo = (ControlCreationAndBindingInfo)parentNode.Tag;// this.GetControlCreationAndBindingInfoByControlName(selectedNode.Tag);
        if (ctrlInfo == null) return 0;
        if (ctrlInfo.control == null) return 0;
        ret = PopulateCombo(ctrlInfo);
    }
    foreach (TreeNode selectedNode in parentNode.Nodes)
    {
        // Do something with the child node, for example, print its name.
        //Console.WriteLine("Node Name: " + childNode.Text);
        if (selectedNode != null)
        {
            ControlCreationAndBindingInfo ctrlInfo2 = (ControlCreationAndBindingInfo)selectedNode.Tag;// this.GetControlCreationAndBindingInfoByControlName(selectedNode.Tag);
            if (ctrlInfo2 == null) return 0;
            if (ctrlInfo2.control == null) return 0;
            ret = PopulateCombo(ctrlInfo2);
        }
        // Recursively call the function to iterate through child nodes of the current child node.
        IterateTreeView(selectedNode);
    }
    return ret;
}


private int PopulateCombo(ControlCreationAndBindingInfo controlCreationInfo)
{
    int ret = 1;
    List<Sp_Arg_and_Meta_Info> info = this.getReportInfoFromProcedures(controlCreationInfo.DataSource);
    DataSetContainer dc = null;
    if(info.Count!=0){ // It is stored procedure
        dc = this.getDataSet(info[0]);
    }else{ // May be Table as no infor for Stored Procedure is returned
        dc = CallDynamicReturnTableRecords(
                controlCreationInfo.DataSource ,
                controlCreationInfo.DataSourceColumn,
                getUpdatedWhereclause(controlCreationInfo.Whereclause, controlCreationInfo.WhereTokens )                
            );
    }

    if (dc != null && dc.ds != null)
    {
        if (dc.Err_Msg.Trim() == "")
        {
            if (controlCreationInfo.control is ComboBox)
            {
                ComboBox cmbo = (ComboBox)controlCreationInfo.control;
                this.PopulateCombo(cmbo, dc.ds, controlCreationInfo.DataSourceColumn);
            }else{
                MessageBox.Show("Control " + controlCreationInfo.control.Name + " is not combobox");
                controlCreationInfo.control.Focus();

            }
            
        }
        else MessageBox.Show(dc.Err_Msg);
    }
    
    return ret;
}


public string getUpdatedWhereclause(string Whereclause, List<string> controlNames)
{
    foreach (var controlName in controlNames)
    {
        string controlValueAsString = getControlValue(controlName);
        Whereclause = Whereclause.Replace("[" + controlName + "]", "[" + controlValueAsString + "]");
    }
    return Whereclause;
}


public String getControlValue(String Controlname)
{
    string ret ="";
    Control ctrl = this.GetPanelControlByName(Controlname);
    if (ctrl != null) ret= getControlValue(ctrl);
    else MessageBox.Show("Control="+Controlname+" Not found ");
    return ret;
}


public String getControlValue(Control ctrl)
{
    if (ctrl is ComboBox)
    {
        ComboBox combo = ctrl as ComboBox;
        DataTable dt = combo.DataSource as DataTable;
        String I_ = "'";
        String V_ = "Cast('[VAL_TAG]' AS [AS_TAG])";
        String C_ = "Cast('[VAL_TAG]' AS VARCHAR(MAX))"; // DEFAULT

        if (dt == null) return "'0'";

        Type firstColumnType = dt.Columns[0].DataType;
        
        Type secondColumnType = dt.Columns[1].DataType;

        switch (firstColumnType.Name)
        {
            case "Int32":
                C_ = V_.Replace("'", "").Replace("[AS_TAG]", "INT");
                break;
            case "Int64":
                C_ = V_.Replace("'", "").Replace("[AS_TAG]", "BIGINT");
                break;
            case "Boolean":
                C_ = V_.Replace("'", "").Replace("[AS_TAG]", "BIT");
                break;
            case "String":
                C_ = C_.Replace("[AS_TAG]", "VARCHAR(MAX)");
                break;
            case "DateTime":
                C_ = V_.Replace("[AS_TAG]", "DATETIME");
                break;
            // Add more cases as needed for other data types
            default:                
                break;
        }
  
        if (combo.SelectedItem != null)
        {
            if (combo.SelectedItem is System.Data.DataRowView)
            {
                DataRowView v = (DataRowView)combo.SelectedItem;
                Type dataType = v.Row[0].GetType();
                string dataTypeStr = dataType.ToString();
                // Assuming you want to get the value from the first column
                return C_.Replace("[AS_TAG]",v.Row[0].ToString());
            }
            else
            {
     
                return C_.Replace("[AS_TAG]", combo.SelectedItem.ToString());
            }
        }
        else if (combo.Items.Count > 0)
        {
            return combo.Items[0].ToString();
        }
        else return I_ + "0" + I_;
    }
    else if (ctrl is DateTimePicker)
    {
        DateTimePicker dateTime = ctrl as DateTimePicker;
        return dateTime.Value.ToString();
    }
    else if (ctrl is TextBox)
    {
        TextBox textBox = ctrl as TextBox;
        return textBox.Text;
    }

    return ""; // Default empty string if control type doesn't match any of the above
}


public DataSetContainer CallDynamicReturnTableRecords(string table, string displayCol, string whereClause)
{
    //string connectionString = "YourConnectionStringHere"; //Replace with your connection string.
    DataSetContainer container = new DataSetContainer();

    using (SqlConnection connection = new SqlConnection(this.connectionString))
    {
        try
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("Dynamic_ReturnTableRecords", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.Add("@Table", SqlDbType.VarChar, 150).Value = table;
                cmd.Parameters.Add("@DisplayColProposed", SqlDbType.VarChar, 150).Value = displayCol;
                if (!string.IsNullOrEmpty(whereClause))
                {
                    cmd.Parameters.Add("@Where", SqlDbType.NVarChar, -1).Value = whereClause;
                }
                else
                {
                    cmd.Parameters.Add("@Where", SqlDbType.NVarChar, -1).Value = DBNull.Value;
                }

                // Output parameter
                SqlParameter errParam = new SqlParameter("@Err_Msg", SqlDbType.VarChar, 100);
                errParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errParam);

                // Return value
                SqlParameter returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                // Fill the dataset
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(container.ds);

                // Fetch the output parameter and return value
                container.Err_Msg = cmd.Parameters["@Err_Msg"].Value.ToString();
                container.Return = (int)cmd.Parameters["@ReturnVal"].Value;

            }
        }
        catch (Exception ex)
        {
            // Handle exception
            container.Err_Msg = ex.Message;
        }
    }

    return container;
}



private int PopulateCombo(ComboBox combo, DataSet ds, string displayField)
{
    int ret = 1;  // success, 0 failure

    try
    {
        if (ds != null && ds.Tables.Count > 0)
        {
            combo.DataSource = ds.Tables[0];
            combo.DisplayMember = displayField;
            combo.ValueMember = displayField;  // assuming you want to use the same field for value, modify as needed
        }
        else
        {
            ret = 0;
        }
    }
    catch
    {
        ret = 0;  // On any exception, return failure
    }

    return ret;
}


private void addAdditionalControlOrUpdateExistingToPanel(Dictionary<string, string> metaData)
{
    List<ControlCreationAndBindingInfo> controlCreationInfo = this.getNewControlCreationInfroFromMetaData(metaData);
    addAdditionalControlOrUpdateExistingToPanel(controlCreationInfo);
}

private void addAdditionalControlOrUpdateExistingToPanel(ControlCreationAndBindingInfo controlCreationInfo)
{
    List<ControlCreationAndBindingInfo> List = new List<ControlCreationAndBindingInfo>();
    List.Add(controlCreationInfo);
    addAdditionalControlOrUpdateExistingToPanel(List);
}

private void addAdditionalControlOrUpdateExistingToPanel(List<ControlCreationAndBindingInfo> controlCreationInfo)
{
    
    // panelParameters is the Panel on the form where additional controls will be added.

    int yOffset = 10; // Starting offset
    int spacing = 10;
    int totalHeight = 0; // Total height of controls
    int ControlWidth = 200;
    // Create a dictionary to store existing controls by name
    Dictionary<string, Control> existingControls = new Dictionary<string, Control>();

    foreach (Control control in panelParameters.Controls)
    {
        if (control.Visible && (control is TextBox || control is DateTimePicker || control is ComboBox))
        {
            totalHeight += control.Height + spacing;

            // Add existing controls to the dictionary
            existingControls.Add(control.Name, control);
        }
    }

    // Subtract the last spacing value
    if (totalHeight > 0)
    {
        totalHeight -= spacing;
    }

    int bottomLocation = totalHeight;

    int i = 0; int height_tillLastControladded = bottomLocation - spacing;
    foreach (var controlInfo in controlCreationInfo)
    {
        i++;
        Control newControl = null;

        // Check if a control with the same name exists in the panel


        if (controlInfo.ControlType == ControlType.TEXT)
        {
            // Create a TextBox
            newControl = new TextBox();
        }
        else if (controlInfo.ControlType == ControlType.DATE)
        {
            // Create a DateTimePicker
            newControl = new DateTimePicker();
        }
        else if (controlInfo.ControlType == ControlType.COMBO)
        {
            // Create a ComboBox
            newControl = new ComboBox();
        }

        if (newControl != null)
        {
            if (existingControls.ContainsKey(controlInfo.ControlName))
            {
                Control existingControl = existingControls[controlInfo.ControlName];
                i--; // already exist so 
                // Check if the existing control type matches the desired type
                if ((controlInfo.ControlType == ControlType.TEXT && existingControl is TextBox) ||
                    (controlInfo.ControlType == ControlType.DATE && existingControl is DateTimePicker) ||
                    (controlInfo.ControlType == ControlType.COMBO && existingControl is ComboBox))
                {
                    i--;
                    // Control type matches, no need to add a new control, leave the existing one
                    continue;
                }
                else
                {
                    // Control type does not match, remove the existing control
                    // Set common properties for all controls
             //       newControl.Name = controlInfo.ControlName;
                    newControl.Top = existingControl.Top;
                    newControl.Left = existingControl.Left; // Adjust the left position as needed
                    newControl.Width = existingControl.Width; // Set the width as needed
                    newControl.Visible = existingControl.Visible;

                    panelParameters.Controls.Remove(existingControl);
                    newControl.Name = controlInfo.ControlName;
                }
            }else{

                Label lbl = new Label();
                this.panelParameters.Height += (newControl.Height + spacing);
                height_tillLastControladded += (newControl.Height + spacing);

                // Remove "@" and replace "_" with a space
                string friendlyArgName = controlInfo.ControlName.Replace("_"," ");
                lbl.Text = friendlyArgName;// +" (" + arg.Value + "):";
                lbl.Top = height_tillLastControladded;
                lbl.Left = 10;
                lbl.Width = 150;
                panelParameters.Controls.Add(lbl);

            // Set common properties for all controls
                newControl.Name = controlInfo.ControlName;
                newControl.Top = height_tillLastControladded;
                newControl.Left = lbl.Right + 10; ; // Adjust the left position as needed
                newControl.Width = ControlWidth; // Set the width as needed
                newControl.Visible = true;
            }

            // Add the control to the panel
            //this.panelParameters.Height -= spacing;
            panelParameters.BackColor = Color.LightGray; // Change to your desired lighter color

            panelParameters.Controls.Add(newControl);
            btnShowReport.Top =panelParameters.Top+ panelParameters.Height +  spacing;
            this.btnShowReport.Left = panelParameters.Width - this.btnShowReport.Width - spacing;

        }





    }
}



private void button2_Click(object sender, EventArgs e)
{

}

private void button2_Click_1(object sender, EventArgs e)
{
    if(UploadFile())MessageBox.Show("Successfully uploaded the file");
}

private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
{
    TreeNode selectedNode = e.Node;
    ControlCreationAndBindingInfo ctrlInfo = (ControlCreationAndBindingInfo)selectedNode.Tag;// this.GetControlCreationAndBindingInfoByControlName(selectedNode.Tag);
    if (ctrlInfo == null) return;
    if(ctrlInfo.control == null) return;
    MessageBox.Show("Selected Node Name: " + selectedNode.Text+" Ctrl="+ctrlInfo.control.Name);
    ctrlInfo.control.Focus();
}







// -- adding missing stored procedure 
    public bool AddStoredProcedureToDbIfNotFound(string storedProcedureName, string tsql_StoredProcedure_ToAddToDb)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the stored procedure already exists
                using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM sys.procedures WHERE name = @storedProcedureName", connection))
                {
                    checkCommand.Parameters.AddWithValue("@storedProcedureName", storedProcedureName);
                    int existingProcedureCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingProcedureCount == 0)
                    {
                        // Stored procedure doesn't exist, so add it
                        using (SqlCommand createCommand = new SqlCommand(tsql_StoredProcedure_ToAddToDb, connection))
                        {
                            createCommand.ExecuteNonQuery();
                        }

                        // Return true to indicate the stored procedure was added
                        return true;
                    }
                    else
                    {
                        // Stored procedure already exists
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions, such as database connection errors
            Console.WriteLine("Error: {"+ex.Message+"}");
            return false;
        }
    }


    string getReportsMetaData = @"create PROCEDURE [dbo].[getReportsMetaData]  
--ALTER PROCEDURE getReportsMetaData  
@ProcName VARCHAR(256)=null,--ARG1 NUMERIC,    
@Err_Msg varchar(100)=null output    
AS    
BEGIN     
    
SET @ProcName = trim(ISNULL(@ProcName,''))
SELECT 
    o.name AS ProcName,
    CASE
        WHEN CHARINDEX('START_REPORT_METADATA', m.definition) > 0 
             AND CHARINDEX('END_REPORT_METADATA', m.definition) > 0 THEN
            SUBSTRING(
                m.definition, 
                CHARINDEX('START_REPORT_METADATA', m.definition) + LEN('START_REPORT_METADATA'), 
                CHARINDEX('END_REPORT_METADATA', m.definition) - CHARINDEX('START_REPORT_METADATA', m.definition) - LEN('START_REPORT_METADATA')
            )
        ELSE NULL
    END AS MetadataContent,
(
    SELECT p.name + ' ' + t.name + 
           CASE WHEN t.name IN ('char', 'varchar', 'nchar', 'nvarchar', 'binary', 'varbinary') THEN
               '(' + 
                   CASE WHEN p.max_length = -1 THEN 'MAX' 
                        ELSE CAST(p.max_length AS VARCHAR(10)) 
                   END + ')'
           ELSE '' 
           END + 
           CASE WHEN p.has_default_value = 1 THEN ' = ' + CAST(p.default_value AS VARCHAR(100)) ELSE '' END + 
           CASE WHEN p.is_output = 1 THEN ' output' ELSE '' END + ','
    FROM sys.parameters p 
    JOIN sys.types t ON p.system_type_id = t.system_type_id
    WHERE p.object_id = o.object_id
    FOR XML PATH('')
) AS Arguments
FROM 
    sys.sql_modules m
JOIN 
    sys.objects o ON m.object_id = o.object_id
WHERE 
    o.type = 'P' 
    AND 
    (
    	(@ProcName='' AND o.name LIKE 'Report_%')
    	OR
    	(o.name= @ProcName) 
    
	)
     
 if @@Error!=0     
 begin    
  set @Err_Msg='Could Not Find Specified Record'    
  return 200    
 end    
 return 100    
END    
    ";



    public void CreateTableFilesIfNotPresent()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL command to create the "Files" table if it doesn't exist
                string createTableSQL = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Files')
                    BEGIN
                        CREATE TABLE Files (
                            FileCheckSum VARCHAR(256),
                            FILENAME NVARCHAR(256),
                            fileOfImage VARBINARY(MAX),
                            uploadDate DATETIME,
                            fileCreationDate DATETIME,
                            fileUpdatedDate DATETIME
                        )
                    END";

                using (SqlCommand command = new SqlCommand(createTableSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions, such as database connection errors
            Console.WriteLine("Error: {"+ex.Message+"}");
        }
    }



    public bool UploadFile()
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Calculate the checksum of the selected file
                string fileChecksum = CalculateFileChecksum(filePath);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the file with the same checksum exists in the database
                    string query = "SELECT COUNT(*) FROM Files WHERE FileCheckSum = @fileChecksum";
                    using (SqlCommand checkCommand = new SqlCommand(query, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@fileChecksum", fileChecksum);
                        int existingFileCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingFileCount == 0)
                        {
                            // File with the same checksum not found, so insert it
                            InsertFileToDatabase(filePath, fileChecksum, connection);
                            return true; // File uploaded
                        }
                        else
                        {
                            // File with the same checksum found, do not insert
                            return false; // File already exists
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions, such as database connection errors or file-related errors
            MessageBox.Show(ex.Message);
            Console.WriteLine("Error: {"+ex.Message+"}");
        }

        return false; // File upload failed
    }

    private string CalculateFileChecksum(string filePath)
    {
        using (FileStream fileStream = File.OpenRead(filePath))
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(fileStream);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
    }




        /*
    private void InsertFileToDatabase(string filePath, string fileChecksum, SqlConnection connection)
    {
        // Check if a file with the same name exists in the database
        string checkDuplicateSQL = "SELECT COUNT(*) FROM Files WHERE FILENAME = @fileName";

        using (SqlCommand checkDuplicateCommand = new SqlCommand(checkDuplicateSQL, connection))
        {
            checkDuplicateCommand.Parameters.AddWithValue("@fileName", Path.GetFileName(filePath));

            int fileCount = (int)checkDuplicateCommand.ExecuteScalar();

            if (fileCount > 0)
            {
                // A file with the same name exists, update it in the database
                string updateSQL = @"
                UPDATE Files
                SET FileCheckSum = @fileChecksum,
                    fileOfImage = @fileData,
                    uploadDate = @uploadDate,
                    fileCreationDate = @creationDate,
                    fileUpdatedDate = @updatedDate
                WHERE FILENAME = @fileName";

                using (SqlCommand updateCommand = new SqlCommand(updateSQL, connection))
                {
                    updateCommand.Parameters.AddWithValue("@fileChecksum", fileChecksum);
                    updateCommand.Parameters.AddWithValue("@fileName", Path.GetFileName(filePath));
                    updateCommand.Parameters.AddWithValue("@fileData", File.ReadAllBytes(filePath));
                    updateCommand.Parameters.AddWithValue("@uploadDate", DateTime.Now);
                    updateCommand.Parameters.AddWithValue("@creationDate", File.GetCreationTime(filePath));
                    updateCommand.Parameters.AddWithValue("@updatedDate", File.GetLastWriteTime(filePath));

                    updateCommand.ExecuteNonQuery();
                }
            }
            else
            {
                // Insert the new file into the database
                string insertSQL = @"
                INSERT INTO Files (FileCheckSum, FILENAME, fileOfImage, uploadDate, fileCreationDate, fileUpdatedDate)
                VALUES (@fileChecksum, @fileName, @fileData, @uploadDate, @creationDate, @updatedDate)";

                using (SqlCommand insertCommand = new SqlCommand(insertSQL, connection))
                {
                    insertCommand.Parameters.AddWithValue("@fileChecksum", fileChecksum);
                    insertCommand.Parameters.AddWithValue("@fileName", Path.GetFileName(filePath));
                    insertCommand.Parameters.AddWithValue("@fileData", File.ReadAllBytes(filePath));
                    insertCommand.Parameters.AddWithValue("@uploadDate", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@creationDate", File.GetCreationTime(filePath));
                    insertCommand.Parameters.AddWithValue("@updatedDate", File.GetLastWriteTime(filePath));

                    insertCommand.ExecuteNonQuery();
                }
            }
        }
    }
*/

    private void InsertFileToDatabase(string filePath, string fileChecksum, SqlConnection connection)
    {
        // Check if a file with the same name exists in the database
        string checkDuplicateSQL = "SELECT COUNT(*) FROM Files WHERE FILENAME = @fileName";

        using (SqlCommand checkDuplicateCommand = new SqlCommand(checkDuplicateSQL, connection))
        {
            checkDuplicateCommand.Parameters.AddWithValue("@fileName", Path.GetFileName(filePath));

            int fileCount = (int)checkDuplicateCommand.ExecuteScalar();

            if (fileCount > 0)
            {
                // A file with the same name exists, delete it from the database
                string deleteSQL = "DELETE FROM Files WHERE FILENAME = @fileName";

                using (SqlCommand deleteCommand = new SqlCommand(deleteSQL, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@fileName", Path.GetFileName(filePath));
                    deleteCommand.ExecuteNonQuery();
                }
            }
        }

        // Insert the new file into the database
        string insertSQL = @"
        INSERT INTO Files (FileCheckSum, FILENAME, fileOfImage, uploadDate, fileCreationDate, fileUpdatedDate)
        VALUES (@fileChecksum, @fileName, @fileData, @uploadDate, @creationDate, @updatedDate)";

        using (SqlCommand insertCommand = new SqlCommand(insertSQL, connection))
        {
            insertCommand.Parameters.AddWithValue("@fileChecksum", fileChecksum);
            insertCommand.Parameters.AddWithValue("@fileName", Path.GetFileName(filePath));
            insertCommand.Parameters.AddWithValue("@fileData", File.ReadAllBytes(filePath));
            insertCommand.Parameters.AddWithValue("@uploadDate", DateTime.Now);
            insertCommand.Parameters.AddWithValue("@creationDate", File.GetCreationTime(filePath));
            insertCommand.Parameters.AddWithValue("@updatedDate", File.GetLastWriteTime(filePath));

            insertCommand.ExecuteNonQuery();
        }
    }


   public string GetFile(string fileName, bool storedInCurrentDirectory)
    {
        string filePath = storedInCurrentDirectory
            ? Path.Combine(Environment.CurrentDirectory, fileName)
            : Path.Combine(Path.GetTempPath(), fileName);

        string checkSumOfExistingFileIfExists = GetFileChecksum(filePath);


        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the file with the same filename exists in the database
                string query = "SELECT FileCheckSum FROM Files WHERE FILENAME = @fileName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fileName", fileName);

                    object checksumFromDb = command.ExecuteScalar();

                    if (checksumFromDb != null && checksumFromDb != DBNull.Value)
                    {
                        // File with the same checksum exists in the database
                        if(checkSumOfExistingFileIfExists==checksumFromDb)return filePath;
                    }
                }

                // File not found locally or in the database, retrieve it from the database
                query = "SELECT FILENAME, fileOfImage FROM Files WHERE FILENAME = @fileName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fileName", fileName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] fileData = (byte[])reader["fileOfImage"];

                            // Save the file to the specified location
                            File.WriteAllBytes(filePath, fileData);

                            return filePath;
                        }
                        else
                        {
                            // File not found in the database
                            return null;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions, such as database connection errors or file-related errors
            Console.WriteLine("Error: {"+ex.Message+"}");
            return null;
        }
    }

    private string GetFileChecksum(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(fileStream);
                    return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                }
            }
            else
            {
                // File doesn't exist locally
                return "";
            }
        }
        catch (Exception)
        {
            // Handle any exceptions that may occur during checksum calculation
            return "";
        }
    }

    private void btnDebug(object sender, EventArgs e)
    {
        cmbReports.Items.Clear();
        frmMISC_Load(null, null);
    }

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}

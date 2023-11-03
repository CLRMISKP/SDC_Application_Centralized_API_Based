
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Data.SqlClient;


//USAGE
/*
             frmDbConn mfrmDbConn = new frmDbConn();
            string connectionString = mfrmDbConn.getConnectionStringFromConfig();
            if (connectionString == null)
            {
                mfrmDbConn.ShowDialog();
                if ((connectionString = mfrmDbConn.getConnectionStringFromConfig()) == null) { MessageBox.Show("Invalid Database"); return; };
            }
 */







    public partial class frmDbConn : Form
    {
        public bool bConnected = false;

        String CryptString = "sak1822";

        String ConnectionString = "bla bla";
        String Server = ".";
        String Database = "master";
        String User = "sa";
        String Password = "";
        bool bSecurity = true;

        public frmDbConn()
        {
            InitializeComponent();
        }



        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (pBoxBusy.InvokeRequired)
            {
                pBoxBusy.BeginInvoke((MethodInvoker)delegate
                {
                    pBoxBusy.Invalidate();
                });
            }
            else
            {
                pBoxBusy.Invalidate();
            }
        }

        Image gifImage = GenerateBusyImage();
        public Image BusyImage = null;
        private void frmDbConn_Load(object sender, EventArgs e)
        {
            if (BusyImage != null) this.pBoxBusy.Image = BusyImage;
            
            this.pBoxBusy.BringToFront();
            this.lblWait.BringToFront();
            pBoxBusy.Image = gifImage;
            ImageAnimator.Animate(gifImage, OnFrameChanged);
            pBoxBusy.Visible = false;


            // Save credentials to config file
            //SaveCredentialsToDbConfig();

            // Read credentials from config file
            ReadCredentialsFromDbConfig();

            //loadDatabaseCombos();
        }


        
        private DataSet FetchDatabaseData()
        {
            try
            {
                // Create a SqlConnection object and open the connection
                this.ConnectionString = getConnectionStringFromConfigFromCtrls();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Use a SqlCommand to execute a query that retrieves the names of all databases on the server
                    using (SqlCommand command = new SqlCommand("SELECT name FROM sys.databases", connection))
                    {
                        // Use a SqlDataAdapter to fill a DataSet with the query results
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            return dataSet;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null; // Return null in case of error
            }
        }




        /*
        private void loadDatabaseCombos()
        {
            try
            {
                // Create a SqlConnection object and open the connection
                this.ConnectionString = getConnectionStringFromConfigFromCtrls();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Use a SqlCommand to execute a query that retrieves the names of all databases on the server
                    using (SqlCommand command = new SqlCommand("SELECT name FROM sys.databases", connection))
                    {
                        // Use a SqlDataReader to read the results of the query
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Loop through the rows in the result set and add the database names to the ComboBox
                            while (reader.Read())
                            {
                               

                                if (cmbDatabases.InvokeRequired)
                                {
                                    cmbDatabases.Invoke((MethodInvoker)delegate
                                    {
                                        cmbDatabases.Items.Add(reader.GetString(0));
                                    });
                                }
                                else
                                {
                                    cmbDatabases.Items.Add(reader.GetString(0));
                                }
                            }
                        }
                    }
                }
                bConnected = true;
            }
            catch (Exception ex)
            {
                bConnected = false;
                
                //this.lblError.Visible = true;
                if(this.lblError.InvokeRequired)
                    this.lblError.Invoke((MethodInvoker)(() => lblError.Visible = true));
                else lblError.Visible = true;
              
            }
        }
        */
        /*
        private async Task loadDatabaseCombosAsync()
        {
            try
            {
                // Create a SqlConnection object and open the connection
                this.ConnectionString = getConnectionStringFromConfigFromCtrls();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();

                    // Use a SqlCommand to execute a query that retrieves the names of all databases on the server
                    using (SqlCommand command = new SqlCommand("SELECT name FROM sys.databases", connection))
                    {
                        // Use a SqlDataReader to read the results of the query
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            // Clear the existing items in the ComboBox
                            cmbDatabases.Items.Clear();

                            // Loop through the rows in the result set and add the database names to the ComboBox
                            while (await reader.ReadAsync())
                            {
                                // Update the UI control on the UI thread using Control.Invoke or Control.BeginInvoke if needed
                                cmbDatabases.Invoke((MethodInvoker)(() => cmbDatabases.Items.Add(reader.GetString(0))));
                            }
                        }
                    }
                }

                bConnected = true;
            }
            catch (Exception ex)
            {
                bConnected = false;
                this.lblError.Invoke((MethodInvoker)(() => lblError.Visible = true));
            }
        }
        */
        void SaveCredentialsToDbConfig()
        {

            CryptoSakGpt4 cr = new CryptoSakGpt4();
            NameValueCollection credentials = new NameValueCollection();
            credentials.Add("ConnectionString", ConnectionString);
            credentials.Add("Server", this.txtServerAddress.Text);
            //credentials.Add("Database", Database);
            if (cmbDatabases.Items.Count > 0 && cmbDatabases.SelectedIndex >= 0)
            {
                string selectedDatabase = cmbDatabases.SelectedItem.ToString();
                credentials.Add("Database", selectedDatabase);
            }
            else
            {
                credentials.Add("Database", string.Empty);
            }

            credentials.Add("User", this.txtUser.Text);
            credentials.Add("Password", this.txtPassword.Text);
            
            credentials.Add("bSecurity", this.chkIntegratedSecurity.Checked.ToString());

            using (StreamWriter sw = new StreamWriter("db.config"))
            {
                foreach (string key in credentials.Keys)
                {
//                    string encryptedValue = credentials[key];// cr.Encrypt(credentials[key], CryptString);
                    string encryptedValue =  cr.Encrypt(credentials[key], CryptString);
                    sw.WriteLine(key + ">" + encryptedValue);

                }
            }
        }


        public String getConnectionStringFromConfigFromCtrls()
        {


            if (this.txtServerAddress.InvokeRequired)
                this.txtServerAddress.Invoke((MethodInvoker)(() => Server = txtServerAddress.Text));
            else Server = txtServerAddress.Text;

            if (this.cmbDatabases.InvokeRequired)
                this.cmbDatabases.Invoke((MethodInvoker)(() => Database = cmbDatabases.Text));
            else Database = cmbDatabases.Text;

            if (this.txtUser.InvokeRequired)
                this.txtUser.Invoke((MethodInvoker)(() => User = txtUser.Text));
            else User = txtUser.Text;

            if (this.txtPassword.InvokeRequired)
                this.txtPassword.Invoke((MethodInvoker)(() => Password = txtPassword.Text));
            else Password = txtPassword.Text;

            
            if (this.chkIntegratedSecurity.InvokeRequired)
                this.chkIntegratedSecurity.Invoke((MethodInvoker)(() => bSecurity=this.chkIntegratedSecurity.Checked));
            else bSecurity=this.chkIntegratedSecurity.Checked;
            



            if (bSecurity)
                ConnectionString = "Server=" + Server + ";Integrated Security=SSPI;TrustServerCertificate=true;";

            else
                ConnectionString = string.Format("Server={0};Database={1};User ID={2};Password={3};Integrated Security={4};TrustServerCertificate=True;",
                                Server,
                                Database,
                                User,
                                Password,
                                bSecurity ? "True" : "False");
            return ConnectionString;
        }
        public String getConnectionStringFromConfig()
        {

            CryptoSakGpt4 cr = new CryptoSakGpt4();

            NameValueCollection credentials = new NameValueCollection();
            String CryptString = "sak1822";
            try
            {
                using (StreamReader sr = new StreamReader("db.config"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] keyValue = line.Split('>');
//                        string decryptedValue = keyValue[1];// cr.Decrypt(keyValue[1], CryptString);
                        string decryptedValue =  cr.Decrypt(keyValue[1], CryptString);
                        credentials.Add(keyValue[0], decryptedValue);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;// nothig to read             
            }


            ConnectionString = credentials["ConnectionString"];
            Server = credentials["Server"];
            Database = credentials["Database"];
            User = credentials["User"];
            Password = credentials["Password"];            
            bSecurity = bool.Parse(credentials["bSecurity"]);
            this.chkIntegratedSecurity.Checked = bSecurity;



            if (this.chkIntegratedSecurity.Checked)
                //ConnectionString = $"Server={Server};Database={Database};Integrated Security=SSPI;TrustServerCertificate=true;";
                ConnectionString = "Server=" + Server + ";Database=" + Database + ";Integrated Security=SSPI;TrustServerCertificate=true;";

            else
                ConnectionString = string.Format("Server={0};Database={1};User ID={2};Password={3};Integrated Security={4};TrustServerCertificate=True;",
                                Server,
                                Database,
                                User,
                                Password,
                                bSecurity ? "True" : "False");
            return ConnectionString;
        }

        void ReadCredentialsFromDbConfig()
        {

            String conStr = getConnectionStringFromConfig();

            this.txtServerAddress.Text = Server;
            this.txtPassword.Text = Password;
            this.txtUser.Text = User;
            this.cmbDatabases.Text = Database;
            this.chkIntegratedSecurity.Checked = bSecurity;
        }

        private void chkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            gpBxUsrPass.Visible = !this.chkIntegratedSecurity.Checked;

            int offset = gpBxUsrPass.Height + 10; // The distance to move the controls (10 is added for some extra padding)


            if (!chkIntegratedSecurity.Checked)
            {
                lblDatabase.Top += offset;
                cmbDatabases.Top += offset;
                btnFetchDbs.Top += offset;
                btnOK.Top += offset;
                this.Height += offset;
                
            }
            else
            {
                lblDatabase.Top -= offset;
                cmbDatabases.Top -= offset;
                btnFetchDbs.Top -= offset;
                btnOK.Top -= offset;
                this.Height -= offset;
                
            }
        }

        private void frmDbConn_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.lblError.Visible= false;
            SaveCredentialsToDbConfig();
        }





        private void txtServerAddress_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            bConnected = false;
        }

        private void chkIntegratedSecurity_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            bConnected = false;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            bConnected = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            bConnected = false;
        }

        private void cmbDatabases_TextChanged(object sender, EventArgs e)
        {
            
            //this.lblError.Invoke((MethodInvoker)(() => lblError.Visible = true));
        }

        private void cmbDatabases_Click(object sender, EventArgs e)
        {
            //loadDatabaseCombos();
        }




        private void btnFetchDbs_Click(object sender, EventArgs e)
        {
            // Show busy animation or perform any UI updates here
            this.pBoxBusy.Visible = true;
            this.lblWait.Visible = true;
            this.cmbDatabases.Items.Clear();

            DataSet result = FetchDatabaseData();

            // Process the result, update UI controls, etc.
            if (result != null)
            {
                // Update UI controls with the retrieved data
                DataTable dataTable = result.Tables[0];
                foreach (DataRow row in dataTable.Rows)
                {
                    string databaseName = row["name"].ToString();
                    cmbDatabases.Items.Add(databaseName);
                }

                bConnected = true;
                LoadOneOfDatabases(this.Database);
            }
            else
            {
                // Handle error case
                bConnected = false;
                lblError.Visible = true;
            }

            this.pBoxBusy.Visible = false;
            this.lblWait.Visible = false;
            // Hide busy animation or perform any UI updates here
        }



        private void LoadOneOfDatabases(string oneOfDatabases)
        {
            if (cmbDatabases.Items.Contains(oneOfDatabases))
            {
                cmbDatabases.SelectedItem = oneOfDatabases;
            }
            else if (cmbDatabases.Items.Count > 0)
            {
                cmbDatabases.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static Image GenerateBusyImage()
        {
            int diameter = 100; // Diameter of the circle
            Image img = new Bitmap(diameter, diameter);

            using (Graphics g = Graphics.FromImage(img))
            {
                // Draw red circle
                g.FillEllipse(Brushes.Red, 0, 0, diameter, diameter);

                // Set font and formatting
                Font font = new Font("Arial", 20, FontStyle.Bold);
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // Draw 'BUSY' text
                g.DrawString("BUSY", font, Brushes.White, new RectangleF(0, 0, diameter, diameter), format);
            }

            return img;
        }


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.gpBxUsrPass = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWait = new System.Windows.Forms.Label();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnFetchDbs = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pBoxBusy = new System.Windows.Forms.PictureBox();
            this.gpBxUsrPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBusy)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.FormattingEnabled = true;
            this.cmbDatabases.Location = new System.Drawing.Point(88, 183);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(164, 23);
            this.cmbDatabases.TabIndex = 0;
            this.cmbDatabases.TextChanged += new System.EventHandler(this.cmbDatabases_TextChanged);
            this.cmbDatabases.Click += new System.EventHandler(this.cmbDatabases_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(2, 186);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(60, 15);
            this.lblDatabase.TabIndex = 1;
            this.lblDatabase.Text = "Databases";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server";
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(88, 9);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(219, 23);
            this.txtServerAddress.TabIndex = 2;
            this.txtServerAddress.Text = ".";
            this.txtServerAddress.TextChanged += new System.EventHandler(this.txtServerAddress_TextChanged);
            // 
            // gpBxUsrPass
            // 
            this.gpBxUsrPass.Controls.Add(this.txtPassword);
            this.gpBxUsrPass.Controls.Add(this.label4);
            this.gpBxUsrPass.Controls.Add(this.txtUser);
            this.gpBxUsrPass.Controls.Add(this.label3);
            this.gpBxUsrPass.Location = new System.Drawing.Point(12, 73);
            this.gpBxUsrPass.Name = "gpBxUsrPass";
            this.gpBxUsrPass.Size = new System.Drawing.Size(313, 100);
            this.gpBxUsrPass.TabIndex = 3;
            this.gpBxUsrPass.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.FormattingEnabled = true;
            this.txtPassword.Location = new System.Drawing.Point(76, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(219, 23);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pass";
            // 
            // txtUser
            // 
            this.txtUser.FormattingEnabled = true;
            this.txtUser.Location = new System.Drawing.Point(76, 16);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(219, 23);
            this.txtUser.TabIndex = 0;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "User";
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWait.ForeColor = System.Drawing.Color.IndianRed;
            this.lblWait.Location = new System.Drawing.Point(53, 86);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(217, 21);
            this.lblWait.TabIndex = 5;
            this.lblWait.Text = "WAIT LOADING DATABASEs";
            this.lblWait.Visible = false;
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(12, 48);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(125, 19);
            this.chkIntegratedSecurity.TabIndex = 4;
            this.chkIntegratedSecurity.Text = "Integrated Security";
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkIntegratedSecurity_CheckedChanged);
            this.chkIntegratedSecurity.TextChanged += new System.EventHandler(this.chkIntegratedSecurity_TextChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.IndianRed;
            this.lblError.Location = new System.Drawing.Point(145, 43);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(174, 21);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Connection Not Valid";
            // 
            // btnFetchDbs
            // 
            this.btnFetchDbs.Location = new System.Drawing.Point(258, 186);
            this.btnFetchDbs.Name = "btnFetchDbs";
            this.btnFetchDbs.Size = new System.Drawing.Size(75, 23);
            this.btnFetchDbs.TabIndex = 6;
            this.btnFetchDbs.Text = "Get DBs";
            this.btnFetchDbs.UseVisualStyleBackColor = true;
            this.btnFetchDbs.Click += new System.EventHandler(this.btnFetchDbs_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(125, 212);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 27);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pBoxBusy
            // 
            //this.pBoxBusy.Image = global::DbConn_Templet.Properties.Resources.busy03;
            this.pBoxBusy.Location = new System.Drawing.Point(101, -16);
            this.pBoxBusy.Name = "pBoxBusy";
            this.pBoxBusy.Size = new System.Drawing.Size(128, 128);
            this.pBoxBusy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBoxBusy.TabIndex = 8;
            this.pBoxBusy.TabStop = false;
            // 
            // frmDbConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 243);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnFetchDbs);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.chkIntegratedSecurity);
            this.Controls.Add(this.gpBxUsrPass);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.pBoxBusy);
            this.Controls.Add(this.lblWait);
            this.Name = "frmDbConn";
            this.Text = "Connect To Db";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDbConn_FormClosing);
            this.Load += new System.EventHandler(this.frmDbConn_Load);
            this.gpBxUsrPass.ResumeLayout(false);
            this.gpBxUsrPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBusy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbDatabases;
        private Label lblDatabase;
        private Label label2;
        private TextBox txtServerAddress;
        private System.Windows.Forms.GroupBox gpBxUsrPass; 
        private ComboBox txtPassword;
        private Label label4;
        private ComboBox txtUser;
        private Label label3;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private Label lblError;
        private Button btnFetchDbs;
        private Button btnOK;
        private PictureBox pBoxBusy;
        private Label lblWait;
    }


    class CryptoSakGpt4
    {
        public bool bEleminate_Key_management = true;
        // Usage:
        // string encryptedPassword = DAPICredentialStorage.SaveCredentialDAP("mySecretPassword");
        // string retrievedPassword = DAPICredentialStorage.GetCredentialDAP(encryptedPassword);

        public string Encrypt(string plainText, string key)
        {
           using (Aes aes = Aes.Create())
            {
                aes.Key = GetHashedKey(key);
                aes.IV = new byte[aes.BlockSize / 8];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText, string key)
        {

            if (!IsBase64String(cipherText))
            {
                throw new ArgumentException("The input cipherText is not a valid Base64-encoded string.");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = GetHashedKey(key);
                aes.IV = new byte[aes.BlockSize / 8];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        private bool IsBase64String(string value)
        {
            value = value.Trim();
            if ((value.Length % 4) != 0)
            {
                return false;
            }

            try
            {
                Convert.FromBase64String(value);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        private byte[] GetHashedKey(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] hashedKey = sha256.ComputeHash(keyBytes);
                return hashedKey.Take(32).ToArray(); // Take 32 bytes (256 bits) for the AES key
            }
        }


    }









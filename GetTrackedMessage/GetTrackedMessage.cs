using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.BizTalk;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Operations;
using System.Reflection;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections;


namespace Datacom.GetTrackedMessage
{
    /// <summary>
    /// Thiago Almeida - http://connectedthoughts.wordpress.com
    /// Test application to retrieve messages from BizTalk 2006 Tracking database
    /// http://connectedthoughts.wordpress.com/2008/04/02/3-ways-of-programatically-extracting-a-message-body-from-the-biztalk-tracking-database/
    /// </summary>
    
    public partial class GetTrackedMessage : Form
    {
        public GetTrackedMessage()
        {
            InitializeComponent();
            cboGetType.SelectedIndex = 0;
        }

        private void btnGetMessage_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
            txtMessage.Refresh();
            Guid messageGuid;
            try
            {
                messageGuid = new Guid(txtGuid.Text);
            }
            catch (Exception exGuid)
            { 
                txtMessage.Text = "Please enter a valid Guid. Error: " + exGuid.Message;
                return;
            }

            switch(cboGetType.SelectedIndex)
            {
                case 0:
                    txtMessage.Text = GetMessageWithOperations(messageGuid);
                    break;
                case 1:
                    txtMessage.Text = GetMessageWithSQL(messageGuid);
                    break;
                case 2:
                    txtMessage.Text = GetMessageWithWMI(messageGuid);
                    break;
                default:
                    break;
            }
        }
        
        //Retrieves the message using the operations DLL - Add Microsofr.BizTalk.Operations.dll to references
        //Doesn't work for Biztalk 2004
        public string GetMessageWithOperations(Guid MessageInstanceId)
        {
            try
            {
                
                TrackingDatabase dta = new TrackingDatabase(txtTrackingDBServer.Text, txtTrackingDBName.Text);

                BizTalkOperations operations = new BizTalkOperations();
                
                IBaseMessage message = operations.GetTrackedMessage(MessageInstanceId, dta);
                string body = string.Empty;
                using (StreamReader streamReader = new StreamReader(message.BodyPart.Data))
                {
                    body = streamReader.ReadToEnd();
                }
                
                return body;

                 
            }
            catch (Exception exOp)
            {
                return "Failed to get message with id " + MessageInstanceId.ToString() + " from tracking database: " + exOp.Message;
            }
        }

        //Calls BizTalk stored procedure to retrieve compressed message and decompresses it
        public string GetMessageWithSQL(Guid MessageInstanceId)
        {
            try
            {
                //Connection to DTA database on localhost
                SqlConnection con = new SqlConnection("Data Source=" + txtTrackingDBServer.Text + ";Initial Catalog=" + txtTrackingDBName.Text + ";Integrated Security=True");
                string message = "";

                try
                {

                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;

                    //Build execution of stored procedure bts_GetTrackedMessageParts
                    cmd.CommandText = "bts_GetTrackedMessageParts";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter guidParameter = new SqlParameter("@uidMsgID", SqlDbType.UniqueIdentifier);
                    guidParameter.Value = MessageInstanceId;
                    cmd.Parameters.Add(guidParameter);
                    cmd.Connection = con;

                    con.Open();

                    reader = cmd.ExecuteReader();

                    //Get the reader to retrieve the data
                    while (reader.Read())
                    {
                        //Use memory stream and reflection to get the data
                        SqlBinary binData = new SqlBinary((byte[])reader["imgPart"]);
                        MemoryStream stream = new MemoryStream(binData.Value);
                        Assembly pipelineAssembly = Assembly.LoadFrom(string.Concat(@"C:\Program Files\Microsoft BizTalk Server 2006", @"\Microsoft.BizTalk.Pipeline.dll"));
                        Type compressionStreamsType = pipelineAssembly.GetType("Microsoft.BizTalk.Message.Interop.CompressionStreams", true);
                        StreamReader st = new StreamReader((Stream)compressionStreamsType.InvokeMember("Decompress", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, new object[] { (object)stream }));
                        message = st.ReadToEnd();
                    }
                }
                finally
                {
                    con.Close();
                }

                return message;

            }
            catch (Exception exSQL)
            {
                return "Failed to get message with id " + MessageInstanceId.ToString() + " from tracking database: " + exSQL.Message;
            }
        }

        //Uses WMI to save the tracked message out to a file folder using MSBTS_TrackedMessageInstance class
        //Files saved to disk aren't being deleted afterwards...
        public string GetMessageWithWMI(Guid MessageInstanceId)
        {
            try
            {

                // Construct full WMI path to the MSBTS_TrackedMessageInstance using the message guid (NOTE: MessageInstanceID string value must be enclosed in {} curly brackets)
                string strInstanceFullPath = "\\\\.\\root\\MicrosoftBizTalkServer:MSBTS_TrackedMessageInstance.MessageInstanceID='{" + MessageInstanceId.ToString() + "}'";

                // Load the MSBTS_TrackedMessageInstance
                ManagementObject objTrackedSvcInst = new ManagementObject(strInstanceFullPath);

                // Invoke "SaveToFile" method to save the message out into the specified folder
                objTrackedSvcInst.InvokeMethod("SaveToFile", new object[] {Application.StartupPath});

                //Get all files in the directory starting with this messageid
                string[] files = Directory.GetFiles(Application.StartupPath, "{" + MessageInstanceId.ToString() + "*.*");

                string message = "";
                foreach (string file in files)
                { 
                    if (file.EndsWith(".out"))
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            message = sr.ReadToEnd();
                        }
                    }
                }

                foreach (string file in files)
                {
                    System.IO.File.Delete(file);
                }

                if (files.Length == 0)
                {
                    throw new Exception("No files found on folder that match the GUID");
                }

                return message;

            }
            catch (Exception exWMI)
            {
                return "Failed to save tracked message with id " + MessageInstanceId.ToString() + " into folder " + Application.StartupPath + ": " + exWMI.Message;
            }
        }

    }
}
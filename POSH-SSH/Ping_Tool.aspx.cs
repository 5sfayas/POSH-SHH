using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management.Automation;
using System.Text;

namespace Final_CloudApp
{
    public partial class Ping_Tool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //****Function start*****************
        public void ping(string cloud, string parameter)
        {

            //Location of the script
            string script = @cloud;
            TextBox3.Text = string.Empty;

            // Initialize PowerShell engine
            var shell = PowerShell.Create();

            // Add the script to the PowerShell object
            shell.Commands.AddCommand(script, false);

            //Name of the parameter as in the script
            shell.Commands.AddParameter("com1", source); //Parameter-0
            shell.Commands.AddParameter("com2", dest);//Parameter-1

            // Execute the script
            var results = shell.Invoke();

            // Note : use |out-string for console-like output
            if (results.Count > 0)
            {
                // We use a string builder ton create our result text
                var builder = new StringBuilder();

                foreach (var psObject in results)
                {
                    // Convert the Base Object to a string and append it to the string builder.
                    // Add \r\n for line breaks
                    builder.Append(psObject.BaseObject.ToString() + "\r\n");
                }

                // Encode the string in HTML (prevent security issue with 'dangerous' caracters like < >
                // TextBox2.Text = Server.HtmlEncode(builder.ToString());
                TextBox3.Text = (builder.ToString());
            }

        }
        //Function Finish

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                ping("C:\\D drive\\Ransara\\aws_ping.ps1", TextBox2.Text);
            
        }
    }
}
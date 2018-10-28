using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAppsMedGithub
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void UploadFile(object sender, EventArgs e)
        {
            string path = Server.MapPath("/Bilder/");
            string fileName = FileUpload1.PostedFile.FileName;
            FileUpload1.SaveAs(path + fileName);
            Response.Write("Fil lastet til server");
        }
    }
}
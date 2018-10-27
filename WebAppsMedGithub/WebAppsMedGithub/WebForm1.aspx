<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppsMedGithub.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <p>Velg fil: <asp:FileUpload runat="server" ID="FileUpload1" /></p>
            <asp:Button ID="btnSubmit" OnClick="UploadFile" runat="server" Text="Upload" />
            </div>
            <img src="Bilder/1111.jpg" />
        </div>
    </form>
</body>
</html>

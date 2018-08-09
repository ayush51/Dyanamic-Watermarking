<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FooTheory.iTextSharpExample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Option 1: <br />
        Print This Text To The PDF: <asp:TextBox runat="server" ID="pdfTextTextBox" Text="NOT FOR SALE" /> <asp:Button Text="Generate PDF Now" runat="server" ID="generatedPdfButton" OnClick="generatedPdfButton_Click" />
        <pre></pre>
        
<%--        Option 2: <br />
        What's your name? : <asp:TextBox runat="server" ID="nameTextBox" Text="Donn"></asp:TextBox> <asp:Button runat="server" ID="generateNameCustomizedPdf" OnClick="generateNameCustomizedPdf_Click" Text="Generate Name Customized PDF" />--%>
    </div>
    </form>
</body>
</html>

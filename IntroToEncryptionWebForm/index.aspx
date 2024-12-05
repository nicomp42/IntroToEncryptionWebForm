<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="IntroToEncryptionWebForm.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="tblDemo" runat="server" BorderStyle="Groove" BorderWidth="2px" >
                <asp:TableRow BorderStyle="Groove" BorderWidth="2px" >
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Label ID="lblEncryptPrompt" runat="server" Text="Enter a word to encrypt"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:TextBox ID="txtEncrypt" runat="server" Width="400px" TextMode="MultiLine" ></asp:TextBox>
                        <br/>
                        <asp:TextBox ID="txtEncryptResult" runat="server" Text=""  Width="400px" BackColor="WhiteSmoke"  TextMode="MultiLine" Enabled="False"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Button ID="cmdEncrypt" runat="server" OnClick="cmdEncrypt_Click" Text="Encrypt" type="button" class="btn btn-primary" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow> <asp:TableCell></asp:TableCell>  </asp:TableRow>
                <asp:TableRow BorderStyle="Groove" BorderWidth="2px">
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Label ID="lblDecryptPrompt" runat="server" Text="Enter a word to decrypt"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:TextBox ID="txtDecrpyt" runat="server" Width="400px" TextMode="MultiLine" ></asp:TextBox>
                        <br/>
                        <asp:TextBox ID="txtDecryptResult" runat="server" Text=""  Width="400px" BackColor="WhiteSmoke" TextMode="MultiLine" Enabled="False"> </asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Button ID="cmdDecrypt" runat="server" Text="Decrypt" OnClick="cmdDecrypt_Click" type="button" class="btn btn-primary" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow> <asp:TableCell> <asp:Label ID="lblSeperator" runat="server" Text="      " BackColor ="Wheat"></asp:Label> </asp:TableCell>  </asp:TableRow>
                <asp:TableRow BorderStyle="Groove" BorderWidth="2px">
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Label ID="lblHashPrompt" runat="server" Text="Enter a word to hash"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:TextBox ID="txtHash" runat="server" Width="400px" TextMode="MultiLine" ></asp:TextBox>
                        <br/>
                        <asp:TextBox ID="txtHashResult" runat="server" Text=""  Width="400px" BackColor="WhiteSmoke" TextMode="MultiLine" Enabled="False"> </asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Button ID="cmdHash" runat="server" Text="Hash" OnClick="cmdHash_Click" type="button" class="btn btn-primary" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow> <asp:TableCell> <asp:Label ID="lblSeperator01" runat="server" Text="      " BackColor ="Wheat"></asp:Label> </asp:TableCell>  </asp:TableRow>
                <asp:TableRow BorderStyle="Groove" BorderWidth="2px">
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Label ID="lblHashLookupPrompt" runat="server" Text="Enter a hash to look up in the hashed dictionary"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:TextBox ID="txtHashedString" runat="server" Width="400px" TextMode="MultiLine" ></asp:TextBox>
                        <br/>
                        <asp:TextBox ID="txtHashLookupResult" runat="server" Text=""  Width="400px" BackColor="WhiteSmoke" TextMode="MultiLine" Enabled="False"> </asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell BorderStyle="Groove" BorderWidth="2px">
                        <asp:Button ID="cmdLookUpHashedString" runat="server" Text="Look Up" OnClick="cmdLookUpHashedString_Click" type="button" class="btn btn-primary" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow> <asp:TableCell> <asp:Label ID="lblSeperator02" runat="server" Text="      " BackColor ="Wheat"></asp:Label> </asp:TableCell>  </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                    </asp:TableCell>
                    <asp:TableCell>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="cmdCheck" runat="server" Text="Check" type="button" class="btn btn-primary" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell>
                        <asp:Label runat="server" ID="lblStatus"></asp:Label>
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>

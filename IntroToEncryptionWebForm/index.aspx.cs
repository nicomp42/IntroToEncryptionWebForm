using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntroToEncryptionWebForm
{
    public partial class index : System.Web.UI.Page
    {
        static private EncryptDecrypt myEncryptDecrypt;
        protected void Page_Load(object sender, EventArgs e)
        {
            // This method runs when the page loads into the browser or it is refreshed by the end-user
            if (!IsPostBack)
            {
                // This runs only on the first page load event, not page refresh events
                myEncryptDecrypt = new EncryptDecrypt();
                lblStatus.Text = myEncryptDecrypt.englishWords.Count.ToString() + " english words loaded.";
                lblStatus.Text += "<br />" + myEncryptDecrypt.encryptedWords.Count.ToString() + " words encrypted.";
                lblStatus.Text += "<br />" + myEncryptDecrypt.hashedWords.Count.ToString() + " words hashed.";
            }
        }

        protected void cmdEncrypt_Click(object sender, EventArgs e)
        {
            txtEncryptResult.Text = myEncryptDecrypt.encryptWord(txtEncrypt.Text);
        }

        protected void cmdDecrypt_Click(object sender, EventArgs e)
        {
            txtDecryptResult.Text = myEncryptDecrypt.decryptWord(Convert.FromBase64String(txtDecrpyt.Text)); 
        }

        protected void cmdHash_Click(object sender, EventArgs e)
        {
            String myString = txtHash.Text;    
            txtHashResult.Text = EncryptDecrypt.CalculateSHA256Hash(myString);

        }

        protected void cmdLookUpHashedString_Click(object sender, EventArgs e)
        {
            txtHashLookupResult.Text = myEncryptDecrypt.lookupHashedString(txtHashedString.Text);
        }
    }
}
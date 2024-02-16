using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    public partial class IPCamWeb : Form
    {
        public string username;
        public string password;
        public string ipaddress;
        int i = 0;
        public IPCamWeb()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        public IPCamWeb(string username,string password,string ipaddress)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.ipaddress = ipaddress;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            FillFormAndSubmit();
            webBrowser1.Document.Window.ScrollTo(200, 100);
            var vid = webBrowser1.Document.GetElementById("canvas");
            ++i;
           // MessageBox.Show(i.ToString());
            if (vid != null && i>=4)
            {
                HtmlDocument document = webBrowser1.Document;

                // Execute JavaScript to modify the style of elements on the page
                document.InvokeScript("execScript", new object[] {
                @"
                var elements = document.getElementsByTagName('*');
                for (var i = 0; i < elements.length; i++) {
                    var element = elements[i];
                    if (element.id !== 'canvas' ) {
                        element.style.hidden = 'true';
                    }
                }
                "
            });
            }
             
           
        }

        private void IPCamWeb_Load(object sender, EventArgs e)
        {
             webBrowser1.Navigate("http://"+ipaddress+"/");
           // webBrowser1.Navigate("http://192.168.100.70/");
        }
        private void FillPassword()
        {
            var passwordInputElement = webBrowser1.Document.GetElementById("login_psw");

            if (passwordInputElement != null)
            {
                // Set the value of the password field
                passwordInputElement.SetAttribute("value", password);

                // Create and execute a JavaScript code snippet to dispatch events
                var script = @"
            var inputEvent = document.createEvent('Event');
            inputEvent.initEvent('input', true, true);
            document.getElementById('login_psw').dispatchEvent(inputEvent);

            var changeEvent = document.createEvent('Event');
            changeEvent.initEvent('change', true, true);
            document.getElementById('login_psw').dispatchEvent(changeEvent);

            var blurEvent = document.createEvent('Event');
            blurEvent.initEvent('blur', true, true);
            document.getElementById('login_psw').dispatchEvent(blurEvent);
        ";

                webBrowser1.Document.InvokeScript("execScript", new object[] { script, "JavaScript" });
            }
        }

        private void Fillusername()
        {
            var usernameinputField = webBrowser1.Document.GetElementById("login_user");

            if (usernameinputField != null)
            {
                // Set the value of the password field
                usernameinputField.SetAttribute("value", username);

                // Create and execute a JavaScript code snippet to dispatch events
                var script = @"
            var inputEvent = document.createEvent('Event');
            inputEvent.initEvent('input', true, true);
            document.getElementById('login_user').dispatchEvent(inputEvent);

            var changeEvent = document.createEvent('Event');
            changeEvent.initEvent('change', true, true);
            document.getElementById('login_user').dispatchEvent(changeEvent);

            var blurEvent = document.createEvent('Event');
            blurEvent.initEvent('blur', true, true);
            document.getElementById('login_user').dispatchEvent(blurEvent);
        ";

                webBrowser1.Document.InvokeScript("execScript", new object[] { script, "JavaScript" });
            }
        }
        private void ClickSubmitButton()
        {
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName("a");

            foreach (HtmlElement element in elements)
            {
                string classAttribute = element.GetAttribute("class");
                string titleAttribute = element.GetAttribute("title");

                // if (classAttribute == "u-button fn-width80" && titleAttribute == "Login")
                // {
                //    element.InvokeMember("click");
                // break; // Assuming you want to click the first matching element, you can remove this line if you want to click all matching elements
                //}

                if (titleAttribute == "Login")
                {
                    element.InvokeMember("click");
                }
                int viewportHeight = webBrowser1.Height;
                HtmlDocument document = webBrowser1.Document; // Replace webBrowser1 with the actual name of your WebBrowser control.
                int contentHeight = document.Body.ScrollRectangle.Height;
                int y = (contentHeight - viewportHeight) / 2;
                y = (70 * contentHeight) / 100;
                //webBrowser1.Document.Window.ScrollTo(200, 100);
            }
        }
        public void FillFormAndSubmit()
        {
            // Find the input field element by its ID
            var usernameinputField = webBrowser1.Document.GetElementById("login_user");
            var passwordinputField = webBrowser1.Document.GetElementById("login_psw");

            // Fill the input field with a value
            if (usernameinputField != null)
            {
                usernameinputField.SetAttribute("value", username);
            }
            if (passwordinputField != null)
            {
                //passwordinputField.SetAttribute("type", "text");
                passwordinputField.SetAttribute("value", password);
            }
            FillPassword();
            Fillusername();
            ClickSubmitButton();
            hidenavbar();
        }
        public void hidenavbar()
        {
            HtmlDocument document = webBrowser1.Document;

            // Execute JavaScript to modify the style of elements on the page
            document.InvokeScript("execScript", new object[] {
                @"
                var elements = document.getElementsByClassName('main-head');
                var telements = document.getElementsByClassName('main-top');
                var uelements = document.querySelectorAll('[class=""u-tab main""]');

                if(elements.length > 0)
                {
                        var element = elements[0];
                        element.style.display = 'none';
                        element.style.height='0%';
                        
                }
 
               if (telements.length > 0) {
                  var telement = telements[0];
                   telement.style.display = 'none';
                    
                    telement.style.height='0px';
                    telement.style.width='0px';
                    telement.style.margin='0px';
                  }

                for (var i = 0; i < uelements.length; i++) {
                        var uelement = uelements[i];
                            uelement.style.display='none';
                            
                            uelement.style.height='0px';
                           uelement.style.width='0px';
                            uelement.style.margin='0px';                   
                }

               
                "
            });


        }

        public void CaptureScreenshot()
        {
            try
            {
                Rectangle bounds = webBrowser1.Bounds; // Get the bounds of the WebBrowser control
                string fileName = "image_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg"; // add timestamp to file name
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), fileName); // set default file path

                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    webBrowser1.DrawToBitmap(bitmap, new Rectangle(0, 0, bounds.Width, bounds.Height)); // Draw the control to the bitmap

                    // Convert the Bitmap to an Image
                    Image image = Image.FromHbitmap(bitmap.GetHbitmap());

                    // Save the image to a file
                    image.Save(filePath, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Bilgin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechRecognitionEngine recoEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speechSyn = new SpeechSynthesizer();
        bool izin;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            bilginrobot_ayarlari();
            izin = true;
            recoEngine.RecognizeAsync();
        }
        void bilginrobot_ayarlari()
        {
            string[] ihtimaller = { "Merhaba", "Googleyi aç" , "Facebooka gir" ,  "Youtubeye gir" , "Müslüm baba aç" , "Kapat" , "Merhaba yaz" };
            Choices seçenekler = new Choices(ihtimaller);
            Grammar grammer = new Grammar(new GrammarBuilder(seçenekler));
            recoEngine.LoadGrammar(grammer);
            recoEngine.SetInputToDefaultAudioDevice();
            recoEngine.SpeechRecognized += ses_tanıdığında;
        }
   
        private void ses_tanıdığında(object sender, SpeechRecognizedEventArgs e)
        {
            if (izin == true)
            {
                pictureBox1.Visible = true;
                izin = false;

                if (e.Result.Text == "Merhaba")
                {
                    speechSyn.SpeakAsync("Hello, at your services bay bilgin works");
                }

                if (e.Result.Text == "Googleyi aç")
                {
                    speechSyn.SpeakAsync("Okey, a will ethernet start now.");
                    System.Diagnostics.Process.Start("C://Program Files (x86)//Google//Chrome//Application//chrome.exe");
                }

                if (e.Result.Text == "Facebooka gir")
                {
                    System.Diagnostics.Process.Start("www.facebook.com/");
                }

                if (e.Result.Text == "Youtubeye gir")
                {
                    System.Diagnostics.Process.Start("www.youtube.com");
                }

                if (e.Result.Text == "Kapat")
                {
                    SendKeys.Send("{^} + {W}");
                }

                if (e.Result.Text == "Merhaba yaz")
                {
                    SendKeys.Send("Merhaba + {ENTER}");
                }

                if (e.Result.Text == "Müslüm baba aç")
                {
                    System.Diagnostics.Process.Start("www.youtube.com/watch?v=0hQCKkqmDlw");
                }
            }
        }
    }
}

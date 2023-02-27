using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Microsoft.Win32;


namespace Windows_Cores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            consultar();
            UltimaCorSelecionada();
        }

        string versaoAtual = "3";           // Controle de versão para atualização

        int AppsUseLightTheme;              // Modo de aplicativo padrão
        int ColorPrevalence_iniciar;        // Iniciar, barra de tarefas e central de ações
        int EnableTransparency;             // Efeitos de Tranparência
        int SystemUsesLightTheme;           // Modo padrão do Windows

        int ColorPrevalence;                // Barras de títulos e bordas da janela
        int AccentColor;                    // Cor


        private ColorDialog selecionarCor;  // + Cor personalizada

        private Button ultimoBotao;         // Ultima cor selecionada


        private void consultar()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            AppsUseLightTheme =         (int)key.GetValue("AppsUseLightTheme");            
            ColorPrevalence_iniciar =   (int)key.GetValue("ColorPrevalence");
            EnableTransparency =        (int)key.GetValue("EnableTransparency");
            SystemUsesLightTheme =      (int)key.GetValue("SystemUsesLightTheme");
            key.Close();

            RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM", true);
            ColorPrevalence =           (int)key2.GetValue("ColorPrevalence");
            AccentColor =               (int)key2.GetValue("AccentColor");            
            key2.Close();

            _ = AppsUseLightTheme == 1 ? radioButton_AplicativosClaro.Checked = true : radioButton_AplicativosClaro.Checked = false;
            _ = AppsUseLightTheme == 1 ? radioButton_AplicativosEscuro.Checked = false : radioButton_AplicativosEscuro.Checked = true;

            _ = ColorPrevalence ==  1 ? checkBox_MostrarBarrasBorda.Checked = true : checkBox_MostrarBarrasBorda.Checked = false;
            _ = EnableTransparency == 1 ? checkBox_EfeitoTransparencia.Checked = true : checkBox_EfeitoTransparencia.Checked = false;

            _ = SystemUsesLightTheme == 1 ? radioButton_WindowsClaro.Checked = true : radioButton_WindowsClaro.Checked = false;
            _ = SystemUsesLightTheme == 1 ? radioButton_WindowsEscuro.Checked = false : radioButton_WindowsEscuro.Checked = true;

            _ = ColorPrevalence_iniciar == 1 ? checkBox_MostrarIniciar.Checked = true : checkBox_MostrarIniciar.Checked = false;
        }


        // RadioButton's
        private void radioButton_WindowsClaro_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            key.SetValue("SystemUsesLightTheme", 1);
            key.Close();
        }

        private void radioButton_WindowsEscuro_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            key.SetValue("SystemUsesLightTheme", 0);
            key.Close();
        }

        private void radioButton_AplicativosClaro_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            key.SetValue("AppsUseLightTheme", 1);
            key.Close();
        }

        private void radioButton_AplicativosEscuro_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            key.SetValue("AppsUseLightTheme", 0);
            key.Close();
        }

        private void checkBox_EfeitoTransparencia_CheckedChanged(object sender, EventArgs e)
        {
            int EfeitoTransparencia = checkBox_EfeitoTransparencia.Checked ? 1 : 0;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            key.SetValue("EnableTransparency", EfeitoTransparencia);
            key.Close();
        }

        private void checkBox_Iniciar_CheckedChanged(object sender, EventArgs e)
        {
            int inicio = checkBox_MostrarIniciar.Checked ? 1 : 0;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
            key.SetValue("ColorPrevalence", inicio);
            key.Close();

            DWM.Refresh();
        }

        private void checkBox_BarrasBorda_CheckedChanged(object sender, EventArgs e)
        {
            int BarraBorda = checkBox_MostrarBarrasBorda.Checked ? 1 : 0;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM", true);
            key.SetValue("ColorPrevalence", BarraBorda);
            key.Close();

            DWM.Refresh();
        }



        // Os 48 botões de cores chamam essa função, e apartir do nome do botão é definido a cor para o windows 
        private void botao_Cor_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            DWM.SetAccentColor(UInt32.Parse(botao.Name.Remove(0, 4)));
            botaoCheck(sender);
        }


        // Da um ✔ no botão com a cor atual, quando inicia o programa
        private void UltimaCorSelecionada()
        {
            foreach (var botao in groupBoxCoresDoWindows.Controls.OfType<Button>())
            {
                if (botao.Name.Remove(0, 4) == ((uint)AccentColor).ToString())
                {
                    botao.Text = "✔";
                    ultimoBotao = botao;
                }
            }
        }


        // Altera o texto do botão quando clicado: ✔
        private void botaoCheck(object sender)
        {
            Button botaoAtual = (Button)sender;
            botaoAtual.Text = "✔";

            if (ultimoBotao != botaoAtual)
            {
                ultimoBotao.Text = "";
            }

            ultimoBotao = botaoAtual;
        }


        // Cores Personalizadas com o ColorDialog, porem algumas cores o windows não aceita e fica outra
        private void button_CorPersonalizada_Click(object sender, EventArgs e)
        {
            selecionarCor = new ColorDialog();

            if (selecionarCor.ShowDialog() == DialogResult.OK)
            {
                string color_hex = (selecionarCor.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                uint color_uint = uint.Parse(color_hex, System.Globalization.NumberStyles.HexNumber);
                DWM.SetAccentColor(color_uint);
            }
        }


        // Botão para abrir o link do github
        private void linkLabel_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DanielSvoboda");
        }


        // Baixa o novo .exe do github com o nome do antigo(atual) e com numero a versão atual: exemplo_V3.exe
        private void button_atualizar_Click(object sender, EventArgs e)
        {
            var url_versao = "https://raw.githubusercontent.com/DanielSvoboda/Windows_Cores/main/versao.txt";
            var url_exe = "https://github.com/DanielSvoboda/Windows_Cores/raw/main/Windows_Cores.exe";

            WebRequest solicitacao = HttpWebRequest.Create(url_versao);
            WebResponse resposta = solicitacao.GetResponse();
            StreamReader sr = new StreamReader(resposta.GetResponseStream());
            string versaoNoGit = sr.ReadToEnd();

            if (versaoNoGit != versaoAtual)
            {
                DialogResult dialogResult = MessageBox.Show("Existe uma atualização! \n\n" +
                    "Versão atual: "+ versaoAtual+ "\n"+
                    "Versão nova:  " + versaoNoGit + "\n\n"+
                    "Vamos atualizar agora?", "Atualização Disponivel", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var dir = Directory.GetCurrentDirectory();
                    var nome_antigo = Process.GetCurrentProcess().ProcessName;
                    var nome_novo = Directory.GetCurrentDirectory() + @"\"+ nome_antigo + "_V" + versaoNoGit + ".exe";

                    var wClient = new WebClient();
                    wClient.DownloadFile(url_exe, nome_novo);      

                    MessageBox.Show("Download concluído!");

                    // Fecha o programa, espera 2 segundos, apaga o arquivo, renomeia com o nome antigo e com o numero da versão atual e abre ele     :)
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = "/C choice /C Y /N /D Y /T 2 & Del \"" + dir + "\\" + nome_antigo+ ".exe\" & start \"\" \"" + nome_novo + "\"",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = "cmd.exe"
                    }); ;

                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Não existe atualização disponivel ;)");
            }
        }
    }
}

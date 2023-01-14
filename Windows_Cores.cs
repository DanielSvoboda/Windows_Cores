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
            pintar_Botoes();
            UltimaCorSelecionada();
        }

        string versaoAtual = "2";           // Controle de versão para atualização

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

        // Pinta todos os botões 'Cores Do Windows'
        private void pintar_Botoes()
        {
            cor_4278237695.BackColor = Color.FromArgb(255, 185, 0);
            cor_4278226175.BackColor = Color.FromArgb(255, 140, 0);
            cor_4279002103.BackColor = Color.FromArgb(247, 99, 12);
            cor_4279259338.BackColor = Color.FromArgb(202, 80, 16);
            cor_4278270938.BackColor = Color.FromArgb(218, 59, 1);
            cor_4283460079.BackColor = Color.FromArgb(239, 105, 80);
            cor_4281873617.BackColor = Color.FromArgb(209, 52, 56);
            cor_4282598399.BackColor = Color.FromArgb(255, 67, 67);
            cor_4283844839.BackColor = Color.FromArgb(231, 72, 86);
            cor_4280488424.BackColor = Color.FromArgb(232, 17, 35);
            cor_4284350698.BackColor = Color.FromArgb(234, 0, 94);
            cor_4283564227.BackColor = Color.FromArgb(195, 0, 82);
            cor_4287365347.BackColor = Color.FromArgb(227, 0, 140);
            cor_4285989055.BackColor = Color.FromArgb(191, 0, 119);
            cor_4289935810.BackColor = Color.FromArgb(194, 57, 179);
            cor_4287168666.BackColor = Color.FromArgb(154, 0, 137);
            cor_4292311040.BackColor = Color.FromArgb(0, 120, 215);
            cor_4289815296.BackColor = Color.FromArgb(0, 99, 177);
            cor_4292381838.BackColor = Color.FromArgb(142, 140, 216);
            cor_4292241771.BackColor = Color.FromArgb(107, 105, 214);
            cor_4290274439.BackColor = Color.FromArgb(135, 100, 184);
            cor_4289285492.BackColor = Color.FromArgb(116, 77, 169);
            cor_4290922161.BackColor = Color.FromArgb(177, 70, 194);
            cor_4288157576.BackColor = Color.FromArgb(136, 23, 152);
            cor_4290550016.BackColor = Color.FromArgb(0, 153, 188);
            cor_4288314669.BackColor = Color.FromArgb(45, 125, 154);
            cor_4291016448.BackColor = Color.FromArgb(0, 183, 195);
            cor_4287070979.BackColor = Color.FromArgb(3, 131, 135);
            cor_4287934976.BackColor = Color.FromArgb(0, 178, 148);
            cor_4285826305.BackColor = Color.FromArgb(1, 133, 116);
            cor_4285189120.BackColor = Color.FromArgb(0, 204, 106);
            cor_4282288400.BackColor = Color.FromArgb(16, 137, 62);
            cor_4285822330.BackColor = Color.FromArgb(122, 117, 116);
            cor_4283980381.BackColor = Color.FromArgb(93, 90, 88);
            cor_4287264360.BackColor = Color.FromArgb(104, 118, 138);
            cor_4285226065.BackColor = Color.FromArgb(81, 92, 107);
            cor_4285758550.BackColor = Color.FromArgb(86, 124, 115);
            cor_4284508232.BackColor = Color.FromArgb(72, 104, 96);
            cor_4278551113.BackColor = Color.FromArgb(73, 130, 5);
            cor_4279270416.BackColor = Color.FromArgb(16, 124, 16);
            cor_4285953654.BackColor = Color.FromArgb(118, 118, 118);
            cor_4282927692.BackColor = Color.FromArgb(76, 74, 72);
            cor_4286478697.BackColor = Color.FromArgb(105, 121, 126);
            cor_4284044362.BackColor = Color.FromArgb(74, 84, 89);
            cor_4284775524.BackColor = Color.FromArgb(100, 124, 100);
            cor_4283719250.BackColor = Color.FromArgb(82, 94, 84);
            cor_4282742148.BackColor = Color.FromArgb(132, 117, 69);
            cor_4284445566.BackColor = Color.FromArgb(126, 115, 95);
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

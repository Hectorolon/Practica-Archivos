using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace PracticaArchivo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            int ancho = 0;
            int alto = 0;
            short pixel = 0;
            int tamaño = 0;
            ofd.ShowDialog();
            FileStream archivo = new
                FileStream(ofd.FileName, FileMode.Open);
            BinaryReader br = new BinaryReader(archivo);

            br.BaseStream.Seek(2, SeekOrigin.Begin);

            tamaño = br.ReadInt32();

            br.BaseStream.Seek(18, SeekOrigin.Begin);

            ancho = br.ReadInt32();
            alto = br.ReadInt32();

            br.BaseStream.Seek(28, SeekOrigin.Begin);

            pixel = br.ReadInt16();

            txtInfo.Text = "Tamaño = " + tamaño + "\r\nAncho = " + ancho + "\r\nAlto = " + alto + "\r\nNumero de Pixel = " + pixel;
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            //sfd.ShowDialog();
            //FileStream archivo = new
            //    FileStream(sfd.FileName, FileMode.Create);
            //StreamWriter sw = new StreamWriter(archivo);

            XmlDocument doc = new XmlDocument();
            XmlElement raiz = doc.CreateElement("Directorio");
            doc.AppendChild(raiz);

            XmlElement nombre = doc.CreateElement("nombre");
            raiz.AppendChild(nombre);

            XmlElement apellido = doc.CreateElement("apellido");
            apellido.AppendChild(doc.CreateTextNode("Rolon"));
            nombre.AppendChild(apellido);

            XmlElement telefono = doc.CreateElement("telefono");
            telefono.AppendChild(doc.CreateTextNode("3121355446"));
            nombre.AppendChild((telefono));

            doc.Save("c:\\xml\\archivo.xml");
        }
    }
}


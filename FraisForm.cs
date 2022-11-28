using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAffaire
{
    public partial class FraisForm : Form
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_Affaire.mdf;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataAdapter da = new SqlDataAdapter();

        // les Methodes
        public void remplirTypeNote()
        {
            cmbTypeFrais.Items.Clear();

            cmbTypeFrais.Items.Add("Gazoil");
            cmbTypeFrais.Items.Add("Autoroute");
            cmbTypeFrais.Items.Add("Gardiennage");
            cmbTypeFrais.Items.Add("Restaurant");
            cmbTypeFrais.Items.Add("Hotel");
            cmbTypeFrais.Items.Add("Achat de Matiere ou Fourniture");
            cmbTypeFrais.Items.Add("Produit et Frais des entretiens");
            cmbTypeFrais.Items.Add("Frais Postaux");
            cmbTypeFrais.Items.Add("Frais de Legalisation");
            cmbTypeFrais.Items.Add("Frais de Manutention");
            cmbTypeFrais.Items.Add("Indeminites de Deplacement");
            cmbTypeFrais.Items.Add("Frais de Transport");
            cmbTypeFrais.Items.Add("Frais de Deplacement Technicien(Controle de Gestion)");
            cmbTypeFrais.Items.Add("Frais de Deplacement Ingenieur(Controle de Gestion)");
            cmbTypeFrais.Items.Add("Frais de Kilometriques(Controle de Gestion)");
            cmbTypeFrais.Items.Add("Divers");
            cmbTypeFrais.Items.Add("...Définir");


        }
        public void remplirPCNote()
        {
            cmbPCFrais.Items.Clear();

            cmbPCFrais.Items.Add("Bon");
            cmbPCFrais.Items.Add("Facture");
            cmbPCFrais.Items.Add("Ticket");
            cmbPCFrais.Items.Add("Sans");
        }


        public FraisForm()
        {
            InitializeComponent();
        }

        private void btnAjouterFrais_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            if (f.rbValiderNote.Checked == true)
            {
                if (cmbTypeFrais.Text != "" && cmbPCFrais.Text != "" && txtFraisFrais.Text != "" && txtDateFrais.Text != "")
                {
                    errorProvider1.Dispose();

                    con.Open();
                    if (f.txtNumeroNote.Text != "" || f.cmbNumAffaireNote.Text != "")
                    {
                        cmd.CommandText = "insert into NoteFrais(Numero,affaire) values('" +
                                                                        Convert.ToInt32(f.txtNumeroNote.Text) + "','" +
                                                                        f.cmbNumAffaireNote.Text + "')";
                        cmd.ExecuteNonQuery();


                        cmd.CommandText = "insert into Frais(numero,Type,PiecesComptables,frais,date,noteFrais) values('" +
                                                                                                    f.NumeroFrais() + "','" +
                                                                                                    cmbTypeFrais.Text + "','" +
                                                                                                    cmbPCFrais.Text + "','" +
                                                                                                    txtFraisFrais.Text + "','" +
                                                                                                    txtDateFrais.Text + "','" +
                                                                                                    f.txtNumeroNote.Text + "')";
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(cmbTypeFrais.Text);
                    }

                    con.Close();


                    f.remplirNumeroNote();
                    f.remplirListFraisNote();
                    f.RemplirNumeroAffaire();
                    f.remplirListAffaire();
                    f.remplirTypeNote();
                    f.remplirPCNote();


                    Hide();
                }
                else
                {
                    if (cmbTypeFrais.Text == "")
                        errorProvider1.SetError(cmbTypeFrais, "cette information est Obligatoir");
                    if (cmbPCFrais.Text == "")
                        errorProvider1.SetError(cmbPCFrais, "cette information est Obligatoir");
                    if (txtFraisFrais.Text == "")
                        errorProvider1.SetError(txtFraisFrais, "cette information est Obligatoir");
                    if (txtDateFrais.Text == "")
                        errorProvider1.SetError(txtDateFrais, "cette information est Obligatoir");
                }


            }
        }

        private void FraisForm_Load(object sender, EventArgs e)
        {
            remplirTypeNote();
            remplirPCNote();
        }

        private void cmbTypeFrais_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbTypeFrais.Text == "...Définir")
            {
                cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTypeFrais.Text = "";
            }
            else
            {
                cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void cmbPCFrais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPCFrais.Text == "Sans")
            {
                txtFraisFrais.Text = "0.00";
                txtFraisFrais.Enabled = false;
            }
            else
            {
                txtFraisFrais.Enabled = true;
                txtFraisFrais.Text = "0.00";
            }
        }
    }
}

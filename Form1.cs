using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionAffaire
{
    public partial class Form1 : Form
    {
        //public static SqlConnection con = new SqlConnection(@"Data Source=OMAR-PC\SQLEXPRESS; initial catalog=DB_Affaire;Integrated Security=True");
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_Affaire.mdf;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataAdapter da = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }



        /************************************ le menu ************************************/
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxAff.Visible = true;
            BoxNoteAjouter.Visible = false;
            BoxMission.Visible = false;
            BoxPartiesInterecee.Visible = false;
            BoxRecherchFraisdeNote.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void affaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxNoteAjouter.Visible = true;
            BoxAff.Visible = false;
            BoxMission.Visible = false;
            BoxPartiesInterecee.Visible = false;
            BoxRecherchFraisdeNote.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void rechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxNoteAjouter.Visible = true;
            BoxAff.Visible = false;
            BoxMission.Visible = false;
            BoxPartiesInterecee.Visible = false;
            BoxRecherchFraisdeNote.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxAff.Visible = true;
            BoxPartiesInterecee.Visible = false;
            BoxNoteAjouter.Visible = false;
            BoxMission.Visible = false;
            BoxRecherchFraisdeNote.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void missionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BoxMission.Visible = true;
            BoxPartiesInterecee.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
            BoxRecherchFraisdeNote.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void lesPartiesIntereceeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxMission.Visible = true;
            BoxPartiesInterecee.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
            BoxRecherchFraisdeNote.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void lesPartiesIntéresséesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxPartiesInterecee.Visible = true;
            BoxMission.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
            BoxRecherchFraisdeNote.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void rechercheDansLesFraisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxRecherchFraisdeNote.Visible = true;
            BoxPartiesInterecee.Visible = false;
            BoxMission.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
            BoxMissionReche.Visible = false;
        }
        private void rechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxMissionReche.Visible = true;
            BoxRecherchFraisdeNote.Visible = false;
            BoxPartiesInterecee.Visible = false;
            BoxMission.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
        }



        /************************************ les Methodes ************************************/
        // methode pour remplir les id et la liste des client
        public void RemplirIdClient()
        {
            DataTable dt = new DataTable();

            cmbClientAff.Items.Clear();
            txtICEClient.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select * from Client";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtICEClient.Items.Add(dt.Rows[i][0].ToString());
                cmbClientAff.Items.Add(dt.Rows[i][1].ToString());
            }

            con.Close();
        }
        public void remplirListClient()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select ICE, raisonSociale as 'Raison Sociale' from Client";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListClient.DataSource = dt;
        }

        // methode pour remplir le nom et la liste de charge d'affaire
        public void RemplirNomRespo()
        {
            DataTable dt = new DataTable();

            txtNomRespo.Items.Clear();
            cmbResponsableAff.Items.Clear();
            cmbRespoMission.Items.Clear();
            cmbRespoNote.Items.Clear();
            cmbRespoMissionReche.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select nom from Responsable";
            da.SelectCommand = cmd;
            da.Fill(dt);

            cmbRespoMissionReche.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtNomRespo.Items.Add(dt.Rows[i][0].ToString());
                cmbResponsableAff.Items.Add(dt.Rows[i][0].ToString());
                cmbRespoMission.Items.Add(dt.Rows[i][0].ToString());
                cmbRespoNote.Items.Add(dt.Rows[i][0].ToString());
                cmbRespoMissionReche.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListRespo()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Nom, Prenom from Responsable";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListRespo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListRespo.DataSource = dt;
        }

        //methode pour remplir le nom et la list des employes
        public void remplirNomEmploye()
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();

            txtNomPersonne.Items.Clear();
            cmbEmployeOrdre.Items.Clear();

            con.Open();
            cmd.CommandText = "select nom from Personnel";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtNomPersonne.Items.Add(dt.Rows[i][0].ToString());
                cmbEmployeOrdre.Items.Add(dt.Rows[i][0].ToString());
                
            }

            con.Close();
        }
        public void remplirListEmploye()
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();

            con.Open();
            cmd.CommandText = "select Nom, Prenom from Personnel";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            listPersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listPersonnel.DataSource = dt;
        }

        // methode pour remplir le numero et la liste d'affaire
        public void RemplirNumeroAffaire()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            dt.Rows.Clear();
            dt2.Rows.Clear();
            
            cmbNumAffaireNote.Items.Clear();
            cmbNumAffMission.Items.Clear();
            cmbNumeroAff.Items.Clear();
            cmbAffMissionReche.Items.Clear();



            con.Open();
            cmd.CommandText = "select Numero from Affaires";
            da.SelectCommand = cmd;
            da.Fill(dt);

            cmd.Parameters.Clear();

            cmd.CommandText = "select distinct Affaires.Numero from Affaires left join NoteFrais on Affaires.Numero=affaire except select distinct Affaires.Numero from Affaires right join NoteFrais on Affaires.Numero=affaire";
            da.SelectCommand = cmd;
            da.Fill(dt2);
            con.Close();


            cmbAffMissionReche.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbNumeroAff.Items.Add(dt.Rows[i][0].ToString());
                cmbNumAffMission.Items.Add(dt.Rows[i][0].ToString());
                cmbAffMissionReche.Items.Add(dt.Rows[i][0].ToString());
            }

            cmbNumAffaireNote.Items.Add("");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                cmbNumAffaireNote.Items.Add(dt2.Rows[i][0].ToString());
            }

        }
        public void remplirListAffaire()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Numero,raisonSociale as 'Client',Responsable as 'Chargé d''affaire',NoteFrais as 'Note des Frais',NbrJourEstimer as 'Nombre de Jours Estimé' from Affaires inner join Client on Affaires.Client=Client.ICE";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();

            ListAff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListAff.DataSource = dt;
        }

        //methode pour remplir les numero et la liste des Frais de note
        public void remplirNumeroNote()
        {
            DataTable dt = new DataTable();

            cmbNumeroNote.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select Numero from NoteFrais";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbNumeroNote.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListFraisNote()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            if (rbValiderNote.Checked == true)
            {
                cmd.CommandText = "select Numero as 'Numero', Type as 'Type',PiecesComptables as 'Piece Comptable',convert(date,[date]) as [Date],frais as 'Frais' from Frais where noteFrais='" + txtNumeroNote.Text +"'";
                
            }
            else
            {
                cmd.CommandText = "select Numero as 'Numero', Type as 'Type',PiecesComptables as 'Piece Comptable',convert(date,[date]) as [Date],frais as 'Frais' from Frais where noteFrais='" + cmbNumeroNote.Text + "'";

            }
            da.SelectCommand = cmd;
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
            }
            listFraisNote.Columns[3].DefaultCellStyle.Format = "dd/mm/yy";

            con.Close();

            //listFraisNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //listFraisNote.DataSource = dt;
        }

        //methode pour remplir le Numero et la liste des Missions
        public void remplirNumeroMission()
        {
            DataTable dt = new DataTable();

            cmbNumeroMission.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select numero from Mission";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbNumeroMission.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListMission()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListMissionReche.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListMission.DataSource = dt;
            ListMission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListMissionReche.DataSource = dt;
        }

        //methode pour remplir Type de Note
        public void remplirTypeNote()
        {
            cmbTypeFrais.Items.Clear();
            cmbTypeFraisRecheNote.Items.Clear();

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
            cmbTypeFrais.Items.Add("Redéfinir...");

            cmbTypeFraisRecheNote.Items.Add("Gazoil");
            cmbTypeFraisRecheNote.Items.Add("Autoroute");
            cmbTypeFraisRecheNote.Items.Add("Gardiennage");
            cmbTypeFraisRecheNote.Items.Add("Restaurant");
            cmbTypeFraisRecheNote.Items.Add("Hotel");
            cmbTypeFraisRecheNote.Items.Add("Achat de Matiere ou Fourniture");
            cmbTypeFraisRecheNote.Items.Add("Produit et Frais des entretiens");
            cmbTypeFraisRecheNote.Items.Add("Frais Postaux");
            cmbTypeFraisRecheNote.Items.Add("Frais de Legalisation");
            cmbTypeFraisRecheNote.Items.Add("Frais de Manutention");
            cmbTypeFraisRecheNote.Items.Add("Indeminites de Deplacement");
            cmbTypeFraisRecheNote.Items.Add("Frais de Transport");
            cmbTypeFraisRecheNote.Items.Add("Frais de Deplacement Technicien(Controle de Gestion)");
            cmbTypeFraisRecheNote.Items.Add("Frais de Deplacement Ingenieur(Controle de Gestion)");
            cmbTypeFraisRecheNote.Items.Add("Frais de Kilometriques(Controle de Gestion)");
            cmbTypeFraisRecheNote.Items.Add("Divers");
            cmbTypeFraisRecheNote.Items.Add("Redéfinir...");
        }
        //methode pour remplir Pieces Comptable de Note
        public void remplirPCNote()
        {
            cmbPCFrais.Items.Clear();
            cmbPCFraisRecheNote.Items.Clear();

            cmbPCFrais.Items.Add("Bon");
            cmbPCFrais.Items.Add("Facture");
            cmbPCFrais.Items.Add("Ticket");
            cmbPCFrais.Items.Add("Sans");
            cmbPCFrais.Items.Add("Redéfinir...");

            cmbPCFraisRecheNote.Items.Add("Bon");
            cmbPCFraisRecheNote.Items.Add("Facture");
            cmbPCFraisRecheNote.Items.Add("Ticket");
            cmbPCFraisRecheNote.Items.Add("Sans");
            cmbPCFraisRecheNote.Items.Add("Redéfinir...");
        }

        //methode pour remplir la list des frais
        public void remplirListFrais()
        {
            
            DataTable dt = new DataTable();
            dt.Rows.Clear();

            con.Open();
            cmd.CommandText = "select Numero,Type,PiecesComptables as 'Piece Comptable',Frais,Date,noteFrais as 'Note de Frais' from Frais";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();

            ListRechercheFraisNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListRechercheFraisNote.DataSource = dt;
        }



        //methode pour verifier si l'affaire est deja existe dans la base
        public Boolean IsAffExists(string affaire)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false; 
            con.Open();
            cmd.CommandText = "select Numero from Affaires where Numero='"+ affaire +"'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si charge d'affaire est deja existe dans la base
        public Boolean IsRespoExists(string nom)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select nom from Responsable where nom='" + nom + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si le client est deja existe dans la base
        public Boolean IsClientExists(string cin)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select ICE from Client where ICE='" + cin + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }
        public Boolean IsRaisonSocialeClientExists(string raisonSociale)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select raisonSociale from Client where raisonSociale='" + raisonSociale + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }


        //methode pour verifier si la note des frais est deja existe dans la base
        public Boolean IsNoteExists(int numero)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select Numero from NoteFrais where Numero='" + numero + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si la mission est deja existe dans la base
        public Boolean IsMissionExists(int numero)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select numero from Mission where numero='" + numero + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si le frais est deja existe dans la base
        public Boolean IsFraisExists(int numeroFrais, int numeroNote)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select numero from Frais where numero='" + numeroFrais + "' and noteFrais='"+ numeroNote + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour savoir le numero de note des frais pour gerer le numero automatique
        public void NumeroNote()
        {
            con.Open();
            cmd.CommandText = "declare @num int = 1 " +
                              "while (exists(select Numero from NoteFrais where Numero = @num)) " +
                              "begin " +
                                "set @num = @num + 1; " +
                              "end " +
                              "select @num";
            int numeroNote = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();

            txtNumeroNote.Text = numeroNote.ToString();
        }

        //methode pour affecter le numero de frais
        public int NumeroFrais()
        {
            con.Open();
            cmd.CommandText = "declare @num int = 1 " +
                              "while (exists(select numero from Frais where numero = @num))" +
                              "begin " +
                                "set @num = @num + 1; " +
                              "end " +
                              "select @num";
            int numeroNote = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();

            return numeroNote;
        }

        //methode pour verifier si le client a une affaire
        public Boolean IsClientExistsInAffaire(string ICE)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select Client from Affaires where Client='" + ICE + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si le responsable a une affaire
        public Boolean IsRespoExistsInAffaire(string nom)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select Responsable from Affaires where Responsable='" + nom + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si le Responsable a une ordre de mission
        public Boolean IsRespoExistsInMission(string nom)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select respo from Mission where respo='" + nom + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si le Responsable a une Note
        public Boolean IsRespoExistsInNote(string nom)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select respo from NoteFrais where respo='" + nom + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si le Employe a une Note
        public Boolean IsEmployeExists(string nom)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select nom from Personnel where nom='" + nom + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }

        //methode pour verifier si le Employe dans une Ordre de Mission
        public Boolean IsEmployeExistsInMission(string personne, int mission)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select personnel from DetailMission where mission='" + mission + "' and personnel='"+ personne +"'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }



        public void numeroFrais()
        {
            for (int i = 0; i < listFraisNote.Rows.Count - 1; i++)
            {
                listFraisNote.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            RemplirNumeroAffaire();
            remplirListAffaire();
            RemplirIdClient();
            remplirListClient();
            remplirNumeroMission();
            remplirListMission();
            remplirNumeroNote();
            remplirListFraisNote();
            remplirTypeNote();
            remplirPCNote();
            RemplirNomRespo();
            remplirListRespo();
            NumeroNote();
            remplirListFrais();
            remplirNomEmploye();
            remplirListEmploye();

            //txtDateFinFraisRecheNote.Value = (DateTime.Now.Month DateTime.Parse("mm/dd/yy"));
        }



        // les parties interecees
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton2.Checked == true)
            {
                radioButton3.Checked = false;
                radioButton1.Checked = false;

                BoxRespoAjouter.Visible = true;
            }
            else
            {
                BoxRespoAjouter.Visible = false;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton3.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = false;

                BoxClientAjouter.Visible = true;
            }
            else
            {
                BoxClientAjouter.Visible = false;
            }
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;

                BoxPersonnel.Visible = true;
            }
            else
            {
                BoxPersonnel.Visible = false;
            }
        }
        private void btnValiderClient_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton3.Checked == true)
            {
                if (txtICEClient.Text != "")
                {
                    if (txtRaisonSocialClient.Text != "")
                    {
                        if (IsClientExists(txtICEClient.Text) == true)
                        {
                            errorProvider1.SetError(txtICEClient, "ICE de Client est déjà Existant");
                        }
                        else
                        {
                            if (IsRaisonSocialeClientExists(txtRaisonSocialClient.Text) == false)
                            {
                                con.Open();
                                cmd.CommandText = "insert into Client values('" + txtICEClient.Text + "','" + txtRaisonSocialClient.Text + "')";
                                cmd.ExecuteNonQuery();
                                con.Close();

                                MessageBox.Show("Client Ajouter Avec Succès");

                                txtICEClient.Text = txtRaisonSocialClient.Text = "";
                                remplirListClient();
                                RemplirIdClient();
                            }
                            else
                                errorProvider1.SetError(txtRaisonSocialClient, "Raison Sociale de Client est déjà Existant");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtRaisonSocialClient, "cette information est Obligatoir");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtICEClient, "cette information est Obligatoir");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtNomRespo.Text != "")
                {
                    if (IsRespoExists(txtNomRespo.Text) == true)
                    {
                        errorProvider1.SetError(txtNomRespo, "Chargé d'affaire est déjà Existant");
                    }
                    else
                    {
                        if (txtPrenomRespo.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "insert into Responsable values('" + txtNomRespo.Text + "','" + txtPrenomRespo.Text + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Chargé d'affaire Ajouter Avec Succès");

                            txtNomRespo.Text = txtPrenomRespo.Text = "";
                            RemplirNomRespo();
                            remplirListRespo();
                        }
                        else
                        {
                            errorProvider1.SetError(txtPrenomRespo, "cette information est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomRespo, "cette information est Obligatoir");
                }
            }
            else if (radioButton1.Checked == true)
            {
                if (txtNomPersonne.Text != "")
                {
                    if (IsEmployeExists(txtNomPersonne.Text) == true)
                    {
                        errorProvider1.SetError(txtNomPersonne, "Personne est déjà Existant");
                    }
                    else
                    {
                        if (txtPrenomPresonne.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "insert into Personnel values('" + txtNomPersonne.Text + "','" + txtPrenomPresonne.Text + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Personne Ajouter Avec Succès");

                            txtNomPersonne.Text = txtPrenomPresonne.Text = "";
                            remplirNomEmploye();
                            remplirListEmploye();
                        }
                        else
                        {
                            errorProvider1.SetError(txtPrenomPresonne, "cette Information est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomPersonne, "cette information est Obligatoir");
                }
            }
        }
        private void btnModifierCR_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton3.Checked == true)
            {
                if (txtICEClient.Text != "")
                {
                    if (IsClientExists(txtICEClient.Text) == false)
                    {
                        errorProvider1.SetError(txtICEClient, "Client n'est pas Existant");
                    }
                    else
                    {
                        if (txtRaisonSocialClient.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "update Client set raisonSociale='" + txtRaisonSocialClient.Text + "' where ICE='" + txtICEClient.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Modification Avec Succès");

                            txtICEClient.Text = txtRaisonSocialClient.Text = "";
                            remplirListClient();
                            RemplirIdClient();
                        }
                        else
                        {
                            errorProvider1.SetError(txtRaisonSocialClient, "cette information est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtICEClient, "cette information est Obligatoir");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtNomRespo.Text != "")
                {
                    if (IsRespoExists(txtNomRespo.Text) == false)
                    {
                        errorProvider1.SetError(txtNomRespo, "Chargé d'affaire n'est pas Existant");
                    }
                    else
                    {
                        if (txtPrenomRespo.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "update Responsable set prenom='" + txtPrenomRespo.Text + "' where nom='" + txtNomRespo.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Modification Avec Succès");

                            txtNomRespo.Text = txtPrenomRespo.Text = "";
                            RemplirNomRespo();
                            remplirListRespo();
                        }
                        else
                        {
                            errorProvider1.SetError(txtPrenomRespo, "Prenom est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomRespo, "cette information est Obligatoir");
                }
            }
            else if (radioButton1.Checked == true)
            {
                if (txtNomPersonne.Text != "")
                {
                    if (IsEmployeExists(txtNomPersonne.Text) == false)
                    {
                        errorProvider1.SetError(txtNomPersonne, "Personne n'est pas Existant");
                    }
                    else
                    {
                        if (txtPrenomPresonne.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "update Personnel set prenom='" + txtPrenomPresonne.Text + "' where nom='" + txtNomPersonne.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Modification Avec Succès");

                            txtNomPersonne.Text = txtPrenomPresonne.Text = "";
                            remplirNomEmploye();
                            remplirListEmploye();
                        }
                        else
                        {
                            errorProvider1.SetError(txtPrenomPresonne, "Prenom est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomPersonne, "cette information est Obligatoir");
                }
            }
        }
        private void txtICEClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            DataTable dt = new DataTable();
            dt.Rows.Clear();

            con.Open();
            cmd.CommandText = "select ICE,raisonSociale as 'Raison Sociale' from Client where ICE='" + txtICEClient.Text + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListClient.DataSource = dt;

            txtRaisonSocialClient.Text = dt.Rows[0][1].ToString();
        }
        private void txtNomRespo_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Nom, Prenom from Responsable where nom='"+ txtNomRespo.Text +"'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListRespo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListRespo.DataSource = dt;

            txtPrenomRespo.Text = dt.Rows[0][1].ToString();
        }
        private void txtNomPersonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            DataTable dt = new DataTable();
            dt.Rows.Clear();

            con.Open();
            cmd.CommandText = "select Nom, Prenom from Personnel where nom='" + txtNomPersonne.Text + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            listPersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listPersonnel.DataSource = dt;

            txtPrenomPresonne.Text = dt.Rows[0][1].ToString();
        }
        private void btnSupprimerCR_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton3.Checked == true)
            {
                if (txtICEClient.Text != "")
                {
                    if (IsClientExists(txtICEClient.Text) == false)
                    {
                        errorProvider1.SetError(txtICEClient, "Client n'est pas Existant");
                    }
                    else
                    {
                        if (MessageBox.Show("voulez-vous supprimer Client?", "Supprimer Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (IsClientExistsInAffaire(txtICEClient.Text))
                            {
                                MessageBox.Show("le Client a une ou plusieur Affaire ");
                            }
                            else
                            {
                                con.Open();
                                cmd.CommandText = "delete Client where ICE='" + txtICEClient.Text + "'";
                                cmd.ExecuteNonQuery();
                                con.Close();

                                MessageBox.Show("Suppression Avec Succès");

                                txtICEClient.Text = txtRaisonSocialClient.Text = "";
                                remplirListClient();
                                RemplirIdClient();
                            }
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtICEClient, "cette information est Obligatoir");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtNomRespo.Text != "")
                {
                    if (IsRespoExists(txtNomRespo.Text) == false)
                    {
                        errorProvider1.SetError(txtNomRespo, "Chargé d'affaire n'est pas Existant");
                    }
                    else
                    {
                        if (MessageBox.Show("voulez-vous supprimer Chargé d'affaire?", "Supprimer Chargé d'affaire", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            cmd.CommandText = "delete Responsable where nom='" + txtNomRespo.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            txtNomRespo.Text = txtPrenomRespo.Text = "";
                            RemplirNomRespo();
                            remplirListRespo();
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomRespo, "cette information est Obligatoir");
                }
            }
            else if (radioButton1.Checked == true)
            {
                if (txtNomPersonne.Text != "")
                {
                    if (IsEmployeExists(txtNomPersonne.Text) == false)
                    {
                        errorProvider1.SetError(txtNomPersonne, "Personne n'est pas Existant");
                    }
                    else
                    {
                        if (MessageBox.Show("voulez-vous supprimer Chargé d'affaire?", "Supprimer Chargé d'affaire", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            cmd.CommandText = "delete Personnel where nom='" + txtNomPersonne.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            txtNomPersonne.Text = txtPrenomPresonne.Text = "";
                            remplirNomEmploye();
                            remplirListEmploye();
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomPersonne, "cette information est Obligatoir");
                }
            }
        }



        // l'affaire
        private void cmbNumeroAff_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Numero,raisonSociale as 'Client',Responsable as 'Chargé d''affaire',NoteFrais as 'Note des Frais',NbrJourEstimer as 'Nombre de Jours Estimé' from Affaires inner join Client on Affaires.Client=Client.ICE where Numero='" + cmbNumeroAff.Text + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();

            ListAff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListAff.DataSource = dt;

            cmbClientAff.Text = dt.Rows[0][1].ToString();
            cmbResponsableAff.Text = dt.Rows[0][2].ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            RemplirNumeroAffaire();
            remplirListAffaire();
            RemplirIdClient();
            RemplirNomRespo();
            txtNbrJourAffaire.Value = 1;

            cmbNumeroAff.Text = "";
        }
        private void btnValiderAff_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroAff.Text != "")
            {
                if (IsAffExists(cmbNumeroAff.Text) == false)
                {
                    if (cmbClientAff.Text != "" && cmbResponsableAff.Text != "")
                    {
                        if (txtNbrJourAffaire.Value.ToString() != null)
                        {
                            if (txtNbrJourAffaire.Value > 0)
                            {
                                con.Open();

                                cmd.CommandText = "select ICE from Client where raisonSociale='" + cmbClientAff.Text + "'";
                                string ICE = cmd.ExecuteScalar().ToString();

                                cmd.Parameters.Clear();

                                cmd.CommandText = "insert into Affaires(Numero,Client,Responsable,NbrJourEstimer) values('" 
                                                            + cmbNumeroAff.Text + "','" 
                                                            + ICE + "','" 
                                                            + cmbResponsableAff.Text + "','"+
                                                            int.Parse(txtNbrJourAffaire.Value.ToString()) +"')";
                                cmd.ExecuteNonQuery();
                                con.Close();

                                // afficher message d'inssertion
                                MessageBox.Show("Affaire Ajouter Avec Succès");

                                //vider la valeur de champ
                                cmbNumeroAff.Text = "";
                                RemplirIdClient();
                                RemplirNomRespo();
                                txtNbrJourAffaire.Value = 1;

                                //faire le mis a jour
                                remplirListAffaire();
                                RemplirNumeroAffaire();
                            }
                            else
                                errorProvider1.SetError(txtNbrJourAffaire, "Saisir Nombre de jours Valide");
                        }
                        else
                            errorProvider1.SetError(txtNbrJourAffaire,"cette Information est Obligatoir");
                    }
                    else
                    {
                        if (cmbClientAff.Text == "")
                            errorProvider1.SetError(cmbClientAff, "cette Information est Obligatoir");
                        if (cmbResponsableAff.Text == "")
                            errorProvider1.SetError(cmbResponsableAff, "cette Information est Obligatoir");
                    }
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "l'affaire est déjà Existant");
                }
            }
            else
            {
                errorProvider1.SetError(cmbNumeroAff,"cette Information est Obligatoir");
            }
        }
        private void btnModifierAffaire_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroAff.Text != "")
            {
                if (IsAffExists(cmbNumeroAff.Text) == true)
                {
                    if (cmbClientAff.Text != "" && cmbResponsableAff.Text != "")
                    {
                        if (txtNbrJourAffaire.Value.ToString() != null)
                        {
                            if (txtNbrJourAffaire.Value > 0)
                            {
                                con.Open();

                                cmd.CommandText = "select ICE from Client where raisonSociale='" + cmbClientAff.Text + "'";
                                string ICE = cmd.ExecuteScalar().ToString();

                                cmd.Parameters.Clear();

                                cmd.CommandText = "update Affaires set Client='" + ICE 
                                                                    + "',Responsable='" + cmbResponsableAff.Text 
                                                                    + "',NbrJourEstimer='"+ int.Parse(txtNbrJourAffaire.Value.ToString()) 
                                                                    +"' where Numero='" + cmbNumeroAff.Text + "'";
                                cmd.ExecuteNonQuery();
                                con.Close();

                                // afficher message d'inssertion
                                MessageBox.Show("Modification Avec Succès");

                                //vider la valeur de champ
                                cmbNumeroAff.Text = "";
                                RemplirIdClient();
                                RemplirNomRespo();
                                txtNbrJourAffaire.Value = 1;


                                //faire le mis a jour
                                remplirListAffaire();
                                RemplirNumeroAffaire();
                            }
                            else
                                errorProvider1.SetError(txtNbrJourAffaire, "Saisir Nombre de jours Valide");
                        }
                        else
                            errorProvider1.SetError(txtNbrJourAffaire, "cette Information est Obligatoir");
                    }
                    else
                    {
                        if (cmbClientAff.Text == "")
                            errorProvider1.SetError(cmbClientAff, "cette Information est Obligatoir");
                        if (cmbResponsableAff.Text == "")
                            errorProvider1.SetError(cmbResponsableAff, "cette Information est Obligatoir");
                    }
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "l'affaire n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroAff, "choisir une Affaire");
        }
        private void btnSupprimerAff_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroAff.Text != "")
            {
                if (IsAffExists(cmbNumeroAff.Text) == true)
                {
                    if (MessageBox.Show("voulez-vous supprimer cette Affaire?", "Supprimer Affaire", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cmd.CommandText = "delete Affaires where Numero='" + cmbNumeroAff.Text + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();


                        //afficher message Succès
                        MessageBox.Show("Suppression Avec Succès");

                        //faire mis a jour
                        RemplirNumeroAffaire();
                        remplirListAffaire();
                        RemplirNomRespo();
                        RemplirIdClient();

                        cmbNumeroAff.Text = "";

                        con.Close();
                    }
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "l'affaire n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroAff, "choisir Numero d'affaire");
        }
        private void btnPdfAff_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroAff.Text != "")
            {
                if (IsAffExists(cmbNumeroAff.Text))
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();

                    con.Open();
                    cmd.CommandText = "select * from Affaires where Numero='" + cmbNumeroAff.Text + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Affaires");

                    cmd.Parameters.Clear();

                    cmd.CommandText = "select * from NoteFrais where affaire='" + cmbNumeroAff.Text + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "NoteFrais");

                    cmd.Parameters.Clear();

                    cmd.CommandText = "select noteFrais from Affaires where Numero='" + cmbNumeroAff.Text + "'";

                    int noteFrais = 0;
                    if (cmd.ExecuteScalar().ToString() != "")
                    {
                        noteFrais = int.Parse(cmd.ExecuteScalar().ToString());
                    }

                    cmd.Parameters.Clear();

                    cmd.CommandText = "select * from Frais where noteFrais='" + noteFrais + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Frais");

                    cmd.Parameters.Clear();

                    cmd.CommandText = "select * from Mission where affaire='" + cmbNumeroAff.Text + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Mission");

                    cmd.Parameters.Clear();

                    cmd.CommandText = "select Client from Affaires where Numero='" + cmbNumeroAff.Text + "'";

                    string ice = "";
                    if (cmd.ExecuteScalar().ToString() != "")
                    {
                        ice = cmd.ExecuteScalar().ToString();
                    }

                    cmd.Parameters.Clear();

                    cmd.CommandText = "select * from Client where ICE='" + ice + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Client");


                    con.Close();



                    CrystalReport1 cr = new CrystalReport1();
                    cr.Database.Tables["Affaires"].SetDataSource(ds.Tables[0]);
                    cr.Database.Tables["NoteFrais"].SetDataSource(ds.Tables[1]);
                    cr.Database.Tables["Frais"].SetDataSource(ds.Tables[2]);
                    cr.Database.Tables["Mission"].SetDataSource(ds.Tables[3]);
                    cr.Database.Tables["Client"].SetDataSource(ds.Tables[4]);

                    Form2 f = new Form2();
                    f.crystalReportViewer1.ReportSource = null;
                    f.crystalReportViewer1.ReportSource = cr;
                    f.crystalReportViewer1.Refresh();

                    f.Show();
                    this.Hide();
                }
                else
                    errorProvider1.SetError(cmbNumeroAff, "l'affaire n'est pas Existant");
            }
            else
                errorProvider1.SetError(cmbNumeroAff, "chisir une Affaire");
        }



        // note de frais
        private void cmbTypeNoteAjouter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeFrais.Text == "Redéfinir...")
            {
                cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTypeFrais.Text = "";
            }
            else
            {
                cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void cmbPCNoteAjouter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPCFrais.Text == "Sans")
            {
                txtFraisFrais.Text = "0";
                txtFraisFrais.Enabled = false;
            }
            else
            {
                txtFraisFrais.Enabled = true;
            }

            if (cmbPCFrais.Text == "Redéfinir...")
            {
                cmbPCFrais.DropDownStyle = ComboBoxStyle.DropDown;
                cmbPCFrais.Text = "";
            }
            else
            {
                cmbPCFrais.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (rbValiderNote.Checked == true)
            {
                if (DateTime.Parse(txtDateNote.Value.ToString()).Day <= DateTime.Now.Day)
                {
                    if (listFraisNote.Rows.Count > 1)
                    {
                        try
                        {
                            if (cmbRespoNote.Text != "")
                            {
                                if (cmbNumAffaireNote.Text != "")
                                {
                                    con.Open();
                                    cmd.CommandText = "insert into NoteFrais(Numero,affaire,date,respo) values('" +
                                                                                    Convert.ToInt32(txtNumeroNote.Text) + "','" +
                                                                                    cmbNumAffaireNote.Text + "','" +
                                                                                    Convert.ToDateTime(txtDateNote.Text) + "','" +
                                                                                    cmbRespoNote.Text + "')";
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                else
                                {
                                    con.Open();
                                    cmd.CommandText = "insert into NoteFrais(Numero,date,respo) values('" +
                                                                                    Convert.ToInt32(txtNumeroNote.Text) + "','" +
                                                                                    Convert.ToDateTime(txtDateNote.Text) + "','" +
                                                                                    cmbRespoNote.Text + "')";
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }


                                con.Open();
                                for (int i = 0; i < listFraisNote.Rows.Count - 1; i++)
                                {

                                    cmd.CommandText = "insert into Frais(numero,Type,PiecesComptables,date,frais,noteFrais) values('" +
                                                                                                            int.Parse(listFraisNote.Rows[i].Cells[0].Value.ToString()) + "','" +
                                                                                                            listFraisNote.Rows[i].Cells[1].Value.ToString() + "','" +
                                                                                                            listFraisNote.Rows[i].Cells[2].Value.ToString() + "','" +
                                                                                                            DateTime.Parse(listFraisNote.Rows[i].Cells[3].Value.ToString()) + "','" +
                                                                                                            double.Parse(listFraisNote.Rows[i].Cells[4].Value.ToString()) + "','" +
                                                                                                            txtNumeroNote.Text + "')";
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                                con.Close();

                                listFraisNote.Rows.Clear();
                                remplirTypeNote();
                                remplirPCNote();
                                RemplirNumeroAffaire();
                                remplirListAffaire();
                                RemplirNomRespo();
                                NumeroNote();
                                txtDateFrais.Text = "";
                                txtDateNote.Text = "";
                                txtFraisFrais.Text = "0";
                                txtRespoNote.Text = "";


                                remplirNumeroNote();
                                remplirListFrais();
                            }
                            else
                                errorProvider1.SetError(cmbRespoNote, "cette information est Obligatoir");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erreur", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pour Valider une Note de Frais il doit Remplir au minimum un Frais", "Erreur", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                    errorProvider1.SetError(txtDateNote, "Date de Note il doit inférieur ou egale Date d'aujourd'hui");
            }
            else
            {
                if (listFraisNote.Rows.Count > 1)
                {
                    try
                    {
                        for (int i = 0; i < listFraisNote.Rows.Count - 1; i++)
                        {
                            if (IsFraisExists(int.Parse(listFraisNote.Rows[i].Cells[0].Value.ToString()), int.Parse(cmbNumeroNote.Text)) == false)
                            {
                                con.Open();
                                cmd.CommandText = "insert into Frais(numero,Type,PiecesComptables,frais,date,noteFrais) values('" +
                                                            int.Parse(listFraisNote.Rows[i].Cells[0].Value.ToString()) + "','"+
                                                            listFraisNote.Rows[i].Cells[1].Value.ToString() + "','"+
                                                            listFraisNote.Rows[i].Cells[2].Value.ToString() + "','"+
                                                            double.Parse(listFraisNote.Rows[i].Cells[4].Value.ToString()) + "','"+
                                                            DateTime.Parse(listFraisNote.Rows[i].Cells[3].Value.ToString()) + "','"+
                                                            int.Parse(cmbNumeroNote.Text) + "')";
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }


                        listFraisNote.Rows.Clear();
                        remplirTypeNote();
                        remplirPCNote();
                        NumeroNote();
                        RemplirNumeroAffaire();
                        RemplirNomRespo();
                        remplirListAffaire();
                        txtDateFrais.Text = "";
                        txtDateNote.Text = "";
                        txtFraisFrais.Text = "0";

                        txtNumAff.Text = txtTotalFraisNote.Text = "";

                        remplirNumeroNote();
                        remplirListFrais();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Pour Valider une Note de Frais il doit Remplir au minimum un Frais", "Erreur", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            
        }
        private void btnSupprimerNoteFrais_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroNote.Text != "")
            {
                if (IsNoteExists(int.Parse(cmbNumeroNote.Text)) == true)
                {
                    if (MessageBox.Show("voulez-vous supprimer cette Note de Frais?","Supprimer Note",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cmd.CommandText = "select numero from Frais where noteFrais='" + int.Parse(cmbNumeroNote.Text) + "'";
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cmd.CommandText = "delete Frais where numero='"+ int.Parse(dt.Rows[i][0].ToString()) +"' and noteFrais='" + int.Parse(cmbNumeroNote.Text) + "'";
                            cmd.ExecuteNonQuery();
                        }

                        cmd.Parameters.Clear();

                        cmd.CommandText = "delete NoteFrais where Numero='" + int.Parse(cmbNumeroNote.Text) + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();


                        //afficher message Succès
                        MessageBox.Show("Suppression Avec Succès");

                        //faire mis a jour
                        remplirListFraisNote();
                        remplirNumeroNote();
                        RemplirNomRespo();
                        RemplirNumeroAffaire();
                        remplirListAffaire();
                        remplirPCNote();
                        remplirTypeNote();
                        NumeroNote();
                        remplirListFrais();

                        listFraisNote.Rows.Clear();

                        cmbNumeroNote.Text = cmbTypeFrais.Text = cmbPCFrais.Text = cmbNumAffaireNote.Text = txtDateNote.Text = txtDateFrais.Text = "";
                        txtFraisFrais.Text = (0.00).ToString();

                        txtTotalFraisNote.Text = txtNumAff.Text = "";
                    }

                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "la Note n'est pas Existant");
                }
            }
            else
            {
                errorProvider1.SetError(cmbNumeroNote, "choisir le Numero de Note");
            }
            cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            listFraisNote.Rows.Clear();
            remplirTypeNote();
            remplirPCNote();
            RemplirNumeroAffaire();
            RemplirNomRespo();
            remplirNumeroNote();

            cmbNumeroNote.Text = "";
            txtDateFrais.Text = "";
            txtDateNote.Text = "";
            txtFraisFrais.Text = "0";
            txtRespoNote.Text = "";



            remplirNumeroNote();
            txtNumAff.Text = txtTotalFraisNote.Text = "";

            cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPCFrais.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void btnImrimerPdfNote_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (cmbNumeroNote.Text != "")
            {
                if (IsNoteExists(int.Parse(cmbNumeroNote.Text)))
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();

                    con.Open();

                    cmd.CommandText = "select * from NoteFrais where Numero='" + int.Parse(cmbNumeroNote.Text) + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "NoteFrais");

                    cmd.Parameters.Clear();

                    cmd.CommandText = "select * from Frais where noteFrais='" + int.Parse(cmbNumeroNote.Text) + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Frais");

                    con.Close();



                    CrystalReport2 cr = new CrystalReport2();
                    cr.Database.Tables["NoteFrais"].SetDataSource(ds.Tables[0]);
                    cr.Database.Tables["Frais"].SetDataSource(ds.Tables[1]);

                    Form3 f = new Form3();
                    f.crystalReportViewer1.ReportSource = null;
                    f.crystalReportViewer1.ReportSource = cr;
                    f.crystalReportViewer1.Refresh();

                    f.Show();
                    this.Hide();
                }
                else
                    errorProvider1.SetError(cmbNumeroMission, "la Note n'est pas Existant");
            }
            else
                errorProvider1.SetError(cmbNumeroNote, "chisir Numero de Note");
        }
        private void cmbNumeroNote_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt.Rows.Clear();
            dt2.Rows.Clear();

            errorProvider1.Dispose();
            listFraisNote.Rows.Clear();

            con.Open();
            cmd.CommandText = "select Numero,affaire,cast(totalFrais as varchar) as 'totalFrais',date,respo from NoteFrais where Numero='" + int.Parse(cmbNumeroNote.Text) + "'";
            da.SelectCommand = cmd;
            da.Fill(dt2);

            txtNumAff.Text = dt2.Rows[0][1].ToString();
            txtTotalFraisNote.Text = (dt2.Rows[0][2].ToString());
            txtDateNote.Text = (dt2.Rows[0][3].ToString());
            txtRespoNote.Text = dt2.Rows[0][4].ToString();

            cmd.Parameters.Clear();

            cmd.CommandText = "select numero as 'Numero',Type,PiecesComptables as 'Piece Comptable',convert(date,[date]) as [Date],cast(frais as varchar) from Frais where NoteFrais='" + int.Parse(cmbNumeroNote.Text) + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listFraisNote.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
                txtDateFrais.Text = dt.Rows[i][3].ToString();
                listFraisNote.Rows[i].Cells[3].Value = txtDateFrais.Text;
            }

            remplirTypeNote();
            remplirPCNote();
            txtDateFrais.Text = "";
            txtFraisFrais.Text = "0";
        }



        // mission
        private void btnValiderMission_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
                        
            if (cmbRespoMission.Text != "" && txtDateDebutMission.Text != "" && txtDateFinMission.Text != "" && txtLieuDepartMission.Text != "" && txtLieuArriveMission.Text != "" && cmbNumAffMission.Text != "")
            {
                if (Convert.ToDateTime(txtDateFinMission.Text) >= Convert.ToDateTime(txtDateDebutMission.Text))
                {
                    con.Open();
                    
                    if (listeEmployeOrdre.Items.Count > 0)
                    {
                        cmd.CommandText = "insert into Mission(dateDebut,dateFin,lieuDepart,lieuArriver,affaire,respo,nbrPersonne) values('" +
                                                                        DateTime.Parse(txtDateDebutMission.Text) + "','" +
                                                                        DateTime.Parse(txtDateFinMission.Text) + "','" +
                                                                        txtLieuDepartMission.Text + "','" +
                                                                        txtLieuArriveMission.Text + "','" +
                                                                        cmbNumAffMission.Text + "','" +
                                                                        cmbRespoMission.Text + "','" +
                                                                        int.Parse(listeEmployeOrdre.Items.Count.ToString()) + "')";
                    }
                    else
                    {
                        cmd.CommandText = "insert into Mission(dateDebut,dateFin,lieuDepart,lieuArriver,affaire,respo,nbrPersonne) values('" +
                                                                        DateTime.Parse(txtDateDebutMission.Text) + "','" +
                                                                        DateTime.Parse(txtDateFinMission.Text) + "','" +
                                                                        txtLieuDepartMission.Text + "','" +
                                                                        txtLieuArriveMission.Text + "','" +
                                                                        cmbNumAffMission.Text + "','" +
                                                                        cmbRespoMission.Text + "',0)";
                    }
                    
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    if (listeEmployeOrdre.Items.Count > 0)
                    {
                        for (int i = 0; i < listeEmployeOrdre.Items.Count; i++)
                        {
                            cmd.CommandText = "insert into DetailMission values((select top(1) numero from Mission order by numero desc) ,'" + listeEmployeOrdre.Items[i].ToString() + "')";
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "select NbrJourEstimer from Affaires where Numero='" + cmbNumAffMission.Text + "'";
                    int nbrJour = int.Parse(cmd.ExecuteScalar().ToString());

                    con.Close();

                    MessageBox.Show("Ajouter Avec Succès");

                    if (nbrJour < 0)
                    {
                        MessageBox.Show("Nombre de Jours de Mission Dépasse le Nombre de Jours Estimé pour l'affaire", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                    }

                    remplirNumeroMission();
                    remplirListMission();
                    remplirNumeroMission();
                    RemplirNumeroAffaire();
                    RemplirNomRespo();
                    remplirNomEmploye();
                    remplirListAffaire();
                    listeEmployeOrdre.Items.Clear();

                    cmbNumeroMission.Text = txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = txtLieuArriveMission.Text = "";
                    
                }
                else
                {
                    errorProvider1.SetError(btnValiderMission, "Date Fin de Mission doit être Supérieur ou egale Date Debut");
                }
            }
            else
            {
                if (cmbRespoMission.Text == "")
                    errorProvider1.SetError(cmbRespoMission, "cette Information est Obligatoir");
                if (txtDateDebutMission.Text == "")
                    errorProvider1.SetError(txtDateDebutMission, "cette Information est Obligatoir");
                if (txtDateFinMission.Text == "")
                    errorProvider1.SetError(txtDateFinMission, "cette Information est Obligatoir");
                if (txtLieuDepartMission.Text == "")
                    errorProvider1.SetError(txtLieuDepartMission, "cette Information est Obligatoir");
                if (txtLieuArriveMission.Text == "")
                    errorProvider1.SetError(txtLieuArriveMission, "cette Information est Obligatoir");
                if (cmbNumAffMission.Text == "")
                    errorProvider1.SetError(cmbNumAffMission, "cette Information est Obligatoir");
            }
        
        }
        private void btnModifierMission_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroMission.Text != "")
            {
                if (IsMissionExists(int.Parse(cmbNumeroMission.Text)))
                {
                    if (cmbRespoMission.Text != "" && txtDateDebutMission.Text != "" && txtDateFinMission.Text != "" && txtLieuDepartMission.Text != "" && txtLieuArriveMission.Text != "" && cmbNumAffMission.Text != "")
                    {
                        if (Convert.ToDateTime(txtDateFinMission.Text) >= Convert.ToDateTime(txtDateDebutMission.Text))
                        {
                            con.Open();
                            
                            cmd.Parameters.Clear();

                            cmd.CommandText = "update Mission set dateDebut='" + DateTime.Parse(txtDateDebutMission.Text) +
                                                            "',dateFin ='" + DateTime.Parse(txtDateFinMission.Text) +
                                                            "',lieuDepart='" + txtLieuDepartMission.Text +
                                                            "',lieuArriver='" + txtLieuArriveMission.Text +
                                                            "',affaire='" + cmbNumAffMission.Text +
                                                            "',respo='" + cmbRespoMission.Text +
                                                            "',nbrPersonne='" + int.Parse(listeEmployeOrdre.Items.Count.ToString()) +
                                                            "' where numero='" + int.Parse(cmbNumeroMission.Text) + "'";
                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();


                            cmd.Parameters.Clear();
                            con.Close();


                            if (listeEmployeOrdre.Items.Count > 0)
                            {
                                for (int i = 0; i < listeEmployeOrdre.Items.Count; i++)
                                {
                                    if (IsEmployeExistsInMission(listeEmployeOrdre.Items[i].ToString(), int.Parse(cmbNumeroMission.Text)) == false)
                                    {
                                        con.Open();
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "insert into DetailMission values('" + int.Parse(cmbNumeroMission.Text) + "','" + listeEmployeOrdre.Items[i].ToString() + "')";
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                            }

                            MessageBox.Show("Modification Avec Succès");

                            con.Open();
                            cmd.CommandText = "select NbrJourEstimer from Affaires where Numero='" + cmbNumAffMission.Text + "'";
                            int nbrJour = int.Parse(cmd.ExecuteScalar().ToString());
                            con.Close();

                            if (nbrJour < 0)
                            {
                                MessageBox.Show("Nombre de Jours de Mission Dépasse le Nombre de Jours Estimé pour l'affaire", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            

                            remplirNumeroMission();
                            remplirListMission();
                            RemplirNumeroAffaire();
                            RemplirNomRespo();
                            remplirNomEmploye();
                            remplirListAffaire();
                            listeEmployeOrdre.Items.Clear();

                            cmbNumeroMission.Text = txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = txtLieuArriveMission.Text = "";
                            
                        }
                        else
                        {
                            errorProvider1.SetError(btnModifierMission, "Date Fin de Mission doit être Supérieur ou egale Date Debut");
                        }
                    }
                    else
                    {
                        if (cmbRespoMission.Text == "")
                            errorProvider1.SetError(cmbRespoMission, "cette Information est Obligatoir");
                        if (txtDateDebutMission.Text == "")
                            errorProvider1.SetError(txtDateDebutMission, "cette Information est Obligatoir");
                        if (txtDateFinMission.Text == "")
                            errorProvider1.SetError(txtDateFinMission, "cette Information est Obligatoir");
                        if (txtLieuDepartMission.Text == "")
                            errorProvider1.SetError(txtLieuDepartMission, "cette Information est Obligatoir");
                        if (txtLieuArriveMission.Text == "")
                            errorProvider1.SetError(txtLieuArriveMission, "cette Information est Obligatoir");
                        if (cmbNumAffMission.Text == "")
                            errorProvider1.SetError(cmbNumAffMission, "cette Information est Obligatoir");
                    }

                }
                else
                {
                    errorProvider1.SetError(cmbNumeroMission, "Ordre de Mission n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroMission, "choisir une mission");
        }
        private void cmbNumeroMissionRech_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            dt.Rows.Clear();
            dt2.Rows.Clear();

            
            con.Open();

            cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where numero='" + int.Parse(cmbNumeroMission.Text) + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            cmd.Parameters.Clear();

            cmd.CommandText = "select personnel from DetailMission where mission='" + int.Parse(cmbNumeroMission.Text) + "'";
            da.SelectCommand = cmd;
            da.Fill(dt2);

            con.Close();



            cmbRespoMission.Text = dt.Rows[0][1].ToString();
            txtDateDebutMission.Text = dt.Rows[0][2].ToString();
            txtDateFinMission.Text = dt.Rows[0][3].ToString();
            txtLieuDepartMission.Text = dt.Rows[0][5].ToString();
            txtLieuArriveMission.Text = dt.Rows[0][6].ToString();
            cmbNumAffMission.SelectedItem = dt.Rows[0][8].ToString();



            ListMission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListMission.DataSource = dt;

            listeEmployeOrdre.Items.Clear();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                listeEmployeOrdre.Items.Add(dt2.Rows[i][0].ToString());
            }
        }
        private void btnSupprimerMission_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (cmbNumeroMission.Text != "")
            {
                if (IsMissionExists(int.Parse(cmbNumeroMission.Text)))
                {
                    if (MessageBox.Show("voulez-vous supprimer Ordre de Mission?", "Supprimer Ordre de Mission", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();

                        cmd.CommandText = "update Affaires set NbrJourEstimer = NbrJourEstimer + (select NbrJour from Mission where numero = '"+ int.Parse(cmbNumeroMission.Text) +"') where Numero = '"+ cmbNumAffMission.Text +"'";
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        cmd.CommandText = "delete Mission where numero='" + int.Parse(cmbNumeroMission.Text) + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Suppression Avec Succès");

                        remplirNumeroMission();
                        RemplirIdClient();
                        RemplirNomRespo();
                        RemplirNumeroAffaire();
                        remplirListMission();
                        remplirNomEmploye();
                        remplirListAffaire();
                        listeEmployeOrdre.Items.Clear();


                        txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = txtLieuArriveMission.Text = "";
                    }
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroMission,"Ordre de Mission n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroMission, "choisir une Ordre de Mission");
        }
        private void btnLoadListMission_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            remplirNumeroMission();
            remplirListMission();
            RemplirNumeroAffaire();
            RemplirNomRespo();
            listeEmployeOrdre.Items.Clear();

            cmbNumeroMission.Text = txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = txtLieuArriveMission.Text = "";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroMission.Text != "")
            {
                if (IsMissionExists(int.Parse(cmbNumeroMission.Text)))
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Clear();

                    con.Open();

                    cmd.CommandText = "select * from Mission where numero='" + int.Parse(cmbNumeroMission.Text) + "'";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Mission");

                    con.Close();



                    CrystalReport3 cr = new CrystalReport3();
                    cr.Database.Tables["Mission"].SetDataSource(ds.Tables[0]);

                    Form4 f = new Form4();
                    f.crystalReportViewer1.ReportSource = null;
                    f.crystalReportViewer1.ReportSource = cr;
                    f.crystalReportViewer1.Refresh();

                    f.Show();
                    this.Hide();
                }
                else
                    errorProvider1.SetError(cmbNumeroMission, "l'ordre de Mission n'est pas Existant");
            }
            else
                errorProvider1.SetError(cmbNumeroMission, "chisir Numero de Mission");
        }
        private void button2_Click_3(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbEmployeOrdre.Text != "")
            {
                Boolean exsiste = false;
                for (int i = 0; i < listeEmployeOrdre.Items.Count; i++)
                {
                    if (cmbEmployeOrdre.Text == listeEmployeOrdre.Items[i].ToString())
                    {
                        exsiste = true;
                        break;
                    }
                }

                if (exsiste)
                {
                    errorProvider1.SetError(button2, "ce Personne est déjà Existe dans cette Ordre de Mission");
                }
                else
                {
                    listeEmployeOrdre.Items.Add(cmbEmployeOrdre.Text);
                    cmbEmployeOrdre.Items.RemoveAt(cmbEmployeOrdre.SelectedIndex);
                }
            }
            else
                errorProvider1.SetError(cmbEmployeOrdre, "Sélectionnez le Personne");
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            listeEmployeOrdre.Items.Clear();
            remplirNomEmploye();
        }

        // recherche les missions
        private void button4_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Dispose();


            DataTable dt = new DataTable();
            dt.Rows.Clear();


            con.Open();
            if (DateTime.Parse(txtDateFinMissionReche.Value.ToString()) >= DateTime.Parse(txtDateDebutMissionReche.Value.ToString()))
            {
                if (cmbAffMissionReche.Text != "" && cmbRespoMissionReche.Text != "" && txtLieuDepartMissionReche.Text != "" && txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where respo='"
                                                        + cmbRespoMissionReche.Text
                                                        + "' and affaire='" + cmbAffMissionReche.Text
                                                        + "' and lieuDepart='" + txtLieuDepartMissionReche.Text
                                                        + "' and lieuArriver='" + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbAffMissionReche.Text != "" && cmbRespoMissionReche.Text != "" && txtLieuDepartMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where respo='"
                                                        + cmbRespoMissionReche.Text
                                                        + "' and affaire='" + cmbAffMissionReche.Text
                                                        + "' and lieuDepart='" + txtLieuDepartMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbAffMissionReche.Text != "" && cmbRespoMissionReche.Text != "" && txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where respo='"
                                                        + cmbRespoMissionReche.Text
                                                        + "' and affaire='" + cmbAffMissionReche.Text
                                                        + "' and lieuArriver='" + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbAffMissionReche.Text != "" && txtLieuDepartMissionReche.Text != "" && txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where affaire='"
                                                        + cmbAffMissionReche.Text
                                                        + "' and lieuDepart='" + txtLieuDepartMissionReche.Text
                                                        + "' and lieuArriver='" + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbRespoMissionReche.Text != "" && txtLieuDepartMissionReche.Text != "" && txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where respo='"
                                                        + cmbRespoMissionReche.Text
                                                        + "' and lieuDepart='" + txtLieuDepartMissionReche.Text
                                                        + "' and lieuArriver='" + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbAffMissionReche.Text != "" && cmbRespoMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where affaire='"
                                                        + cmbAffMissionReche.Text
                                                        + "' and respo='" + cmbRespoMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbAffMissionReche.Text != "" && txtLieuDepartMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where affaire='"
                                                        + cmbAffMissionReche.Text
                                                        + "' and lieuDepart='" + txtLieuDepartMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbAffMissionReche.Text != "" && txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where affaire='"
                                                        + cmbAffMissionReche.Text
                                                        + "' and lieuArriver='" + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbRespoMissionReche.Text != "" && txtLieuDepartMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where respo='"
                                                        + cmbRespoMissionReche.Text
                                                        + "' and lieuDepart='" + txtLieuDepartMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbRespoMissionReche.Text != "" && txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where respo='"
                                                        + cmbRespoMissionReche.Text
                                                        + "' and lieuArriver='" + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (txtLieuDepartMissionReche.Text != "" && txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where lieuDepart='"
                                                        + txtLieuDepartMissionReche.Text
                                                        + "' and lieuArriver='" + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbAffMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where affaire='"
                                                        + cmbAffMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (cmbRespoMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where respo='"
                                                        + cmbRespoMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text).Date
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text).Date
                                                        + "')";
                }
                else if (txtLieuDepartMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where lieuDepart='"
                                                        + txtLieuDepartMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (txtLieuArriverMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where lieuArriver='"
                                                        + txtLieuArriverMissionReche.Text
                                                        + "' and (dateDebut>= '"
                                                            + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "')";
                }
                else if (txtDateDebutMissionReche.Text != "" && txtDateFinMissionReche.Text != "")
                {
                    cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',nbrPersonne as 'Number de Personne',affaire as 'Affaire' from Mission where dateDebut>='"
                                                        + DateTime.Parse(txtDateDebutMissionReche.Text)
                                                        + "' and dateFin<='"
                                                            + DateTime.Parse(txtDateFinMissionReche.Text)
                                                        + "'";
                }
                else
                    remplirListMission();

                da.SelectCommand = cmd;
                da.Fill(dt);
                con.Close();

                if (dt.Rows != null)
                {
                    ListMissionReche.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ListMissionReche.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Il n'y a pas de Frais entre cette Date");
                }

            }
            else
            {
                errorProvider1.SetError(button4, "Saisir une Date Valide");
            }
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            RemplirNomRespo();
            RemplirNumeroAffaire();
            remplirListMission();
            txtDateDebutMissionReche.Text = txtDateFinMissionReche.Text = txtLieuDepartMissionReche.Text = txtLieuArriverMissionReche.Text ="";

        }
        



        // frais
        private void rbValiderNote_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (rbValiderNote.Checked == true)
            {
                listFraisNote.Rows.Clear();
                cmbNumAffaireNote.Visible = true;
                txtNumeroNote.Visible = true;
                txtDateNote.Enabled = true;
                cmbRespoNote.Visible = true;

                rbModifierSupprimerNote.Checked = false;
                cmbNumeroNote.Visible = false;
                txtNumAff.Visible = false;
                label2.Visible = false;
                txtTotalFraisNote.Visible = false;
                btnSupprimerNoteFrais.Visible = false;
                btnImrimerPdfNote.Visible = false;
                


                RemplirNumeroAffaire();
                txtNumAff.Text = txtTotalFraisNote.Text = "";
            }
        }
        private void rbModifierSupprimerNote_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (rbModifierSupprimerNote.Checked == true)
            {
                listFraisNote.Rows.Clear();
                rbValiderNote.Checked = false;
                txtNumeroNote.Visible = false;
                cmbNumAffaireNote.Visible = false;
                cmbRespoNote.Visible = false;
                cmbNumeroNote.Visible = true;
                txtNumAff.Visible = true;
                txtRespoNote.Visible = true;
                label2.Visible = true;
                txtTotalFraisNote.Visible = true;
                btnSupprimerNoteFrais.Visible = true;
                btnImrimerPdfNote.Visible = true;

                txtDateNote.Enabled = false;

                remplirNumeroNote();
                txtNumAff.Text = txtTotalFraisNote.Text = "";
            }
        }
        private void btnAjouterFrais_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (rbValiderNote.Checked == true)
            {
                if (cmbTypeFrais.Text != "" && cmbPCFrais.Text != "" && txtFraisFrais.Text != "" && txtDateFrais.Text != "")
                {
                    if (double.Parse(txtFraisFrais.Text) >= 0)
                    {
                        if (DateTime.Parse(txtDateFrais.Text) <= DateTime.Now.Date)
                        {
                            listFraisNote.Rows.Add(1, cmbTypeFrais.Text, cmbPCFrais.Text, txtDateFrais.Text, txtFraisFrais.Text);

                            remplirTypeNote();
                            remplirPCNote();
                            txtDateFrais.Text = "";
                            txtFraisFrais.Text = "";
                            txtFraisFrais.Enabled = true;
                            cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDownList;
                            numeroFrais();
                        }
                        else
                            errorProvider1.SetError(txtDateFrais, "Date de Frais il doit inférieur ou egale Date d'aujourd'hui");
                    }
                    else
                        errorProvider1.SetError(txtFraisFrais,"Saisir Frais Valide");
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
            else
            {
                if (cmbTypeFrais.Text != "" && cmbPCFrais.Text != "" && txtFraisFrais.Text != "" && txtDateFrais.Text != "")
                {
                    if (double.Parse(txtFraisFrais.Text) >= 0)
                    {
                        if (DateTime.Parse(txtDateFrais.Text) <= DateTime.Now.Date)
                        {
                            listFraisNote.Rows.Add(1, cmbTypeFrais.Text, cmbPCFrais.Text, txtDateFrais.Text, txtFraisFrais.Text);


                            remplirTypeNote();
                            remplirPCNote();
                            txtDateFrais.Text = "";
                            txtFraisFrais.Text = "";
                            txtFraisFrais.Enabled = true;
                            cmbTypeFrais.DropDownStyle = ComboBoxStyle.DropDownList;
                            numeroFrais();

                        }
                        else
                            errorProvider1.SetError(txtDateFrais, "Date de Frais il doit inférieur ou egale Date d'aujourd'hui");
                    }
                    else
                    {
                        errorProvider1.SetError(txtFraisFrais, "Saisir Frais Valide");
                    }
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
        private void listFraisNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Dispose();

            if (rbModifierSupprimerNote.Checked == true)
            {
                if (listFraisNote.CurrentCell.Value.ToString() == "Supprimer")
                {
                    if (MessageBox.Show("voulez-vous supprimer Frais?", "Supprimer Frais", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int num = int.Parse(listFraisNote.Rows[e.RowIndex].Cells[0].Value.ToString());
                        con.Open();
                        cmd.CommandText = "delete Frais where Numero='" + num + "' and noteFrais='" + int.Parse(cmbNumeroNote.Text) +"'";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        listFraisNote.Rows.RemoveAt(e.RowIndex);

                        remplirListFrais();
                        numeroFrais();
                    }
                }
            }
            else
            {
                if (listFraisNote.CurrentCell.Value.ToString() == "Supprimer")
                {
                    listFraisNote.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        // recherche les frais
        private void btnRechercheFraisNote_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            
            DataTable dt = new DataTable();
            dt.Rows.Clear();

            con.Open();

            if (DateTime.Parse(txtDateFinFraisRecheNote.Value.ToString()) >= DateTime.Parse(txtDateDebutFraisRecheNote.Value.ToString()))
            {
                if (cmbTypeFraisRecheNote.Text != "" && cmbPCFraisRecheNote.Text != "")
                {
                    cmd.CommandText = "select Numero,Type,PiecesComptables as 'Piece Comptable',Frais,Date,noteFrais as 'Note de Frais' from Frais where Type='" 
                                                        + cmbTypeFraisRecheNote.Text
                                                        + "' and PiecesComptables='" + cmbPCFraisRecheNote.Text
                                                        + "' and date between '"
                                                            + DateTime.Parse(txtDateDebutFraisRecheNote.Text)
                                                            + "' and '"
                                                            + DateTime.Parse(txtDateFinFraisRecheNote.Text)
                                                        + "' and frais between '"
                                                            + double.Parse(txtMinFraisFraisRecheNote.Value.ToString())
                                                            + "' and '"
                                                            + double.Parse(txtMaxFraisFraisRecheNote.Value.ToString()) + "'";
                }
                else if (cmbTypeFraisRecheNote.Text != "")
                {
                    cmd.CommandText = "select Numero,Type,PiecesComptables as 'Piece Comptable',Frais,Date,noteFrais as 'Note de Frais' from Frais where Type='"
                                                        + cmbTypeFraisRecheNote.Text
                                                        + "' and date between '"
                                                            + DateTime.Parse(txtDateDebutFraisRecheNote.Text)
                                                            + "' and '"
                                                            + DateTime.Parse(txtDateFinFraisRecheNote.Text)
                                                        + "' and frais between '"
                                                            + double.Parse(txtMinFraisFraisRecheNote.Value.ToString())
                                                            + "' and '"
                                                            + double.Parse(txtMaxFraisFraisRecheNote.Value.ToString()) + "'";
                }
                else if (cmbPCFraisRecheNote.Text != "")
                {
                    cmd.CommandText = "select Numero,Type,PiecesComptables as 'Piece Comptable',Frais,Date,noteFrais as 'Note de Frais' from Frais where PiecesComptables='"
                                                        + cmbPCFraisRecheNote.Text
                                                        + "' and date between '"
                                                            + DateTime.Parse(txtDateDebutFraisRecheNote.Text)
                                                            + "' and '"
                                                            + DateTime.Parse(txtDateFinFraisRecheNote.Text)
                                                        + "' and frais between '"
                                                            + double.Parse(txtMinFraisFraisRecheNote.Value.ToString())
                                                            + "' and '"
                                                            + double.Parse(txtMaxFraisFraisRecheNote.Value.ToString()) + "'";
                }
                else
                {
                    cmd.CommandText = "select Numero,Type,PiecesComptables as 'Piece Comptable',Frais,Date,noteFrais as 'Note de Frais' from Frais where date between '"
                                                            + DateTime.Parse(txtDateDebutFraisRecheNote.Text)
                                                            + "' and '"
                                                            + DateTime.Parse(txtDateFinFraisRecheNote.Text)
                                                        + "' and frais between '"
                                                            + double.Parse(txtMinFraisFraisRecheNote.Value.ToString())
                                                            + "' and '"
                                                            + double.Parse(txtMaxFraisFraisRecheNote.Value.ToString()) + "'";
                }

                da.SelectCommand = cmd;
                da.Fill(dt);
                con.Close();

                if (dt.Rows != null)
                {
                    ListRechercheFraisNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ListRechercheFraisNote.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Il n'y a pas de Frais entre cette Date");
                }
            }
            else
            {
                errorProvider1.SetError(btnRechercheFraisNote, "la Date Début il doit etre Supérieur ou égal Date Fin");
            }
        }
        private void btnActualiserFraisNoteReche_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            remplirTypeNote();
            remplirPCNote();
            txtDateDebutFraisRecheNote.Text = txtDateFinFraisRecheNote.Text = "";
            txtMinFraisFraisRecheNote.Value = 0;
            txtMaxFraisFraisRecheNote.Value = 10000;

            remplirListFrais();

            cmbTypeFraisRecheNote.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPCFraisRecheNote.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void cmbTypeFraisRecheNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeFraisRecheNote.Text == "Redéfinir...")
            {
                cmbTypeFraisRecheNote.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTypeFraisRecheNote.Text = "";
            }
            else
            {
                cmbTypeFraisRecheNote.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void cmbPCFraisRecheNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPCFraisRecheNote.Text == "Redéfinir...")
            {
                cmbPCFraisRecheNote.DropDownStyle = ComboBoxStyle.DropDown;
                cmbPCFraisRecheNote.Text = "";
            }
            else
            {
                cmbPCFraisRecheNote.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            RemplirIdClient();
            RemplirNumeroAffaire();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            remplirListFraisNote();
            remplirNumeroNote();
            remplirTypeNote();
            remplirPCNote();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            remplirNumeroNote();
            remplirTypeNote();
            remplirPCNote();
            RemplirNumeroAffaire();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            txtNomRespo.Text = txtPrenomRespo.Text = txtICEClient.Text = txtRaisonSocialClient.Text = txtNomPersonne.Text = txtPrenomPresonne.Text = "";

            RemplirIdClient();
            remplirListClient();
            RemplirNomRespo();
            remplirListRespo();
            remplirNomEmploye();
            remplirListEmploye();

        }



        private void btnSupprimerFrais_Click(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e){}
        private void cmbCinBeneRech_SelectedIndexChanged(object sender, EventArgs e){}
        private void btnLoadListBene_Click(object sender, EventArgs e){}
        private void btnValiderBene_Click(object sender, EventArgs e){}
        private void btnModifierBene_Click(object sender, EventArgs e){}
        private void btnSupprimer_Click(object sender, EventArgs e){}
        private void cmbNumNoteRech_SelectedIndexChanged(object sender, EventArgs e){}
        private void btnModifierNote_Click(object sender, EventArgs e){}
        private void btnSupprimerNote_Click(object sender, EventArgs e){}
        private void cmbPCNoteRech_SelectedIndexChanged(object sender, EventArgs e){}
        private void btnValiderMission_Click(object sender, EventArgs e) {}
        private void txtMontantAffAjouter_Validating(object sender, CancelEventArgs e){}
        private void imprimerToolStripMenuItem_Click(object sender, EventArgs e){}
        private void button6_Click(object sender, EventArgs e){}
        private void button7_Click_1(object sender, EventArgs e){}
        private void button6_Click_1(object sender, EventArgs e){}
        private void BoxClient_Enter(object sender, EventArgs e){}
        private void checkBox1_CheckedChanged(object sender, EventArgs e){}
        private void checkBox2_CheckedChanged(object sender, EventArgs e){}
        private void radioButton1_CheckedChanged(object sender, EventArgs e){}
        private void BoxClientAjouter_Enter(object sender, EventArgs e){}
        private void noteDeFraisToolStripMenuItem_Click(object sender, EventArgs e){}
        private void missionToolStripMenuItem_Click(object sender, EventArgs e){}
        private void txtNumeroNote_TextChanged(object sender, EventArgs e){}
        private void ListAff_CellContentClick(object sender, DataGridViewCellEventArgs e){}
        private void ListAff_CellClick(object sender, DataGridViewCellEventArgs e){}
        private void ListAff_CellContentClick_1(object sender, DataGridViewCellEventArgs e){}
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e){}
        private void missionToolStripMenuItem2_Click(object sender, EventArgs e){}
        private void beneficaireToolStripMenuItem_Click(object sender, EventArgs e){}
        private void beneficaireToolStripMenuItem1_Click(object sender, EventArgs e){}
        private void noteDeFraisToolStripMenuItem1_Click(object sender, EventArgs e){}
        private void BoxMissionReche_Enter(object sender, EventArgs e){}
        private void cmbNumeroNote_SelectedIndexChanged(object sender, EventArgs e){}
    }
}
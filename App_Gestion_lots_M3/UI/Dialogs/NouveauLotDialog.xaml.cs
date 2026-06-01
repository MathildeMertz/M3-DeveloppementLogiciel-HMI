using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using Microsoft.UI.Xaml.Controls;

namespace App_Gestion_lots_M3.UI.Dialogs;

public sealed partial class NouveauLotDialog : ContentDialog
{
    private readonly Lot? _lotInitial;
    private readonly bool _modeCreation;

    public NouveauLotDialog(Lot? lot = null)
    {
        InitializeComponent();

        _lotInitial = lot;
        _modeCreation = lot == null;

        RemplirCombos();
        ConfigurerFormulaire();
    }

    private void RemplirCombos()
    {
        cboRecette.ItemsSource = DAL.GetRecettes().Select(r => r.REC_Nom).ToList();
        cboEtat.ItemsSource = DAL.GetEtats().Select(e => e.ETA_Libelle).ToList();
    }

    private void ConfigurerFormulaire()
    {
        if (_modeCreation)
        {
            Title = "Nouveau Lot";
            PrimaryButtonText = "Enregistrer";
            SecondaryButtonText = string.Empty;
            txtNomLot.Text = string.Empty;
            txtNomLot.IsReadOnly = false;
            nudQuantite.Value = 1;
            cboEtat.SelectedItem = "En attente";
            lblDateCreation.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
        else
        {
            Title = "Modifier Lot - " + _lotInitial!.LOT_Nom;
            PrimaryButtonText = "Enregistrer";
            SecondaryButtonText = "Supprimer";
            txtNomLot.Text = _lotInitial.LOT_Nom;
            txtNomLot.IsReadOnly = true;
            nudQuantite.Value = _lotInitial.LOT_Quantite;
            cboRecette.SelectedItem = _lotInitial.REC_Nom;
            cboEtat.SelectedItem = _lotInitial.ETA_Libelle;
            lblDateCreation.Text = _lotInitial.LOT_DateHeureCreation.ToString("dd/MM/yyyy HH:mm");
        }
    }

    private bool Valider(out string message)
    {
        if (string.IsNullOrWhiteSpace(txtNomLot.Text))
        {
            message = "Le nom du lot est obligatoire.";
            return false;
        }
        if (double.IsNaN(nudQuantite.Value) || nudQuantite.Value < 1)
        {
            message = "La quantité doit être un entier positif.";
            return false;
        }
        if (cboRecette.SelectedItem == null)
        {
            message = "Veuillez sélectionner une recette.";
            return false;
        }
        if (cboEtat.SelectedItem == null)
        {
            message = "Veuillez sélectionner un état.";
            return false;
        }
        if (_modeCreation)
        {
            var nom = txtNomLot.Text.Trim();
            foreach (var existant in DAL.GetLots())
            {
                if (string.Equals(existant.LOT_Nom, nom, StringComparison.OrdinalIgnoreCase))
                {
                    message = "Un lot avec ce nom existe déjà.";
                    return false;
                }
            }
        }
        message = string.Empty;
        return true;
    }

    private void OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        if (!Valider(out var message))
        {
            ValidationInfoBar.Title = "Validation";
            ValidationInfoBar.Message = message;
            ValidationInfoBar.IsOpen = true;
            args.Cancel = true;
            return;
        }

        var recetteNom = (string)cboRecette.SelectedItem!;
        var etatNom = (string)cboEtat.SelectedItem!;
        var recette = DAL.GetRecettes().First(r => r.REC_Nom == recetteNom);
        var etat = DAL.GetEtats().First(e => e.ETA_Libelle == etatNom);

        if (_modeCreation)
        {
            DAL.AjouterLot(new Lot
            {
                LOT_Nom = txtNomLot.Text.Trim(),
                LOT_Quantite = (int)nudQuantite.Value,
                LOT_DateHeureCreation = DateTime.Now,
                Id_Recette = recette.Id_Recette,
                REC_Nom = recette.REC_Nom,
                Id_Etat = etat.Id_Etat,
                ETA_Libelle = etat.ETA_Libelle,
            });
        }
        else
        {
            DAL.ModifierLot(_lotInitial!.LOT_Nom, new Lot
            {
                Id_Lot = _lotInitial.Id_Lot,
                LOT_Nom = _lotInitial.LOT_Nom,
                LOT_Quantite = (int)nudQuantite.Value,
                LOT_DateHeureCreation = _lotInitial.LOT_DateHeureCreation,
                Id_Recette = recette.Id_Recette,
                REC_Nom = recette.REC_Nom,
                Id_Etat = etat.Id_Etat,
                ETA_Libelle = etat.ETA_Libelle,
            });
        }
    }
}

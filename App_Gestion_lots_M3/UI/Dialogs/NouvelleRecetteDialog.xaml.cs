using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace App_Gestion_lots_M3.UI.Dialogs;

public sealed partial class NouvelleRecetteDialog : ContentDialog
{
    private readonly Recette? _recetteInitiale;
    private readonly bool _modeCreation;

    // Binding direct sur le type domaine Operation. La conversion
    // bool→"Oui"/"Non" est gérée dans le XAML par BoolToYesNoConverter.
    private readonly ObservableCollection<Operation> _operations = new();

    public NouvelleRecetteDialog(Recette? recette = null)
    {
        InitializeComponent();
        _recetteInitiale = recette;
        _modeCreation = recette == null;

        grdOperations.ItemsSource = _operations;
        ConfigurerFormulaire();
    }

    private void ConfigurerFormulaire()
    {
        if (_modeCreation)
        {
            Title = "Nouvelle Recette";
            PrimaryButtonText = "Enregistrer";
            txtNomRecette.Text = string.Empty;
            txtNomRecette.IsReadOnly = false;
            lblDateCreation.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            Title = "Modifier Recette - " + _recetteInitiale!.REC_Nom;
            PrimaryButtonText = "Enregistrer modifications";
            txtNomRecette.Text = _recetteInitiale.REC_Nom;
            txtNomRecette.IsReadOnly = true;
            lblDateCreation.Text = _recetteInitiale.REC_DateHeureCreation.ToString("dd/MM/yyyy");

            // DAL.GetOperations renvoie déjà des Operation : pas de projection.
            foreach (var op in DAL.GetOperations(_recetteInitiale.Id_Recette))
            {
                _operations.Add(op);
            }
        }
    }

    // Flyout — Annuler. Reset to defaults and dismiss without committing.
    private void fltCancel_Click(object sender, RoutedEventArgs e)
    {
        ResetFlyoutForm();
        btnAjouterOperation.Flyout?.Hide();
    }

    // Flyout — Ajouter. Validate the per-recipe cap, append a new Operation
    // built directly from the flyout's NumberBox / ComboBox values.
    private void fltAdd_Click(object sender, RoutedEventArgs e)
    {
        if (_operations.Count >= 10)
        {
            ValidationInfoBar.Title = "Limite atteinte";
            ValidationInfoBar.Message = "Maximum 10 opérations par recette.";
            ValidationInfoBar.IsOpen = true;
            return;
        }

        var nouvelle = new Operation
        {
            OPE_PositionMoteur = (int)fltPosition.Value,
            OPE_TempsAttente = (int)fltTemps.Value,
            OPE_Quittance = (fltQuittance.SelectedItem as string) == "Oui",
            // Les autres champs (Id_Operation, OPE_Nom, OPE_CycleVerin,
            // OPE_SensMoteur, CON_NoOperation) restent à leurs valeurs par
            // défaut — la DAL persistera la liste telle quelle.
        };
        _operations.Add(nouvelle);
        grdOperations.SelectedItem = nouvelle;
        grdOperations.ScrollIntoView(nouvelle);
        ValidationInfoBar.IsOpen = false;

        ResetFlyoutForm();
        btnAjouterOperation.Flyout?.Hide();
    }

    private void ResetFlyoutForm()
    {
        fltPosition.Value = 1;
        fltTemps.Value = 0;
        fltQuittance.SelectedIndex = 1; // "Non"
    }

    private void btnSupprimerOperation_Click(object sender, RoutedEventArgs e)
    {
        if (grdOperations.SelectedItem is Operation op)
        {
            _operations.Remove(op);
            ValidationInfoBar.IsOpen = false;
        }
        else
        {
            ValidationInfoBar.Title = "Sélection requise";
            ValidationInfoBar.Message = "Veuillez sélectionner une opération à supprimer.";
            ValidationInfoBar.IsOpen = true;
        }
    }

    private bool Valider(out string message)
    {
        if (string.IsNullOrWhiteSpace(txtNomRecette.Text))
        {
            message = "Le nom de la recette est obligatoire.";
            return false;
        }
        if (_operations.Count == 0)
        {
            message = "La recette doit contenir au moins une opération.";
            return false;
        }
        if (_modeCreation)
        {
            var nom = txtNomRecette.Text.Trim();
            foreach (var r in DAL.GetRecettes())
            {
                if (string.Equals(r.REC_Nom, nom, StringComparison.OrdinalIgnoreCase))
                {
                    message = "Une recette avec ce nom existe déjà.";
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

        if (_modeCreation)
        {
            var recette = new Recette
            {
                REC_Nom = txtNomRecette.Text.Trim(),
                REC_DateHeureCreation = DateTime.Now,
                Operations = _operations.ToList(),
            };
            DAL.AjouterRecette(recette);
        }
        else
        {
            var recette = new Recette
            {
                REC_Nom = _recetteInitiale!.REC_Nom,
                REC_DateHeureCreation = _recetteInitiale.REC_DateHeureCreation,
                Operations = _operations.ToList(),
            };
            DAL.ModifierRecette(_recetteInitiale.Id_Recette, recette);
        }
    }
}

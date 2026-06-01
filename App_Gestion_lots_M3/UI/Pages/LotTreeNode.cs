using App_Gestion_lots_M3.Model;
using System.Collections.ObjectModel;

namespace App_Gestion_lots_M3.UI.Pages;

// Wrapper "projection nullable" qui expose directement les types domaine.
// Chaque noeud est SOIT un Lot (parent) SOIT un Evenement (feuille) — jamais
// les deux. Le DataTemplate de LotsPage utilise {x:Bind Lot.X} et
// {x:Bind Evenement.X} : les chemins de propagation null compilés par
// x:Bind retombent sur FallbackValue='' quand la racine est null, ce qui
// permet à UN SEUL DataTemplate de couvrir les deux niveaux sans
// sélecteur de template ni type intermédiaire synthétique.
public sealed class LotTreeNode
{
    public Lot? Lot { get; init; }
    public Evenement? Evenement { get; init; }
    public ObservableCollection<LotTreeNode>? Children { get; init; }
}

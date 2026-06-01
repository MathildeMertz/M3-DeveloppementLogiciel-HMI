using App_Gestion_lots_M3.Model;
using System.Collections.ObjectModel;

namespace App_Gestion_lots_M3.UI.Pages;

// Même pattern que LotTreeNode : une Recette OU une Operation, jamais les
// deux. Le DataTemplate de RecettesPage binde directement sur Recette.X /
// Operation.X via x:Bind avec propagation null + FallbackValue=''.
public sealed class RecetteTreeNode
{
    public Recette? Recette { get; init; }
    public Operation? Operation { get; init; }
    public ObservableCollection<RecetteTreeNode>? Children { get; init; }
}

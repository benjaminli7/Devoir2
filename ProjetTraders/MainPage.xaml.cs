using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProjetModel;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjetTraders
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        Dictionary<string, List<ActionAchetee>> dico;
        List<ActionReelle> lesActionsReelles;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dico = new Dictionary<string, List<ActionAchetee>>();
            lesActionsReelles = new List<ActionReelle>();
            #region jeu d'essais pour le dico

            dico.Add("Enzo", new List<ActionAchetee>()
            {
                new ActionAchetee()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200,
                    PrixAchat = 210,
                    Quantite = 10
                },

                new ActionAchetee()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 140,
                    PrixAchat = 100,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 35,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140,
                    PrixAchat = 110,
                    Quantite = 40
                }
            });

            dico.Add("Noa", new List<ActionAchetee>()
            {
                new ActionAchetee()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25,
                    PrixAchat = 15,
                    Quantite = 20
                },

                new ActionAchetee()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120,
                    PrixAchat = 100,
                    Quantite = 30
                }
            });

            dico.Add("Lilou", new List<ActionAchetee>()
            {
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 25,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50,
                    PrixAchat = 35,
                    Quantite = 15
                },
                new ActionAchetee()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145,
                    PrixAchat = 150,
                    Quantite = 30
                },
                new ActionAchetee()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130,
                    PrixAchat = 140,
                    Quantite = 25
                }
            });
            #endregion

            #region jeu d'essais pour la liste de toutes les actions réelles
            lesActionsReelles.Add
            (
            new ActionReelle()
            {
                CodeAction = "AAPL",
                NomAction = "Apple",
                ValeurAction = 200
            });
            lesActionsReelles.Add
            (
            new ActionReelle()
            {
                CodeAction = "MSFT",
                NomAction = "Microsoft",
                ValeurAction = 14
            });
            lesActionsReelles.Add
            (
            new ActionReelle()
            {
                CodeAction = "TWTR",
                NomAction = "Twitter",
                ValeurAction = 40
            });
            lesActionsReelles.Add
            (
            new ActionReelle()
            {
                CodeAction = "IBM",
                NomAction = "International Business Machines",
                ValeurAction = 140
            });
            lesActionsReelles.Add
            (
            new ActionReelle()
            {
                CodeAction = "FB",
                NomAction = "Facebook",
                ValeurAction = 180
            });
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25
                }
            );

            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120
                }
            );

            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50
                }
             );

            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145
                }
            );

            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130
                }
            );

            #endregion
            lvTraders.ItemsSource = dico.Keys;
            lvAchat.ItemsSource = lesActionsReelles;
        }

        private async void BtnAcheter_Click(object sender, RoutedEventArgs e)
        {
            if(lvTraders.SelectedItem != null)
            {
                double prixAchat = 0;
                int quantite = 0;
                if(txtBoxPrixAchat.Text == "")
                {
                    var dialog4 = new MessageDialog("Saisissez le prix d'achat !");
                    await dialog4.ShowAsync();
                }
                else
                {
                    prixAchat = Convert.ToDouble(txtBoxPrixAchat.Text);
                }

                if(txtBoxQuantite.Text == "")
                {
                    var dialog5 = new MessageDialog("Saisissez la quantité !");
                    await dialog5.ShowAsync();
                }
                else
                {
                    quantite = Convert.ToInt32(txtBoxQuantite.Text);
                }

                if(txtBoxPrixAchat.Text != "" && txtBoxQuantite.Text != "")
                {
                    ActionAchetee aa = new ActionAchetee()
                    {
                        CodeAction = (lvAchat.SelectedItem as ActionReelle).CodeAction,
                        NomAction = (lvAchat.SelectedItem as ActionReelle).NomAction,
                        ValeurAction = (lvAchat.SelectedItem as ActionReelle).ValeurAction,
                        Quantite = quantite,
                        PrixAchat = prixAchat
                    };

                    dico[lvTraders.SelectedItem.ToString()].Add(aa);
                    lvActions.ItemsSource = null;
                    lvActions.ItemsSource = dico[lvTraders.SelectedItem.ToString()];
                }


                // on renouvelle le portefeuille du trader
                double mtPortefeuille = 0;
                foreach (ActionAchetee a in dico[lvTraders.SelectedItem.ToString()])
                {
                    mtPortefeuille += a.Quantite * a.PrixAchat;
                }
                txtBoxPortefeuille.Text = mtPortefeuille.ToString();
            }
            else
            {
                var dialog3 = new MessageDialog("Sélectionnez une action à acheter !");
                await dialog3.ShowAsync();
            }
        }

        private async void BtnVendre_Click(object sender, RoutedEventArgs e)
        {
            if(lvActions.SelectedItem != null)
            {
                if((lvActions.SelectedItem as ActionAchetee).Quantite == Convert.ToInt32(txtBoxQteVendue.Text))
                {
                    dico[lvTraders.SelectedItem.ToString()].Remove(lvActions.SelectedItem as ActionAchetee);
                }
                else if((lvActions.SelectedItem as ActionAchetee).Quantite > Convert.ToInt32(txtBoxQteVendue.Text))
                {
                    (lvActions.SelectedItem as ActionAchetee).Quantite = (lvActions.SelectedItem as ActionAchetee).Quantite - Convert.ToInt32(txtBoxQteVendue.Text);
                }
                else if ((lvActions.SelectedItem as ActionAchetee).Quantite < Convert.ToInt32(txtBoxQteVendue.Text))
                {
                    var dialog = new MessageDialog("La quantité que vous voulez vendre dépasse le nombre d'actions que vous possédez !");
                    await dialog.ShowAsync();
                }
                lvActions.ItemsSource = null;
                lvActions.ItemsSource = dico[lvTraders.SelectedItem.ToString()];

                //on renouvelle le portefeuille du trader
                double mtPortefeuille = 0;
                foreach (ActionAchetee aa in dico[lvTraders.SelectedItem.ToString()])
                {
                    mtPortefeuille += aa.Quantite * aa.PrixAchat;
                }
                txtBoxPortefeuille.Text = mtPortefeuille.ToString();
            }
            else
            {
                var dialog1 = new MessageDialog("Sélectionnez une action à vendre !");
                await dialog1.ShowAsync();
            }
        }

        private void LvTraders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvTraders.SelectedItem != null)
            {
                lvActions.ItemsSource = null;
                lvActions.ItemsSource = dico[lvTraders.SelectedItem.ToString()];

                // on affiche le portefeuille du trader
                double mtPortefeuille = 0;
                foreach(ActionAchetee aa in dico[lvTraders.SelectedItem.ToString()])
                {
                    mtPortefeuille += aa.Quantite * aa.PrixAchat;
                }
                txtBoxPortefeuille.Text = mtPortefeuille.ToString();

                // on clear les champs de texte de "Vente"
                txtBoxNomAction.Text = "";
                txtBoxValeurAction.Text = "";
                txtBoxPrixAchats.Text = "";
                txtBoxQteAchetee.Text = "";
            }
        }

        private void LvActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvActions.SelectedItem != null)
            {
                txtBoxNomAction.Text = (lvActions.SelectedItem as ActionAchetee).NomAction;
                txtBoxValeurAction.Text = (lvActions.SelectedItem as ActionAchetee).ValeurAction.ToString();
                txtBoxPrixAchats.Text = (lvActions.SelectedItem as ActionAchetee).PrixAchat.ToString();
                txtBoxQteAchetee.Text = (lvActions.SelectedItem as ActionAchetee).Quantite.ToString();
            }
        }
    }
}

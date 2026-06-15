using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace convertisseur_d_Unités
{
    /// <summary>
    /// Fenêtre principale du convertisseur.
    /// Contient :
    /// - un menu (boutons) pour choisir le type de conversion
    /// - des écrans de conversion (Température / Volume / Poids / Longueur)
    /// - un bouton Retour pour revenir au menu
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Initialise les éléments graphiques définis dans MainWindow.xaml
            InitializeComponent();
        }

        // -----------------------------
        // Navigation entre les écrans
        // -----------------------------        

        // Affiche l’écran Température + le bouton Retour, et masque les autres.
        private void btnTemperature_Click(object sender, RoutedEventArgs e)
        {
            spButtons.Visibility = Visibility.Collapsed;
            spConvertisseurs.Visibility = Visibility.Visible;
            spTemperature.Visibility = Visibility.Visible;
            spVolume.Visibility = Visibility.Collapsed;
            spWeight.Visibility = Visibility.Collapsed;
            spLenght.Visibility = Visibility.Collapsed;
            spReturn.Visibility = Visibility.Visible;
        }

        // Affiche l’écran Volume + le bouton Retour, et masque les autres.
        private void btnVolume_Click(object sender, RoutedEventArgs e)
        {
            spButtons.Visibility = Visibility.Collapsed;
            spConvertisseurs.Visibility = Visibility.Visible;
            spTemperature.Visibility = Visibility.Collapsed;
            spVolume.Visibility = Visibility.Visible;
            spWeight.Visibility = Visibility.Collapsed;
            spLenght.Visibility = Visibility.Collapsed;
            spReturn.Visibility = Visibility.Visible;
        }

        // Affiche l’écran Poids + le bouton Retour, et masque les autres.
        private void btnWeight_Click(object sender, RoutedEventArgs e)
        {
            spButtons.Visibility = Visibility.Collapsed;
            spConvertisseurs.Visibility = Visibility.Visible;
            spTemperature.Visibility = Visibility.Collapsed;
            spVolume.Visibility = Visibility.Collapsed;
            spWeight.Visibility = Visibility.Visible;
            spLenght.Visibility = Visibility.Collapsed;
            spReturn.Visibility = Visibility.Visible;
        }

        // Affiche l’écran Longueur + le bouton Retour, et masque les autres.
        private void btnLength_Click(object sender, RoutedEventArgs e)
        {
            spButtons.Visibility = Visibility.Collapsed;
            spConvertisseurs.Visibility = Visibility.Visible;
            spTemperature.Visibility = Visibility.Collapsed;
            spVolume.Visibility = Visibility.Collapsed;
            spWeight.Visibility = Visibility.Collapsed;
            spLenght.Visibility = Visibility.Visible;
            spReturn.Visibility = Visibility.Visible;
        }

        // Revient au menu : masque tous les écrans de conversion et le bouton Retour.
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            spButtons.Visibility = Visibility.Visible;
            spConvertisseurs.Visibility = Visibility.Collapsed;
            spTemperature.Visibility = Visibility.Collapsed;
            spVolume.Visibility = Visibility.Collapsed;
            spWeight.Visibility = Visibility.Collapsed;
            spLenght.Visibility = Visibility.Collapsed;
            spReturn.Visibility = Visibility.Collapsed;
        }

        // -----------------------------
        // Température
        // -----------------------------

        // Quand l’unité source change, on réinitialise la saisie et le résultat.
        private void cbTemperatureSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbTemperatureResultat.ClearValue(TextBlock.TextProperty);
            txtTemperatureSource.Clear();
        }

        // Quand l’unité cible change, on réinitialise la saisie et le résultat.
        private void cbTemperatureCible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbTemperatureResultat.ClearValue(TextBlock.TextProperty);
            txtTemperatureSource.Clear();
        }

        // Recalcule le résultat à chaque modification du champ de saisie.
        private void txtTemperatureSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Récupère les valeurs sélectionnées dans les ComboBox (source / cible)
            string? source = (cbTemperatureSource.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? cible = (cbTemperatureCible.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Si l’utilisateur n’a pas encore choisi les unités, on ne calcule rien.
            if (source is null || cible is null)
                return;

            // Si le champ est vide, on efface le texte affiché.
            if (string.IsNullOrEmpty(txtTemperatureSource.Text))
            {
                tbTemperatureResultat.ClearValue(TextBlock.TextProperty);
                return;
            }

            // Vérifie que la saisie est bien un nombre.
            if (!double.TryParse(txtTemperatureSource.Text, out double value))
            {
                tbTemperatureResultat.Text = "0";
                return;
            }

            // Conversion selon l’unité cible (switch/case), puis selon l’unité source.
            switch (cible)
            {
                case "Celsius":
                    switch (source)
                    {
                        case "Celsius":
                            tbTemperatureResultat.Text = value.ToString("0.##");
                            break;
                        case "Fahrenheit":
                            tbTemperatureResultat.Text = ((value - 32) * 5 / 9).ToString("0.##");
                            break;
                        case "Kelvin":
                            tbTemperatureResultat.Text = (value - 273.15).ToString("0.##");
                            break;
                    }
                    break;

                case "Fahrenheit":
                    switch (source)
                    {
                        case "Celsius":
                            tbTemperatureResultat.Text = ((value * 9 / 5) + 32).ToString("0.##");
                            break;
                        case "Fahrenheit":
                            tbTemperatureResultat.Text = value.ToString("0.##");
                            break;
                        case "Kelvin":
                            tbTemperatureResultat.Text = (((value - 273.15) * 9 / 5) + 32).ToString("0.##");
                            break;
                    }
                    break;

                case "Kelvin":
                    switch (source)
                    {
                        case "Celsius":
                            tbTemperatureResultat.Text = (value + 273.15).ToString("0.##");
                            break;
                        case "Fahrenheit":
                            tbTemperatureResultat.Text = (((value - 32) * 5 / 9) + 273.15).ToString("0.##");
                            break;
                        case "Kelvin":
                            tbTemperatureResultat.Text = value.ToString("0.##");
                            break;
                    }
                    break;
            }
        }

        // Validation de la saisie température, accepte les chiffres et les séparateurs décimaux avant et après la virgule.
        private void txtTemperatureSource_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"0123456789,.".Contains(e.Text);
        }

        // -----------------------------
        // Volume
        // -----------------------------

        // Reset sur changement d’unité source.
        private void cbVolumeSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbVolumeResultat.ClearValue(TextBlock.TextProperty);
            txtVolumeSource.Clear();
        }

        // Reset sur changement d’unité cible.
        private void cbVolumeCible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbVolumeResultat.ClearValue(TextBlock.TextProperty);
            txtVolumeSource.Clear();
        }

        // Conversion du volume à chaque changement de saisie.
        private void txtVolumeSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            string? source = (cbVolumeSource.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? cible = (cbVolumeCible.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (source is null || cible is null)
                return;

            if (string.IsNullOrEmpty(txtVolumeSource.Text))
            {
                tbVolumeResultat.ClearValue(TextBlock.TextProperty);
                return;
            }

            if (!double.TryParse(txtVolumeSource.Text, out double value))
            {
                tbVolumeResultat.Text = "0";
                return;
            }

            // Conversion selon l’unité cible, puis selon l’unité source.
            switch (cible)
            {
                case "Litres":
                    // vers Litres
                    switch (source)
                    {
                        case "Litres":
                            tbVolumeResultat.Text = value.ToString("0.##");
                            break;
                        case "Millilitres":
                            tbVolumeResultat.Text = (value / 1000.0).ToString("0.##");
                            break;
                        case "Mètres cubes":
                            tbVolumeResultat.Text = (value * 1000.0).ToString("0.##");
                            break;
                    }
                    break;

                case "Millilitres":
                    // vers Millilitres
                    switch (source)
                    {
                        case "Litres":
                            tbVolumeResultat.Text = (value * 1000.0).ToString("0.##");
                            break;
                        case "Millilitres":
                            tbVolumeResultat.Text = value.ToString("0.##");
                            break;
                        case "Mètres cubes":
                            tbVolumeResultat.Text = (value * 1_000_000.0).ToString("0.##");
                            break;
                    }
                    break;

                case "Mètres cubes":
                    // vers Mètres cubes
                    switch (source)
                    {
                        case "Litres":
                            tbVolumeResultat.Text = (value / 1000.0).ToString("0.##");
                            break;
                        case "Millilitres":
                            tbVolumeResultat.Text = (value / 1_000_000.0).ToString("0.##");
                            break;
                        case "Mètres cubes":
                            tbVolumeResultat.Text = value.ToString("0.##");
                            break;
                    }
                    break;
            }
        }

        // Validation de la saisie volume, accepte les chiffres et les séparateurs décimaux avant et après la virgule.
        private void txtVolumeSource_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"0123456789,.".Contains(e.Text);
        }

        // -----------------------------
        // Poids
        // -----------------------------

        // Reset sur changement d’unité source.
        private void cbWeightSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbWeightResultat.ClearValue(TextBlock.TextProperty);
            txtWeightSource.Clear();
        }

        // Reset sur changement d’unité cible.
        private void cbWeightCible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbWeightResultat.ClearValue(TextBlock.TextProperty);
            txtWeightSource.Clear();
        }

        // Conversion du poids à chaque changement de saisie.
        private void txtWeightSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            string? source = (cbWeightSource.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? cible = (cbWeightCible.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (source is null || cible is null)
                return;

            if (string.IsNullOrEmpty(txtWeightSource.Text))
            {
                tbWeightResultat.ClearValue(TextBlock.TextProperty);
                return;
            }

            if (!double.TryParse(txtWeightSource.Text, out double value))
            {
                tbWeightResultat.Text = "0";
                return;
            }

            // Conversion selon l’unité cible, puis selon l’unité source.
            switch (cible)
            {
                case "Kilogrammes":
                    switch (source)
                    {
                        case "Kilogrammes":
                            tbWeightResultat.Text = value.ToString("0.##");
                            break;
                        case "Grammes":
                            tbWeightResultat.Text = (value / 1000.0).ToString("0.##");
                            break;
                        case "Livres":
                            tbWeightResultat.Text = (value * 0.45359237).ToString("0.##");
                            break;
                    }
                    break;

                case "Grammes":
                    switch (source)
                    {
                        case "Kilogrammes":
                            tbWeightResultat.Text = (value * 1000.0).ToString("0.##");
                            break;
                        case "Grammes":
                            tbWeightResultat.Text = value.ToString("0.##");
                            break;
                        case "Livres":
                            tbWeightResultat.Text = (value * 453.59237).ToString("0.##");
                            break;
                    }
                    break;

                case "Livres":
                    switch (source)
                    {
                        case "Kilogrammes":
                            tbWeightResultat.Text = (value / 0.45359237).ToString("0.##");
                            break;
                        case "Grammes":
                            tbWeightResultat.Text = (value / 453.59237).ToString("0.##");
                            break;
                        case "Livres":
                            tbWeightResultat.Text = value.ToString("0.##");
                            break;
                    }
                    break;
            }
        }

        // Validation de la saisie poids,accepte les chiffres et les séparateurs décimaux avant et après la virgule.
        private void txtWeightSource_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"0123456789,.".Contains(e.Text);
        }

        // -----------------------------
        // Longueur
        // -----------------------------

        // Reset sur changement d’unité source.
        private void cbLenghtSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbLenghtResultat.ClearValue(TextBlock.TextProperty);
            txtLenghtSource.Clear();
        }

        // Reset sur changement d’unité cible.
        private void cbLenghtCible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbLenghtResultat.ClearValue(TextBlock.TextProperty);
            txtLenghtSource.Clear();
        }

        // Conversion de la longueur à chaque changement de saisie.
        private void txtLenghtSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            string? source = (cbLenghtSource.SelectedItem as ComboBoxItem)?.Content.ToString();
            string? cible = (cbLenghtCible.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (source is null || cible is null)
                return;

            if (string.IsNullOrEmpty(txtLenghtSource.Text))
            {
                tbLenghtResultat.ClearValue(TextBlock.TextProperty);
                return;
            }

            if (!double.TryParse(txtLenghtSource.Text, out double value))
            {
                tbLenghtResultat.Text = "0";
                return;
            }

            // Conversion selon l’unité cible, puis selon l’unité source.
            switch (cible)
            {
                case "Mètres":
                    switch (source)
                    {
                        case "Mètres":
                            tbLenghtResultat.Text = value.ToString("0.##");
                            break;
                        case "Centimètres":
                            tbLenghtResultat.Text = (value / 100.0).ToString("0.##");
                            break;
                        case "Pouces":
                            tbLenghtResultat.Text = (value * 0.0254).ToString("0.##");
                            break;
                    }
                    break;

                case "Centimètres":
                    switch (source)
                    {
                        case "Mètres":
                            tbLenghtResultat.Text = (value * 100.0).ToString("0.##");
                            break;
                        case "Centimètres":
                            tbLenghtResultat.Text = value.ToString("0.##");
                            break;
                        case "Pouces":
                            tbLenghtResultat.Text = (value * 2.54).ToString("0.##");
                            break;
                    }
                    break;

                case "Pouces":
                    switch (source)
                    {
                        case "Mètres":
                            tbLenghtResultat.Text = (value / 0.0254).ToString("0.##");
                            break;
                        case "Centimètres":
                            tbLenghtResultat.Text = (value / 2.54).ToString("0.##");
                            break;
                        case "Pouces":
                            tbLenghtResultat.Text = value.ToString("0.##");
                            break;
                    }
                    break;
            }
        }

        // Validation de la saisie longueur, accepte les chiffres et les séparateurs décimaux avant et après la virgule.
        private void txtLenghtSource_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"0123456789,.".Contains(e.Text);
        }
    }
}


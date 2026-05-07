using Avalonia.Controls;
using Avalonia.Interactivity;

namespace T1;

public partial class ProductDialog : Window
{
    public Product? Result { get; private set; }

    public ProductDialog()
    {
        InitializeComponent();
    }

    public ProductDialog(Product? product = null)
    {
        InitializeComponent();

        if (product != null)
        {
            DialogTitle.Text = "Редактировать товар";
            NameBox.Text = product.Name;
            QuantityBox.Text = product.Quantity.ToString();
            PriceBox.Text = product.Price.ToString("F2");
            DescriptionBox.Text = product.Description;
            
            SetComboBoxByContent(CategoryBox, product.Category);
            SetComboBoxByContent(UnitBox, product.Unit);
        }
        else
        {
            CategoryBox.SelectedIndex = 0;
            UnitBox.SelectedIndex = 0;
        }
    }

    private void SetComboBoxByContent(ComboBox box, string value)
    {
        for (int i = 0; i < box.ItemCount; i++)
        {
            if (box.Items[i] is ComboBoxItem item && item.Content?.ToString() == value)
            {
                box.SelectedIndex = i;
                return;
            }
        }
        box.SelectedIndex = 0;
    }

    private void OnSave(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameBox.Text))
        {
            ShowError("Введите наименование товара.");
            return;
        }

        if (!int.TryParse(QuantityBox.Text, out int qty) || qty < 0)
        {
            ShowError("Количество должно быть целым неотрицательным числом.");
            return;
        }

        if (!decimal.TryParse(PriceBox.Text?.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal price) || price < 0)
        {
            ShowError("Цена должна быть неотрицательным числом.");
            return;
        }

        var category = (CategoryBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Другое";
        var unit = (UnitBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "шт";

        Result = new Product
        {
            Name = NameBox.Text.Trim(),
            Category = category,
            Quantity = qty,
            Price = price,
            Unit = unit,
            Description = string.IsNullOrWhiteSpace(DescriptionBox.Text) ? null : DescriptionBox.Text.Trim()
        };

        Close(true);
    }

    private void OnCancel(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }

    private async void ShowError(string message)
    {
        var dialog = new Window
        {
            Title = "Ошибка",
            Width = 320,
            Height = 150,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Background = Avalonia.Media.Brush.Parse("#1E1E2E"),
            CanResize = false,
            Content = new StackPanel
            {
                Margin = new Avalonia.Thickness(24),
                Spacing = 16,
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        Foreground = Avalonia.Media.Brush.Parse("#E0E0F0"),
                        TextWrapping = Avalonia.Media.TextWrapping.Wrap
                    },
                    new Button
                    {
                        Content = "OK",
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                        Background = Avalonia.Media.Brush.Parse("#5B5BF0"),
                        Foreground = Avalonia.Media.Brushes.White,
                        Padding = new Avalonia.Thickness(24, 8),
                        CornerRadius = new Avalonia.CornerRadius(6)
                    }
                }
            }
        };

        var btn = ((StackPanel)dialog.Content).Children[1] as Button;
        btn!.Click += (_, _) => dialog.Close();

        await dialog.ShowDialog(this);
    }
}
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace T1;

public partial class ProductDialog : Window
{
    public Product? Result { get; private set; }

    public ProductDialog()
    {
        InitializeComponent();
        CategoryBox.SelectedIndex = 0;
        UnitBox.SelectedIndex = 0;
    }

    public ProductDialog(Product product)
    {
        InitializeComponent();
        DialogTitle.Text    = "Редактировать товар";
        NameBox.Text        = product.Name;
        QuantityBox.Text    = product.Quantity.ToString();
        PriceBox.Text       = product.Price.ToString("F2");
        DescriptionBox.Text = product.Description;
        SetCombo(CategoryBox, product.Category);
        SetCombo(UnitBox, product.Unit);
    }

    private void SetCombo(ComboBox box, string value)
    {
        for (int i = 0; i < box.ItemCount; i++)
            if (box.Items[i] is ComboBoxItem item && item.Content?.ToString() == value)
            { box.SelectedIndex = i; return; }
        box.SelectedIndex = 0;
    }

    private void OnSave(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameBox.Text))
            { ShowError("Введите наименование."); return; }

        if (!int.TryParse(QuantityBox.Text, out int qty) || qty < 0)
            { ShowError("Некорректное количество."); return; }

        if (!decimal.TryParse(PriceBox.Text?.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out decimal price) || price < 0)
            { ShowError("Некорректная цена."); return; }

        Result = new Product
        {
            Name        = NameBox.Text.Trim(),
            Category    = (CategoryBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Другое",
            Quantity    = qty,
            Price       = price,
            Unit        = (UnitBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "шт",
            Description = string.IsNullOrWhiteSpace(DescriptionBox.Text) ? null : DescriptionBox.Text.Trim()
        };
        Close(true);
    }

    private void OnCancel(object? sender, RoutedEventArgs e) => Close(false);

    private async void ShowError(string message)
    {
        var box = MsBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandard("Ошибка", message, MsBox.Avalonia.Enums.ButtonEnum.Ok);
        await box.ShowWindowDialogAsync(this);
    }
}
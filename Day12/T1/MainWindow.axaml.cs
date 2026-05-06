using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using T1;

namespace T1;

public partial class MainWindow : Window
{
    // Все товары
    private readonly List<Product> _allProducts = new();

    // Отображаемые товары (после фильтрации)
    private readonly ObservableCollection<ProductViewModel> _displayProducts = new();

    private int _nextId = 1;

    public MainWindow()
    {
        InitializeComponent();

        ProductGrid.ItemsSource = _displayProducts;
        ProductGrid.SelectionChanged += (_, _) => UpdateStatusBar();

        // Демо-данные
        LoadDemoData();
        RefreshGrid();
    }

    private void LoadDemoData()
    {
        var demo = new[]
        {
            new Product { Name = "Ноутбук Dell XPS 15",      Category = "Электроника",    Quantity = 12,  Price = 89990,  Unit = "шт", Description = "Core i7, 16GB RAM" },
            new Product { Name = "Монитор LG 27\"",           Category = "Электроника",    Quantity = 8,   Price = 32500,  Unit = "шт" },
            new Product { Name = "Клавиатура механическая",   Category = "Электроника",    Quantity = 45,  Price = 4800,   Unit = "шт" },
            new Product { Name = "Мука пшеничная в/с",        Category = "Продукты",       Quantity = 200, Price = 65,     Unit = "кг" },
            new Product { Name = "Масло подсолнечное",        Category = "Продукты",       Quantity = 150, Price = 110,    Unit = "л",  Description = "Нерафинированное" },
            new Product { Name = "Куртка рабочая утеплённая", Category = "Одежда",         Quantity = 30,  Price = 2900,   Unit = "шт" },
            new Product { Name = "Перчатки защитные",         Category = "Одежда",         Quantity = 500, Price = 120,    Unit = "шт" },
            new Product { Name = "Дрель-шуруповёрт Bosch",   Category = "Инструменты",    Quantity = 15,  Price = 7600,   Unit = "шт", Description = "18V, с аккумулятором" },
            new Product { Name = "Цемент М400",               Category = "Стройматериалы", Quantity = 300, Price = 380,    Unit = "кг" },
            new Product { Name = "Кирпич облицовочный",       Category = "Стройматериалы", Quantity = 1000,Price = 28,     Unit = "шт" },
        };

        foreach (var p in demo)
        {
            p.Id = _nextId++;
            _allProducts.Add(p);
        }
    }

    // ─── Добавить ────────────────────────────────────────────────────────────

    private async void OnAdd(object? sender, RoutedEventArgs e)
    {
        var dialog = new ProductDialog();
        var result = await dialog.ShowDialog<bool>(this);

        if (result && dialog.Result != null)
        {
            dialog.Result.Id = _nextId++;
            _allProducts.Add(dialog.Result);
            RefreshGrid();
            SetStatus($"Товар «{dialog.Result.Name}» добавлен.");
        }
    }

    // ─── Редактировать ───────────────────────────────────────────────────────

    private async void OnEdit(object? sender, RoutedEventArgs e)
    {
        var selected = ProductGrid.SelectedItem as ProductViewModel;
        if (selected == null)
        {
            SetStatus("Выберите товар для редактирования.");
            return;
        }

        var original = _allProducts.First(p => p.Id == selected.Id);
        var dialog = new ProductDialog(original);
        var result = await dialog.ShowDialog<bool>(this);

        if (result && dialog.Result != null)
        {
            // Обновляем оригинальный объект
            original.Name        = dialog.Result.Name;
            original.Category    = dialog.Result.Category;
            original.Quantity    = dialog.Result.Quantity;
            original.Price       = dialog.Result.Price;
            original.Unit        = dialog.Result.Unit;
            original.Description = dialog.Result.Description;

            RefreshGrid();
            SetStatus($"Товар «{original.Name}» обновлён.");
        }
    }

    // ─── Удалить ─────────────────────────────────────────────────────────────

    private async void OnDelete(object? sender, RoutedEventArgs e)
    {
        var selected = ProductGrid.SelectedItem as ProductViewModel;
        if (selected == null)
        {
            SetStatus("Выберите товар для удаления.");
            return;
        }

        // Окно подтверждения
        var confirmed = await ConfirmDialog($"Удалить товар «{selected.Name}»?");
        if (!confirmed) return;

        var original = _allProducts.First(p => p.Id == selected.Id);
        _allProducts.Remove(original);
        RefreshGrid();
        SetStatus($"Товар «{selected.Name}» удалён.");
    }

    // ─── Поиск и фильтрация ──────────────────────────────────────────────────

    private void OnSearchChanged(object? sender, TextChangedEventArgs e) => RefreshGrid();
    private void OnFilterChanged(object? sender, SelectionChangedEventArgs e) => RefreshGrid();

    private void RefreshGrid()
    {
        var search   = SearchBox?.Text?.Trim().ToLower() ?? "";
        var category = (CategoryFilter?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
        var filterAll = category == "Все категории" || string.IsNullOrEmpty(category);

        var filtered = _allProducts
            .Where(p => filterAll || p.Category == category)
            .Where(p => string.IsNullOrEmpty(search) || p.Name.ToLower().Contains(search))
            .Select(p => new ProductViewModel(p))
            .ToList();

        _displayProducts.Clear();
        foreach (var p in filtered)
            _displayProducts.Add(p);

        UpdateStats();
    }

    // ─── Статистика ──────────────────────────────────────────────────────────

    private void UpdateStats()
    {
        TotalCountText.Text = _displayProducts.Count.ToString();
        var sum = _displayProducts.Sum(p => p.Price * p.Quantity);
        TotalSumText.Text = $"{sum:N0} ₽";
    }

    private void UpdateStatusBar()
    {
        var selected = ProductGrid.SelectedItem as ProductViewModel;
        SelectionText.Text = selected != null
            ? $"Выбрано: {selected.Name}"
            : "";
    }

    private void SetStatus(string message) => StatusText.Text = message;

    // ─── Диалог подтверждения ────────────────────────────────────────────────

    private System.Threading.Tasks.Task<bool> ConfirmDialog(string message)
    {
        var tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();

        var yesBtn = new Button
        {
            Content = "Удалить",
            Background = Avalonia.Media.Brush.Parse("#C0392B"),
            Foreground = Avalonia.Media.Brushes.White,
            Padding = new Avalonia.Thickness(20, 8),
            CornerRadius = new Avalonia.CornerRadius(6)
        };
        var noBtn = new Button
        {
            Content = "Отмена",
            Background = Avalonia.Media.Brush.Parse("#2A2A3E"),
            Foreground = Avalonia.Media.Brush.Parse("#A0A0C0"),
            Padding = new Avalonia.Thickness(20, 8),
            CornerRadius = new Avalonia.CornerRadius(6)
        };

        var dialog = new Window
        {
            Title = "Подтверждение",
            Width = 340,
            Height = 160,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Background = Avalonia.Media.Brush.Parse("#1E1E2E"),
            CanResize = false,
            Content = new StackPanel
            {
                Margin = new Avalonia.Thickness(24),
                Spacing = 20,
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        Foreground = Avalonia.Media.Brush.Parse("#E0E0F0"),
                        TextWrapping = Avalonia.Media.TextWrapping.Wrap,
                        FontSize = 14
                    },
                    new StackPanel
                    {
                        Orientation = Avalonia.Layout.Orientation.Horizontal,
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                        Spacing = 10,
                        Children = { noBtn, yesBtn }
                    }
                }
            }
        };

        yesBtn.Click += (_, _) => { tcs.SetResult(true);  dialog.Close(); };
        noBtn.Click  += (_, _) => { tcs.SetResult(false); dialog.Close(); };
        dialog.Closed += (_, _) => { if (!tcs.Task.IsCompleted) tcs.SetResult(false); };

        dialog.ShowDialog(this);
        return tcs.Task;
    }
}

// ─── ViewModel-обёртка для DataGrid ──────────────────────────────────────────

public class ProductViewModel
{
    public int Id { get; }
    public string Name { get; }
    public string Category { get; }
    public int Quantity { get; }
    public string Unit { get; }
    public decimal Price { get; }
    public decimal TotalValue { get; }
    public string? Description { get; }

    public ProductViewModel(Product p)
    {
        Id          = p.Id;
        Name        = p.Name;
        Category    = p.Category;
        Quantity    = p.Quantity;
        Unit        = p.Unit;
        Price       = p.Price;
        TotalValue  = p.Price * p.Quantity;
        Description = p.Description;
    }
}
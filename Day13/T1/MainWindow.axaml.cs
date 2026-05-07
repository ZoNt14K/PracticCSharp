using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace T1;

public partial class MainWindow : Window
{
    private readonly List<Product> _allProducts = new();
    private readonly ObservableCollection<ProductViewModel> _displayProducts = new();
    private int _nextId = 1;

    public ICommand AddProductCommand    { get; }
    public ICommand EditProductCommand   { get; }
    public ICommand DeleteProductCommand { get; }

    public MainWindow()
    {
        AddProductCommand    = new RelayCommand(async () => await DoAdd());
        EditProductCommand   = new RelayCommand(async () => await DoEdit());
        DeleteProductCommand = new RelayCommand(async () => await DoDelete());

        InitializeComponent();
        DataContext = this;

        ProductGrid.ItemsSource = _displayProducts;
        ProductGrid.SelectionChanged += (_, _) => UpdateStatusBar();

        LoadDemoData();
        RefreshGrid();
    }

    private void LoadDemoData()
    {
        var demo = new[]
        {
            new Product { Name = "Ноутбук Dell XPS 15",      Category = "Электроника",    Quantity = 12,   Price = 89990, Unit = "шт", Description = "Core i7, 16GB RAM" },
            new Product { Name = "Монитор LG 27\"",           Category = "Электроника",    Quantity = 8,    Price = 32500, Unit = "шт" },
            new Product { Name = "Клавиатура механическая",   Category = "Электроника",    Quantity = 45,   Price = 4800,  Unit = "шт" },
            new Product { Name = "Мука пшеничная в/с",        Category = "Продукты",       Quantity = 200,  Price = 65,    Unit = "кг" },
            new Product { Name = "Масло подсолнечное",        Category = "Продукты",       Quantity = 150,  Price = 110,   Unit = "л",  Description = "Нерафинированное" },
            new Product { Name = "Куртка рабочая утеплённая", Category = "Одежда",         Quantity = 30,   Price = 2900,  Unit = "шт" },
            new Product { Name = "Перчатки защитные",         Category = "Одежда",         Quantity = 500,  Price = 120,   Unit = "шт" },
            new Product { Name = "Дрель-шуруповёрт Bosch",   Category = "Инструменты",    Quantity = 15,   Price = 7600,  Unit = "шт", Description = "18V, с аккумулятором" },
            new Product { Name = "Цемент М400",               Category = "Стройматериалы", Quantity = 300,  Price = 380,   Unit = "кг" },
            new Product { Name = "Кирпич облицовочный",       Category = "Стройматериалы", Quantity = 1000, Price = 28,    Unit = "шт" },
        };
        foreach (var p in demo) { p.Id = _nextId++; _allProducts.Add(p); }
    }

    // ─── Команды ─────────────────────────────────────────────────────────────

    private async System.Threading.Tasks.Task DoAdd()
    {
        var dialog = new ProductDialog();
        var ok = await dialog.ShowDialog<bool>(this);
        if (ok && dialog.Result != null)
        {
            dialog.Result.Id = _nextId++;
            _allProducts.Add(dialog.Result);
            RefreshGrid();
            SetStatus($"Добавлен: {dialog.Result.Name}");
        }
    }

    private async System.Threading.Tasks.Task DoEdit()
    {
        var vm = ProductGrid.SelectedItem as ProductViewModel;
        if (vm == null) { SetStatus("Выберите товар для редактирования."); return; }

        var original = _allProducts.First(p => p.Id == vm.Id);
        var dialog = new ProductDialog(original);
        var ok = await dialog.ShowDialog<bool>(this);
        if (ok && dialog.Result != null)
        {
            original.Name        = dialog.Result.Name;
            original.Category    = dialog.Result.Category;
            original.Quantity    = dialog.Result.Quantity;
            original.Price       = dialog.Result.Price;
            original.Unit        = dialog.Result.Unit;
            original.Description = dialog.Result.Description;
            RefreshGrid();
            SetStatus($"Обновлён: {original.Name}");
        }
    }

    private async System.Threading.Tasks.Task DoDelete()
    {
        var vm = ProductGrid.SelectedItem as ProductViewModel;
        if (vm == null) { SetStatus("Выберите товар для удаления."); return; }

        var box = MessageBoxManager.GetMessageBoxStandard(
            "Подтверждение", $"Удалить «{vm.Name}»?", ButtonEnum.YesNo);
        var answer = await box.ShowWindowDialogAsync(this);
        if (answer != ButtonResult.Yes) return;

        _allProducts.RemoveAll(p => p.Id == vm.Id);
        RefreshGrid();
        SetStatus($"Удалён: {vm.Name}");
    }

    // ─── Меню ────────────────────────────────────────────────────────────────

    private void OnExit(object? sender, RoutedEventArgs e) => Close();

    private async void OnAbout(object? sender, RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(
            "О программе", "АРМ Работника Склада\nВерсия 1.0", ButtonEnum.Ok);
        await box.ShowWindowDialogAsync(this);
    }

    // ─── Фильтр / поиск ──────────────────────────────────────────────────────

    private void OnSearchChanged(object? sender, TextChangedEventArgs e) => RefreshGrid();
    private void OnFilterChanged(object? sender, SelectionChangedEventArgs e) => RefreshGrid();

    private void RefreshGrid()
    {
        var search   = SearchBox?.Text?.Trim().ToLower() ?? "";
        var category = (CategoryFilter?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
        var allCats  = category is "Все категории" or "";

        var filtered = _allProducts
            .Where(p => allCats || p.Category == category)
            .Where(p => string.IsNullOrEmpty(search) || p.Name.ToLower().Contains(search))
            .Select(p => new ProductViewModel(p))
            .ToList();

        _displayProducts.Clear();
        foreach (var p in filtered) _displayProducts.Add(p);

        TotalCountText.Text = $"Позиций: {_displayProducts.Count}";
        TotalSumText.Text   = $"Сумма: {_displayProducts.Sum(p => p.Price * p.Quantity):N0} ₽";
    }

    private void UpdateStatusBar()
    {
        var sel = ProductGrid.SelectedItem as ProductViewModel;
        SelectionText.Text = sel != null ? $"Выбрано: {sel.Name}" : "";
    }

    private void SetStatus(string msg) => StatusText.Text = msg;
}

// ─── ViewModel для DataGrid ───────────────────────────────────────────────────

public class ProductViewModel
{
    public int      Id          { get; }
    public string   Name        { get; }
    public string   Category    { get; }
    public int      Quantity    { get; }
    public string   Unit        { get; }
    public decimal  Price       { get; }
    public decimal  TotalValue  { get; }
    public string?  Description { get; }

    public ProductViewModel(Product p)
    {
        Id = p.Id; Name = p.Name; Category = p.Category;
        Quantity = p.Quantity; Unit = p.Unit; Price = p.Price;
        TotalValue = p.Price * p.Quantity; Description = p.Description;
    }
}
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FeelingCards.Models;

namespace FeelingCards.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private int _position;

    public MainViewModel()
    {
        Cards = new ObservableCollection<FeelingCard>(BuildCards());
        NextCommand = new Command(() => Position++, () => !IsLastCard);
        PreviousCommand = new Command(() => Position--, () => !IsFirstCard);
        RebuildIndicators();
    }

    public ObservableCollection<FeelingCard> Cards { get; }

    /// <summary>Dots shown under the card; the dot for the current card is filled.</summary>
    public ObservableCollection<Color> Indicators { get; } = new();

    public ICommand NextCommand { get; }

    public ICommand PreviousCommand { get; }

    /// <summary>Zero-based index of the card currently on screen.</summary>
    public int Position
    {
        get => _position;
        set
        {
            if (_position == value || value < 0 || value >= Cards.Count)
                return;

            _position = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CurrentCard));
            OnPropertyChanged(nameof(IsFirstCard));
            OnPropertyChanged(nameof(IsLastCard));
            OnPropertyChanged(nameof(CounterText));
            RebuildIndicators();
            ((Command)NextCommand).ChangeCanExecute();
            ((Command)PreviousCommand).ChangeCanExecute();
        }
    }

    public FeelingCard CurrentCard => Cards[Position];

    public bool IsFirstCard => Position <= 0;

    public bool IsLastCard => Position >= Cards.Count - 1;

    public string CounterText => $"{Position + 1} of {Cards.Count}";

    public event PropertyChangedEventHandler? PropertyChanged;

    private void RebuildIndicators()
    {
        Indicators.Clear();
        for (var i = 0; i < Cards.Count; i++)
            Indicators.Add(i == Position ? Color.FromArgb("#B03A72") : Color.FromArgb("#EBC4DC"));
    }

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private static IEnumerable<FeelingCard> BuildCards() =>
    [
        new() { Image = "card_01", Prompt = "The internet was broken at school?" },
        new() { Image = "card_02", Prompt = "You lost your mobile phone?" },
        new() { Image = "card_03", Prompt = "It was the beginning of the summer holidays?" },
        new() { Image = "card_04", Prompt = "There was chocolate cake at lunchtime?" },
        new() { Image = "card_05", Prompt = "School finished early tomorrow?" },
        new() { Image = "card_06", Prompt = "You had to miss a break?" },
        new() { Image = "card_07", Prompt = "You went on a rollercoaster?" },
        new() { Image = "card_08", Prompt = "You went to a friend's house?" },
        new() { Image = "card_09", Prompt = "You went to the cinema?" },
        new() { Image = "card_10", Prompt = "You were listening to your favourite music?" },
        new() { Image = "card_11", Prompt = "You didn't do your homework?" },
        new() { Image = "card_12", Prompt = "You had an argument with your friend?" },
        new() { Image = "card_13", Prompt = "You were told off in class?" },
        new() { Image = "card_14", Prompt = "You weren't allowed on the computers?" },
        new() { Image = "card_15", Prompt = "You were late to school?" },
        new() { Image = "card_16", Prompt = "Today was your birthday?" },
        new() { Image = "card_17", Prompt = "It began to snow?" },
        new() { Image = "card_18", Prompt = "You had no one to play with at break?" },
        new() { Image = "card_19", Prompt = "You forgot your lunch?" },
        new() { Image = "card_20", Prompt = "There was a fire alarm?" },
    ];
}

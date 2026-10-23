namespace FeelingCards.Models;

/// <summary>
/// A single "How would you feel if..." card shown in the carousel.
/// <see cref="Image"/> is the file name (without extension) of an image
/// in Resources/Images.
/// </summary>
public class FeelingCard
{
	public required string Image { get; init; }
	public required string Prompt { get; init; }
}

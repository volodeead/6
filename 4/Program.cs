using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InvalidSongException : Exception
{
    public InvalidSongException(string message = "Invalid song.")
        : base(message)
    {
    }
}
public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException(string message = "Artist name should be between 3 and 20 symbols.")
        : base(message)
    {
    }
}
public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException(string message = "Song name should be between 3 and 30 symbols.")
        : base(message)
    {
    }
}
public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException(string message = "Invalid song length.")
        : base(message)
    {
    }
}
public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException(string message = "Song minutes should be between 0 and 14.")
        : base(message)
    {
    }
}
public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException(string message = "Song seconds should be between 0 and 59.")
        : base(message)
    {
    }
}


public class Song
{
    private string name;
    private string artist;
    private int minutes;
    private int seconds;

    public Song(string[] tokens)
    {
        ValidateArgs(tokens);
        this.Artist = tokens[0];
        this.Name = tokens[1];
        int[] lengthArgs = ValidateLength(tokens[2]);
        this.Minutes = lengthArgs[0];
        this.Seconds = lengthArgs[1];
    }

    private string Name
    {
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            this.name = value;
        }
    }

    private string Artist
    {
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            this.artist = value;
        }
    }

    private int Minutes
    {
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }

            this.minutes = value;
        }
    }

    private int Seconds
    {
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            this.seconds = value;
        }
    }

    private void ValidateArgs(string[] tokens)
    {
        if (tokens.Length != 3)
        {
            throw new InvalidSongException();
        }
    }
    private int[] ValidateLength(string length)
    {
        var tokens = length.Split(':');
        if (tokens.Length != 2 || tokens.Any(t => !t.All(c => Char.IsDigit(c))))
        {
            throw new InvalidSongLengthException();
        }

        return tokens.Select(int.Parse).ToArray();
    }
    public int GetLengthInSeconds()
    {
        return this.minutes * 60 + this.seconds;
    }
}

public class Playlist
{
    private List<Song> songs = new List<Song>();

    public string AddSong(Song song)
    {
        songs.Add(song);

        return "Song added.";
    }

    public override string ToString()
    {
        int totalLength = songs.Select(s => s.GetLengthInSeconds()).Sum();
        var builder = new StringBuilder();

        builder.AppendLine($"Songs added: {songs.Count}")
            .Append($"Playlist length: {totalLength / 3600}h {totalLength / 60 % 60}m {totalLength % 60}s");

        return builder.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        Playlist playlist = new Playlist();

        for (int i = 0; i < count; i++)
        {
            string[] input = Console.ReadLine().Split(';');

            try
            {
                Song song = new Song(input);
                Console.WriteLine(playlist.AddSong(song));
                
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        Console.WriteLine(playlist);
        Console.ReadLine();
    }
}